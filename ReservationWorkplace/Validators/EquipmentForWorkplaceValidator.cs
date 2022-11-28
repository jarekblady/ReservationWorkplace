using FluentValidation;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Validators
{
    public class EquipmentForWorkplaceValidator : AbstractValidator<EquipmentForWorkplaceViewModel>
    {
        public EquipmentForWorkplaceValidator()
        {
            RuleFor(x => x.WorkplaceId)
                .NotEmpty().WithMessage("Workplace is required");

            RuleFor(x => x.EquipmentId)
                .NotEmpty().WithMessage("Equipment is required");

            RuleFor(x => x.Count)
                .NotNull().WithMessage("Count is required");
        }
    }
}
