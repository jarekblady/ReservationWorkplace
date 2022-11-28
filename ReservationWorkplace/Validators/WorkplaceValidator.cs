using FluentValidation;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Validators
{
    public class WorkplaceValidator : AbstractValidator<WorkplaceViewModel>
    {
        public WorkplaceValidator()
        {
            RuleFor(x => x.Floor)
                .NotNull().WithMessage("Floor is required");

            RuleFor(x => x.Room)
                .NotNull().WithMessage("Room is required");

            RuleFor(x => x.Table)
                .NotNull().WithMessage("Table is required");
        }
    }
}
