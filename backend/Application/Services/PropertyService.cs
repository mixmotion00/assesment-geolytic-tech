using System;
using Application.Data;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interface;

namespace Application.Services;

public class PropertyService(IPropertyRepository propertyRepository, IMapper mapper)
{
    public IEnumerable<PropertyType> GetAllActiveProperties()
    {
        // load domain entities
        var properties = propertyRepository.GetAllActiveProperty();
        return properties;
    }

    public List<ValuationRequestDto> GetAllValuations()
    {
        // return valuations from data memory that match dto
        var valuations = Database.ValuationRequests;
        var dtos = new List<ValuationRequestDto>();
        foreach (var v in valuations)
        {
            var valDto = mapper.Map<ValuationRequestDto>(v);

            // find property type
            var property = GetPropertyType(v.PropertyTypeId);
            if (property == null)
            {
                Console.WriteLine("Something is wrong, property should return a value");
                continue;
            }
            // include property type into the results
            var propDto = mapper.Map<PropertyTypeDto>(property);
            valDto.PropertyTypeDto = propDto;

            dtos.Add(valDto);
        }

        return dtos;
    }

    public ValuationRequestDto? GetValuationRequestDto(int id)
    {
        var valuation = propertyRepository.GetValuationRequest(id);
        if(valuation == null)
            return null;
        
        var valDto = mapper.Map<ValuationRequestDto>(valuation);
        var property = GetPropertyType(valuation.PropertyTypeId);
        if (property == null)
        {
            Console.WriteLine("Something is wrong, property should return a value");
            return null;
        }
        var propDto = mapper.Map<PropertyTypeDto>(property);
        valDto.PropertyTypeDto = propDto;

        return valDto;

        // return propertyRepository.GetValuationRequest(id);
    }

    public ValuationRequestDto CreateValuationRequest(CreateValuationRequestDto dto)
    {
        // map DTO to entity
        var entity = new ValuationRequest
        {
            // add id on increamenet (probably GUID much better)
            Id = Database.ValuationRequests.Any() ? Database.ValuationRequests.Max(v => v.Id) + 1 : 1,
            PropertyAddress = dto.PropertyAddress,
            PropertyTypeId = dto.PropertyTypeId,
            RequestedValue = dto.RequestedValue,
            Status = Status.Draft,
            RequestDate = DateTimeOffset.UtcNow
        };

        Console.WriteLine($"date:{entity.RequestDate}");

        propertyRepository.CreateValuationRequest(entity);

        // map entity to DTO
        var valDto = mapper.Map<ValuationRequestDto>(entity);
        valDto.PropertyTypeDto = mapper.Map<PropertyTypeDto>(propertyRepository
            .GetPropertyType(entity.PropertyTypeId));

        return valDto;
    }

    public ValuationRequest? GetValuationRequest(int id)
    {
        return propertyRepository.GetValuationRequest(id);
    }

    public PropertyType? GetPropertyType(int propertyTypeId)
    {
        return propertyRepository.GetPropertyType(propertyTypeId);
    }

    public void UpdateValuationRequest(int valuationReqId, string newStatusStr)
    {
        // var valuation = GetValuationRequest(valuationReqId);
        var valuation = propertyRepository.GetValuationRequest(valuationReqId);

        // shouldn't happen, already checked on fluent validation
        if (!Enum.TryParse<Status>(newStatusStr, true, out var newStatusEnum))
            throw new Exception("Invalid status");

        // validate transition
        if(!IsValidTransition(valuation!.Status, newStatusStr))
        {
            throw new Exception($"Invalid transition from {valuation.Status} to {newStatusStr}");
        }

        // update status
        valuation.Status = newStatusEnum;
    }

    private bool IsValidTransition(Status currStatus, string newStatus)
    {
        if (!Enum.TryParse<Status>(newStatus, true, out var newStatusEnum))
            return false;

        switch (currStatus)
        {
            case Status.Draft:
                return newStatusEnum == Status.Submitted;

            case Status.Submitted:
                return newStatusEnum == Status.InProgress;

            case Status.InProgress:
                return false; // cannot transition further

            default:
                return false;
        }
    }
}
