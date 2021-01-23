using FluentValidation;
using Hahn.ApplicationProcess.December2020.Domain.Models.ApplicantModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Validators.ApplicantValidators
{
    public class ApplicantDeleteValidator: AbstractValidator<ApplicantDelete> {
        public ApplicantDeleteValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}