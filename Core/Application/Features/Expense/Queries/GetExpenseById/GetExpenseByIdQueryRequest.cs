using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Queries.GetExpenseById
{
    public class GetExpenseByIdQueryRequest:IRequest<ApiResponse<GetExpenseByIdQueryResponse>>
    {
        public long Id { get; set; }
    }
}
