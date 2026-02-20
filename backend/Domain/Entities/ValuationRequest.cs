using System;
using Domain.Enums;

namespace Domain.Entities;

public class ValuationRequest
{
    public int Id { get; set; }
    public string PropertyAddress { get; set; } = "";
    public int PropertyTypeId { get; set; }
    public decimal RequestedValue { get; set; }
    public Status Status { get; set; } = Status.Draft;
    public DateTimeOffset RequestDate {get;set;}
    public string Remarks { get; set; } = "";
}
