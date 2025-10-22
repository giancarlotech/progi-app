using FluentValidation;
using Progi.Api.DTOs;

namespace Progi.Api.Validators
{
    public class FeeRequestValidator : AbstractValidator<FeeRequest>
    {
        public FeeRequestValidator()
        {
            RuleFor(x => x.VehiclePrice)
                .GreaterThan(0)
                .WithMessage("Vehicle price must be greater than zero.");

            RuleFor(x => x.VehicleType)
             .IsInEnum()
             .WithMessage("Vehicle type must be either 'Common = 1' or 'Luxury = 2'.");
        }
    }
}