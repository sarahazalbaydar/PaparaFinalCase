using Application.Features.ExpenseCategory.Queries.GetAllExpenseCategories;
using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategory.Queries.GetExpenseCategoryById
{
    public class GetExpenseCategoryByIdQueryHandler : IRequestHandler<GetExpenseCategoryByIdQueryRequest, ApiResponse<GetExpenseCategoryByIdQueryResponse>>
    {

        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IMapper _mapper;

        public GetExpenseCategoryByIdQueryHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<GetExpenseCategoryByIdQueryResponse>> Handle(GetExpenseCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {

            var expenseCategory = await _expenseCategoryRepository.GetByIdAsync(request.Id);

            if (expenseCategory == null)
            {
                return new ApiResponse<GetExpenseCategoryByIdQueryResponse>("Expense Category Not Found");
            }

            var mapped = _mapper.Map<GetExpenseCategoryByIdQueryResponse>(expenseCategory);
            return new ApiResponse<GetExpenseCategoryByIdQueryResponse>(mapped);

        }

    }
}
