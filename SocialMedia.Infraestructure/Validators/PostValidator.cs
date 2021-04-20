﻿using FluentValidation;
using SocialMedia.Core.DTOs;
using System;

namespace SocialMedia.Infraestructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Usuario Inexistente");

            RuleFor(post => post.Description)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula");

            RuleFor(post => post.Description)
                .Length(10, 500)
                .WithMessage("La longitud de la descripcion debe estar entre 10 y 500 caracteres");

            RuleFor(post => post.Date)
                .NotNull()
                .Equal(DateTime.Now.Date)
                .WithMessage("La Fecha debe ser igual al día de hoy y no puede estar vacía");     

        }
    }
}
