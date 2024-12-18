using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Client.Create
{
    public class CreateClientCommand : IRequest<string>
    {
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string ConnfigurePasswrod { get; set; }

        [Phone]
        public string PhoneNubmer {  get; set; }
    }
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {

            RuleFor(CreateClientCommand =>
            CreateClientCommand.Name)
                .NotEmpty()
                .WithMessage("Name field is required")
                .MaximumLength(255)
                .WithMessage("Name field has maxLength 255");

            RuleFor(CreateClientCommand =>
            CreateClientCommand.Email)
                .NotEmpty()
                .WithMessage("Email field is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(CreateClientCommand =>
            CreateClientCommand.Password)
                .NotEmpty()
                .WithMessage("Password field is required")
                .MaximumLength(255)
                .WithMessage("Name field has maxLength 255");

            RuleFor(create => create.ConnfigurePasswrod).NotEqual(string.Empty).WithMessage("ConfigurePassword field is required")
                .Equal(create => create.Password).WithMessage("Passwords have to be equal"); 

            RuleFor(CreateClientCommand =>
            CreateClientCommand.PhoneNubmer).NotEmpty().WithMessage("PhoneNubmer field is required"); 
        }
    }
}
