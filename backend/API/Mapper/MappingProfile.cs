using System;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ValuationRequest, ValuationRequestDto>();
        CreateMap<PropertyType, PropertyTypeDto>();
    }
}
