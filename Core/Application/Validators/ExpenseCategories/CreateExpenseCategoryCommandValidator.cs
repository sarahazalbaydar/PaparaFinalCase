using Application.Features.ExpenseCategory.Commands.CreateExpenseCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.ExpenseCategories;

public class CreateExpenseCategoryCommandValidator:AbstractValidator<CreateExpenseCategoryCommandRequest>
{
    public CreateExpenseCategoryCommandValidator()
    {
        RuleFor(x => x.Title).MinimumLength(2).MaximumLength(200);
        RuleFor(x => x.Description).MinimumLength(3).MaximumLength(250);
    }
}
