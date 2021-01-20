using FluentValidation;
using Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Validators.EmployeeValidators
{
    public class EmployeeDeleteValidator: AbstractValidator<EmployeeDelete> {
        public EmployeeDeleteValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}