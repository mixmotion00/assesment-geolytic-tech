using System;

namespace Application.Dtos;

public class CreateValuationRequestDto
{
    public string PropertyAddress { get; set; } = "";

    public int PropertyTypeId { get; set; }

    public decimal RequestedValue { get; set; }
    public string Remarks { get; set; } = "";
}
