using Application.Features.ExpenseCategory.Commands.UpdateExpenseCategory;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IExpenseCategoryService
    {

        Task UpdateExpenseCategoryAsync(UpdateExpenseCategoryCommandRequest request);
    }
}
