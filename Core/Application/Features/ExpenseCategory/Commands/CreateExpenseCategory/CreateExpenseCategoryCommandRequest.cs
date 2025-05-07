using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategory.Commands.CreateExpenseCategory
{
    public class CreateExpenseCategoryCommandRequest:IRequest<ApiResponse<CreateExpenseCategoryCommandResponse>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

}
