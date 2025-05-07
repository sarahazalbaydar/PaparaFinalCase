using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateExpenseDto
    {
        public long Id { get; set; }
        public ExpenseStatus Status { get; set; }
        public string? RejectionReason { get; set; }
    }
}
