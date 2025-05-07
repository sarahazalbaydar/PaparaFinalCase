using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Commands.DeleteExpense
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommandRequest, ApiResponse>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public DeleteExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(DeleteExpenseCommandRequest request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetByIdAsync(request.Id);
            if (expense == null)
                return new ApiResponse("Expense not found");
            else if (!expense.IsActive)
                return new ApiResponse("This expense is already inactive");

            var isDeleted = _expenseRepository.SoftDelete(expense);
            if (!isDeleted)
                return new ApiResponse("Failed to delete expense");

            await _expenseRepository.SaveChangesAsync();
            return new ApiResponse();
        }

    }
}
