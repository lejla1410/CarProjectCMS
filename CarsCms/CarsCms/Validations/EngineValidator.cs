using CarsCms.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCms.Validations
{
    public class EngineValidator : AbstractValidator<Engine>
    {
        public EngineValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pole nazwy silnika nie może być puste");
            RuleFor(x => x.Capacity).GreaterThan(1500).WithMessage("Pojemność musi być powyżej 1500");
            RuleFor(x => x.Capacity).LessThan(6000).WithMessage("Pojemność musi być poniżej 6000");
            RuleFor(x => x.Name).MaximumLength(16).WithMessage("Nazwa może mieć maksymalnie 16 znaków");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Nazwa może mieć minimalnie 16 znaków");
            RuleFor(x => x.Name).Must(name => UpperFirst(name).WithMessage("Pierwsza litera musi być wielka ");
        }
        public bool UpperFirst(string name)
        {
            //char [] array = name.ToCharArray();
            //if (array.Length >= 1)
            //{
            //    if (char.IsLower(array[0]))
            //    {
            //        array[0] = char.ToUpper(array[0]);
            //    }
            //}
            if (!String.IsNullOrEmpty(name))
            {
                return char.IsUpper(name[0]);
            }
            return false;
        }
    }
}