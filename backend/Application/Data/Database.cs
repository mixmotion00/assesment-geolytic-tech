using System;
using Domain.Entities;

namespace Application.Data;

public static class Database
{
    // Property Types
    public static List<PropertyType> PropertyTypes { get; set; } = new List<PropertyType>();

    // Valuation Requests
    public static List<ValuationRequest> ValuationRequests { get; set; } = new List<ValuationRequest>();
}
