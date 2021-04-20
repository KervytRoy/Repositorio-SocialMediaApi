using FluentValidation;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLogin>
    {
        public UserLoginValidator()
        {
            RuleFor(userlogin => userlogin.User)
                .NotEmpty()
                .WithMessage("Debe ingresar un Usuario Válido");

            RuleFor(userlogin => userlogin.User)
                .Length(1, 30)
                .WithMessage("Excedió el límite de caracteres");

            RuleFor(userlogin => userlogin.User)
                .NotNull()
                .WithMessage("Debe ingresar un Usuario Válido");

            RuleFor(userlogin => userlogin.Password)
                .NotEmpty()
                .WithMessage("Debe ingresar una Contraseña Válida");

            RuleFor(userlogin => userlogin.Password)
                .Length(1, 30)
                .WithMessage("Excedió el límite de caracteres");

            RuleFor(userlogin => userlogin.Password)
                .NotNull()
                .WithMessage("Debe ingresar una Contraseña Válida");
        }
    }
}
