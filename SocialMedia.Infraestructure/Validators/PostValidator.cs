using FluentValidation;
using SocialMedia.Core.DTOs;

namespace SocialMedia.Infraestructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 500);
        }
    }
}
