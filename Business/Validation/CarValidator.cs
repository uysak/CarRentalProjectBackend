using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandID).NotEmpty();
            RuleFor(c => c.BrandID).GreaterThan(0);

            RuleFor(c => c.ColorID).NotEmpty();
            RuleFor(c => c.ColorID).GreaterThan(0);

            
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan((short)0);

            RuleFor(c=>c.Engine).NotEmpty();

            RuleFor(c => c.FuelID).NotEmpty();
            RuleFor(c => c.FuelID).GreaterThan(0);

            RuleFor(c => c.Model).NotEmpty();
        }

    }
}
