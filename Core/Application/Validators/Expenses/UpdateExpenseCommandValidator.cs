using Application.Features.Expense.Commands.UpdateExpense;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Expenses;

public class UpdateExpenseCommandValidator:AbstractValidator<UpdateExpenseCommandRequest>
{
    public UpdateExpenseCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status must be a valid enum value.");
        RuleFor(x => x.RejectionReason)
            .MaximumLength(500)
            .WithMessage("Rejection reason cannot exceed 500 characters.");
    }

}
