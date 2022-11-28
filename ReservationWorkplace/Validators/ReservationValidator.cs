using FluentValidation;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty().WithMessage("Employee is required");

            RuleFor(x => x.WorkplaceId)
                .NotEmpty().WithMessage("Workplace is required");

            RuleFor(x => x.TimeFrom)
                .NotNull().WithMessage("TimeFrom is required");

            RuleFor(x => x.TimeTo)
                .NotNull().WithMessage("TimeTo is required")
                .GreaterThan(x => x.TimeFrom).WithMessage("TimeTo must be after this TimeFrom");
        }
    }
}

