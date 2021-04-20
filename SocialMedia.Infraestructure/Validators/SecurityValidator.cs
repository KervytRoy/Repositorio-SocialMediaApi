using FluentValidation;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Validators
{
    public class SecurityValidator : AbstractValidator<SecurityDto>
    {
        public SecurityValidator()
        {
            RuleFor(securityDto => securityDto.User)
                .NotEmpty()
                .WithMessage("Debe ingresar un Usuario Válido");

            RuleFor(securityDto => securityDto.User)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(securityDto => securityDto.User)
                .NotNull()
                .WithMessage("Debe ingresar un Usuario Válido");

            RuleFor(securityDto => securityDto.Password)
                .NotEmpty()
                .WithMessage("Debe ingresar una Contraseña Válida");

            RuleFor(securityDto => securityDto.Password)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(securityDto => securityDto.Password)
                .NotNull()
                .WithMessage("Debe ingresar una Contraseña Válida");

            RuleFor(securityDto => securityDto.UserName)
                .NotEmpty()
                .WithMessage("Debe ingresar un Nombre de Usuario Válido");

            RuleFor(securityDto => securityDto.UserName)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(securityDto => securityDto.UserName)
                .NotNull()
                .WithMessage("Debe ingresar un Nombre de Usuario Válido");

            RuleFor(securityDto => securityDto.Role)
                .NotEmpty()
                .WithMessage("Debe ingresar un Rol Válido");

            RuleFor(securityDto => securityDto.Role)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(securityDto => securityDto.Role)
                .NotNull()
                .WithMessage("Debe ingresar un Rol Válido");

            RuleFor(securityDto => securityDto.Role)
                .Must(securityDto => securityDto.Contains("Administrator") || securityDto.Contains("Consumer"))
                .WithMessage("Debe ingresar un Rol Válido");
        }
    }
}
