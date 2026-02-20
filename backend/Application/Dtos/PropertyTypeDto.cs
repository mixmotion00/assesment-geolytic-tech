using System;

namespace Application.Dtos;

public class PropertyTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public bool IsActive { get; set; }
}
