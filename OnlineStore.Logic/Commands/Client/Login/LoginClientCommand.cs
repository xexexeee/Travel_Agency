using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Commands.Client.Login
{
    public class LoginClientCommand : IRequest<string> 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    //Временно убрал для моделстэйта
   public class LoginClientCommandValidator : AbstractValidator<LoginClientCommand>
    {
        public LoginClientCommandValidator()
        {
            RuleFor(log => log.Email).NotEmpty().WithMessage("Field Email is required").EmailAddress().WithMessage("Invalid email format");
            RuleFor(log => log.Password).NotEmpty().WithMessage("Field Password is required");
        }
    }
}
