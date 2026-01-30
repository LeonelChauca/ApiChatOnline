using System;
using ApiChatOnline.Models.Dtos.Auth;
using FluentValidation;

namespace ApiChatOnline.Controllers.Validations;

public class LoginValidation : AbstractValidator<LogindDto>
{
    public LoginValidation()
    {
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
