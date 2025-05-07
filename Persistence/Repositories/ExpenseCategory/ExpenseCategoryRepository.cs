using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ExpenseCategoryRepository : Repository<ExpenseCategory>, IExpenseCategoryRepository
    {
        public ExpenseCategoryRepository(ExpenseManagementDbContext context) : base(context)
        {

        }

        public bool SoftDelete(ExpenseCategory expenseCategory)
        {
            expenseCategory.IsActive = false;
            expenseCategory.UpdatedDate = DateTime.Now;
            return true;
        }
    }
}
