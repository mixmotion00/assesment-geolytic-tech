using System;
using Application.Data;
using Application.Dtos;
using Domain.Entities;
using Domain.Interface;

namespace API.Repositories;

public class PropertyRepository : IPropertyRepository
{
    public IEnumerable<PropertyType> GetAllActiveProperty()
    {
        var result = Database.PropertyTypes.Where(p => p.IsActive);
        return result;
    }

    public ValuationRequest? GetValuationRequest(int id)
    {
        var result = Database.ValuationRequests.SingleOrDefault(s => s.Id == id);
        return result;
    }

    public void CreateValuationRequest(ValuationRequest request)
    {
        Console.WriteLine($"propRep:{request.RequestDate}");
        Database.ValuationRequests.Add(request);
    }

    public PropertyType? GetPropertyType(int id)
    {
        var result = Database.PropertyTypes.SingleOrDefault(s => s.Id == id);
        return result;
    }
}
