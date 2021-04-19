using FluentValidation;
using SocialMedia.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Validators
{
    public class ImageValidator : AbstractValidator<ImageUpload>
    {
        public ImageValidator()
        {
            RuleFor(image => image.Image)
                .Must(image => image.Length / 1024 < 2048)
                .WithMessage("La imagen debe pesar menos de 2MB");

            RuleFor(image => image.Image)
                .NotNull()
                .WithMessage("Debe enviar una imagen");

            RuleFor(image => image.Image)
                .Must(image => image.ContentType == "image/png" || image.ContentType == "image.jpg")
                .WithMessage("Solo se pueden emviar imágenes");
        }
    }
}
