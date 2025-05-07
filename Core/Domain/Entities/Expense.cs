using Domain.Entities.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Expense:BaseEntity
    {
        public long UserId { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string AttachmentFilePath { get; set; }
        public ExpenseStatus Status { get; set; } = ExpenseStatus.Pending;
        public DateTime ExpensedDate { get; set; }
        public long? DecisionUserId { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string? RejectionReason { get; set; }

        public virtual User User { get; set; }
        public virtual ExpenseCategory Category { get; set; }
        public virtual Payment Payment { get; set; }

    }
}
