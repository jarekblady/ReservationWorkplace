using FluentValidation;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Employee.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(x => x.Employee.LastName)
                .NotEmpty().WithMessage("Last Name is required");
        }
    }
}
