using FluentValidation;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Validators
{
    public class EquipmentValidator : AbstractValidator<EquipmentViewModel>
    {
        public EquipmentValidator()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Equipment type is required");
        }
    }
}

