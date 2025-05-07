using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IExpenseCategoryRepository:IRepository<ExpenseCategory>
    {
        bool SoftDelete(ExpenseCategory expenseCategory);
    }
}
