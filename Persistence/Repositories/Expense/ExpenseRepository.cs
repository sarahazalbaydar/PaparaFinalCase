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
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ExpenseManagementDbContext context) : base(context)
        {

        }

        public bool SoftDelete(Expense expense)
        {
            expense.IsActive = false;
            expense.UpdatedDate = DateTime.Now;
            return true;
        }
    }
}
