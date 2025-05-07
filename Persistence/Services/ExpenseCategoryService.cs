using Application.Abstractions.Services;
using Application.Features.ExpenseCategory.Commands.UpdateExpenseCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        public Task AddExpenseCategoryAsync(string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExpenseCategoryAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExpenseCategoryAsync(long id, string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExpenseCategoryAsync(UpdateExpenseCategoryCommandRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
