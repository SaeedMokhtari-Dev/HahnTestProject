using FluentValidation;
using FluentValidation.Validators;
using Hahn.ApplicationProcess.December2020.Domain.HTTPClients;
using Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Validators.EmployeeValidators
{
    public class EmployeeUpdateValidator: AbstractValidator<EmployeeUpdate> {
        private readonly RestCountryClient _restCountryClient;
        public EmployeeUpdateValidator(RestCountryClient restCountryClient)
        {
            _restCountryClient = restCountryClient;
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a name")
                .MinimumLength(5).WithMessage("Minimum length of Name is {MinLength} characters");
            RuleFor(x => x.FamilyName).NotEmpty().WithMessage("Please specify a family name")
                .MinimumLength(5).WithMessage("Minimum length of family is {MinLength} characters");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Please specify an address")
                .MinimumLength(10).WithMessage("Minimum length of address is {MinLength} characters");
            RuleFor(x => x.CountryOfOrigin).NotEmpty().WithMessage("Please specify a CountryOfOrigin")
                .MustAsync(async (countryOfOrigin, cancellation) =>
                {
                    var result = await _restCountryClient.SearchByFullName(countryOfOrigin);
                    return !string.IsNullOrEmpty(result);
                }).WithMessage("Please specify a valid country name");
            RuleFor(x => x.EMailAddress).NotEmpty().WithMessage("Please specify an EMailAddress")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.Age).NotEmpty().WithMessage("Please specify an Age")
                .GreaterThanOrEqualTo(20).LessThanOrEqualTo(60);
            RuleFor(x => x.Hired).NotNull();
        }
    }
}