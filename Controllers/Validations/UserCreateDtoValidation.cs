using System;
using ApiChatOnline.Models.Dtos.User;
using FluentValidation;

namespace ApiChatOnline.Controllers.Validations;

public class UserValidation : AbstractValidator<CreateUserDto>
{
    public UserValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre es obligatorio.")
            .MaximumLength(50)
            .WithMessage("El nombre no puede tener más de 50 caracteres.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("El apellido es obligatorio.")
            .MaximumLength(50)
            .WithMessage("El apellido no puede tener más de 50 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El correo electrónico es obligatorio.")
            .EmailAddress()
            .WithMessage("El correo electrónico no es válido.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es obligatoria.")
            .MinimumLength(6)
            .WithMessage("La contraseña debe tener al menos 6 caracteres.");
    }
}
