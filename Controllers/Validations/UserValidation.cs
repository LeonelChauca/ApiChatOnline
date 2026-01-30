using System;
using ApiChatOnline.Models.Dtos.User;
using FluentValidation;

namespace ApiChatOnline.Controllers.Validations;

public class UserCreateDtoValidation : AbstractValidator<CreateUserDto>
{
    public UserCreateDtoValidation()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("El nombre es requerido.");
        RuleFor(user => user.LastName).NotEmpty().WithMessage("El apellido es requerido.");
        RuleFor(user => user.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Se requiere un correo electrónico válido.");
        RuleFor(user => user.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithMessage("La contraseña debe tener al menos 6 caracteres.");
    }
}
