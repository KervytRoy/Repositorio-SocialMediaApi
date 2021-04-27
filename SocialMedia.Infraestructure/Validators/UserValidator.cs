using FluentValidation;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(userDto => userDto.UserIdentity)
                .NotEmpty()
                .WithMessage("Debe ingresar un Usuario Válido");

            RuleFor(userDto => userDto.UserIdentity)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(userDto => userDto.UserIdentity)
                .NotNull()
                .WithMessage("Debe ingresar un Usuario Válido");

            RuleFor(userDto => userDto.LastName)
                .NotEmpty()
                .WithMessage("Debe ingresar un Apellido Válido");

            RuleFor(userDto => userDto.LastName)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(userDto => userDto.LastName)
                .NotNull()
                .WithMessage("Debe ingresar un Apellido Válido");

            RuleFor(userDto => userDto.Email)
                .NotEmpty()
                .WithMessage("Debe ingresar un Email Válido");

            RuleFor(userDto => userDto.Email)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(userDto => userDto.Email)
                .NotNull()
                .WithMessage("Debe ingresar un Email Válido");

            RuleFor(userDto => userDto.Password)
                .NotEmpty()
                .WithMessage("Debe ingresar una Contraseña Válida");

            RuleFor(userDto => userDto.Password)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(userDto => userDto.Password)
                .NotNull()
                .WithMessage("Debe ingresar una Contraseña Válida");

            RuleFor(userDto => userDto.FirstName)
                .NotEmpty()
                .WithMessage("Debe ingresar un Nombre de Usuario Válido");

            RuleFor(userDto => userDto.FirstName)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(userDto => userDto.FirstName)
                .NotNull()
                .WithMessage("Debe ingresar un Nombre de Usuario Válido");

            RuleFor(userDto => userDto.Role)
                .NotEmpty()
                .WithMessage("Debe ingresar un Rol Válido");

            RuleFor(userDto => userDto.Role)
                .Length(1, 30)
                .WithMessage("Debe ingresar entre 1 y 30 caracteres");

            RuleFor(userDto => userDto.Role)
                .NotNull()
                .WithMessage("Debe ingresar un Rol Válido");

            RuleFor(userDto => userDto.Role)
                .Must(userDto => userDto.Contains("Administrator") || userDto.Contains("Consumer"))
                .WithMessage("Debe ingresar un Rol Válido");
        }
    }
}
