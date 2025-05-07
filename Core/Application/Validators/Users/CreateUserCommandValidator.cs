using Application.Features.User.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandValidator()
        {

            RuleFor(x => x.UserName)
            .MinimumLength(2).WithMessage("Username must be at least 2 characters.").MaximumLength(100);

            RuleFor(x => x.Password)
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^5\d{9}$").WithMessage("Phone number must start with 5 and be 10 digits long (e.g. 5XXXXXXXXX).");

            RuleFor(x => x.IBAN)
                .NotEmpty().WithMessage("IBAN is required.")
                .Matches(@"^TR\d{24}$").WithMessage("IBAN must start with 'TR' followed by 24 digits.");

            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Invalid user role.");

        }
    }
}
