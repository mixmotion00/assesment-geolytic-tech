using System;
using Domain.Entities;

namespace Application.Data;

public class Seeder
{
    public static void Seed()
    {
        // for mvp, always reset all property type
        Database.PropertyTypes = new List<PropertyType>
        {
             new PropertyType
            {
                Id = 1,
                Name = "Residential",
                Code = "Res",
                IsActive = true
            },
            new PropertyType
            {
                Id = 2,
                Name = "Commercial",
                Code = "Com",
                IsActive = true
            },
            new PropertyType
            {
                Id = 3,
                Name = "Industrial",
                Code = "Ind",
                IsActive = true
            }
        };

        Console.WriteLine($"Succesfully create property, {Database.PropertyTypes.Count}");
    }
}
