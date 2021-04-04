using FluentValidation;
using SocialMedia.Core.DTOs;
using System;

namespace SocialMedia.Infraestructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula");

            RuleFor(post => post.Description)
                .Length(10, 500)
                .WithMessage("La longitud de la descripcion debe estar entre 10 y 500 caracteress");

            RuleFor(post => post.Date)
                .NotNull().Equal(DateTime.Now);
                //.LessThan(DateTime.Now)
                //.GreaterThan(DateTime.Now);
                

        }
    }
}
