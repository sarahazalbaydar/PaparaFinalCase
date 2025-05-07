using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Queries.GetAllExpenses
{
    public class GetAllExpensesQueryResponse
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string AttachmentFilePath { get; set; }
        public ExpenseStatus Status { get; set; }
        public DateTime ExpensedDate { get; set; }
        public long? DecisionUserId { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string? RejectionReason { get; set; }

    }
}
