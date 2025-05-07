using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategory.Queries.GetExpenseCategoryById
{
    public class GetExpenseCategoryByIdQueryRequest:IRequest<ApiResponse<GetExpenseCategoryByIdQueryResponse>>
    {
        public long Id { get; set; }

    }
}
