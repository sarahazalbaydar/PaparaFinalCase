using Application.Features.ExpenseCategory.Commands.CreateExpenseCategory;
using Application.Features.ExpenseCategory.Commands.UpdateExpenseCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.ExpenseCategories;

public class UpdateExpenseCategoryCommandValidator : AbstractValidator<UpdateExpenseCategoryCommandRequest>
{
    public UpdateExpenseCategoryCommandValidator()
    {
        RuleFor(x => x.Title).MinimumLength(2).MaximumLength(200);
        RuleFor(x => x.Description).MinimumLength(2).MaximumLength(250);
    }
}
