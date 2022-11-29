using FluentValidation;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Validators
{
    public class EquipmentValidator : AbstractValidator<EquipmentViewModel>
    {
        public EquipmentValidator()
        {
            RuleFor(x => x.Equipment.Type).NotEmpty().WithMessage("Equipment type is required");
        }
    }
}

