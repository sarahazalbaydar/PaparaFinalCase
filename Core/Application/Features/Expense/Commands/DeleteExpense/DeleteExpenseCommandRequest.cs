using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Commands.DeleteExpense
{
    public class DeleteExpenseCommandRequest:IRequest<ApiResponse>
    {
        public long Id { get; set; }

    }
}
