using System;
using Application.Dtos;
using Application.Services;
using FluentValidation;

namespace API.Validator;

public class CreateValuationValidator : AbstractValidator<CreateValuationRequestDto>
{

    private readonly PropertyService _propertyService;

    public CreateValuationValidator(PropertyService propertyService)
    {
        _propertyService = propertyService;

        // PropertyAddress: required, max 200 chars
        RuleFor(x => x.PropertyAddress)
            .NotEmpty().WithMessage("Property address is required.")
            .MaximumLength(200).WithMessage("Property address must be at most 200 characters.");

        // PropertyTypeId: must exist
        RuleFor(x => x.PropertyTypeId)
            .Must(PropertyTypeExists)
            .WithMessage("The selected property type does not exist.");

        // RequestedValue: must be greater than 0
        RuleFor(x => x.RequestedValue)
            .GreaterThan(0).WithMessage("Requested value must be greater than 0.");

        // Remarks: optional, max 500 characters
        RuleFor(x => x.Remarks)
            .MaximumLength(500)
            .WithMessage("Remarks must be at most 500 characters.");

    }

    private bool PropertyTypeExists(int propertyTypeId)
    {
        var property = _propertyService.GetPropertyType(propertyTypeId);
        return property != null;
    }
}
