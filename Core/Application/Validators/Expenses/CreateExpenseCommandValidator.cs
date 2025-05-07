using Application.DTOs;
using Application.Features.Expense.Commands.CreateExpense;
using Application.Features.ExpenseCategory.Commands.CreateExpenseCategory;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Expenses;

public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommandRequest>
{
    public CreateExpenseCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(3).WithMessage("Description must be at least 3 characters.")
            .MaximumLength(250).WithMessage("Description must be less than 250 characters.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0.");

        RuleFor(x => x.AttachmentFilePath)
            .NotNull().WithMessage("Attachment file is required.")
            .Must(BeAValidFileType).WithMessage("Attachment must be a .png, .jpg, .jpeg or .pdf file.");

        RuleFor(x => x.ExpensedDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("ExpensedDate cannot be in the future.");
    }

    private bool BeAValidFileType(IFormFile file)
    {
        if (file == null) return false;

        var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".pdf" };
        var extension = Path.GetExtension(file.FileName).ToLower();
        return allowedExtensions.Contains(extension);
    }
}
