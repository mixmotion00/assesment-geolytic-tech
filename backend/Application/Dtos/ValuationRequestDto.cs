using System;

namespace Application.Dtos;

public class ValuationRequestDto
{
    public int Id { get; set; }
    public string PropertyAddress { get; set; } = "";
    public int PropertyTypeId { get; set; }
    public PropertyTypeDto? PropertyTypeDto {get;set;}
    public decimal RequestedValue { get; set; }
    public string Status { get; set; } = "";
    public DateTimeOffset RequestDate {get;set;}
}
