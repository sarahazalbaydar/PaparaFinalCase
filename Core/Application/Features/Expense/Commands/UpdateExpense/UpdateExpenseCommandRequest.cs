using Application.Responses;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Commands.UpdateExpense
{
    public class UpdateExpenseCommandRequest:IRequest<UpdateExpenseCommandResponse>
    {
        public long Id { get; set; }
        public ExpenseStatus Status { get; set; }
        public string? RejectionReason { get; set; }
    }
}
