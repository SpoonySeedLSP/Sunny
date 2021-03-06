using FluentValidation;
using Sunny.Api.FluentValidation;
using Sunny.Common.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.FluentValidation2
{
    public class CustomerValidator : Validator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Forename).NotEmpty().WithMessage("PleasFFe specify a first name");
            RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
            RuleFor(x => x.Address).Length(20, 250);
            RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
        }

        private bool BeAValidPostcode(string postcode)
        {
            return postcode == "123";
            // custom postcode validating logic goes here
        }
    }

}
