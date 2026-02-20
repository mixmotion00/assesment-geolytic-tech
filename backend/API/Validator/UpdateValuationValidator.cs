using System;
using Application.Dtos;
using Domain.Enums;
using FluentValidation;

namespace API.Validator;

public class UpdateValuationValidator : AbstractValidator<UpdateStatusDto>
{
    // only validate status constant format
    public UpdateValuationValidator()
    {
        RuleFor(x => x.Status)
            .NotEmpty()
            .Must(status => Enum.TryParse<Status>(status, true, out _))
            .WithMessage("Status must be Draft, Submitted, or InProgress");
    }
}
