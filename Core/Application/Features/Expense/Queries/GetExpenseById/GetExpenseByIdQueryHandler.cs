using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Queries.GetExpenseById
{
    public class GetExpenseByIdQueryHandler:IRequestHandler<GetExpenseByIdQueryRequest, ApiResponse<GetExpenseByIdQueryResponse>>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public GetExpenseByIdQueryHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<GetExpenseByIdQueryResponse>> Handle(GetExpenseByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetByIdAsync(request.Id);
            if (expense == null)
            {
                return new ApiResponse<GetExpenseByIdQueryResponse>("Expense Not Found");
            }
            var mapped = _mapper.Map<GetExpenseByIdQueryResponse>(expense);
            return new ApiResponse<GetExpenseByIdQueryResponse>(mapped);
        }

    }
}
