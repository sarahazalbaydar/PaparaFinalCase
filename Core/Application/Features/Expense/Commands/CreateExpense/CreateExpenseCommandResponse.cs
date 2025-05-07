using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Commands.CreateExpense
{
    public class CreateExpenseCommandResponse
    {
        public long UserId { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string AttachmentFilePath { get; set; }
        public ExpenseStatus Status { get; set; } = ExpenseStatus.Pending;
        public DateTime ExpensedDate { get; set; }

    }
}
