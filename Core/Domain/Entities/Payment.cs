using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment: BaseEntity
    {
        public long ExpenseId { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Expense Expense { get; set; }
    }
}
