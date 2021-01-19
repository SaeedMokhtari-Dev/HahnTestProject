using FluentValidation;
using FluentValidation.Validators;
using Hahn.ApplicationProcess.December2020.Domain.Models.PersonModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Validators.PersonValidators
{
    public class PersonDeleteValidator: AbstractValidator<PersonDelete> {
        public PersonDeleteValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}