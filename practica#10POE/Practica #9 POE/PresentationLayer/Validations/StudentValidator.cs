using CommonLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator() 
        {
            RuleFor(student => student.name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre no puede estar vacio")
                .NotEmpty().MinimumLength(2).WithMessage("El nombre tiene que tener minimo dos letras");

            RuleFor(student => student.code).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre no puede estar vacio")
                .NotEmpty().MinimumLength(2).WithMessage("El nombre tiene que tener minimo dos letras");

            RuleFor(student => student.numberphone).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre no puede estar vacio")
                .NotEmpty().MinimumLength(2).WithMessage("El nombre tiene que tener minimo dos letras");

            RuleFor(student => student.city).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre no puede estar vacio")
                .NotEmpty().MinimumLength(2).WithMessage("El nombre tiene que tener minimo dos letras");
        }

    }
}
