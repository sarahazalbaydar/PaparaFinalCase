using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Queries.GetAllExpenses
{
    public class GetAllExpensesQueryRequest:IRequest<ApiResponse<List<GetAllExpensesQueryResponse>>>
    {
    }
}
