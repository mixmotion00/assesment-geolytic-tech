using System;
using Domain.Entities;

namespace Domain.Interface;

public interface IPropertyRepository
{
    IEnumerable<PropertyType> GetAllActiveProperty();
    ValuationRequest? GetValuationRequest(int id);
    void CreateValuationRequest(ValuationRequest request);
    PropertyType? GetPropertyType(int propertyTypeId);
}
