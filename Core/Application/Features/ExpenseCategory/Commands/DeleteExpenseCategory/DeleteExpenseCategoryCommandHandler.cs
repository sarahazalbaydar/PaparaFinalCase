using Application.Features.ExpenseCategory.Commands.UpdateExpenseCategory;
using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategory.Commands.DeleteExpenseCategory
{

    public class DeleteExpenseCategoryCommandHandler : IRequestHandler<DeleteExpenseCategoryCommandRequest, ApiResponse>
    {

        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IMapper _mapper;

        public DeleteExpenseCategoryCommandHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(DeleteExpenseCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var expenseCategory = await _expenseCategoryRepository.GetByIdAsync(request.Id);
            if (expenseCategory == null)
                return new ApiResponse("Expense category not found");
            if (!expenseCategory.IsActive)
                return new ApiResponse("Expense category is not active");

            var isDeleted = _expenseCategoryRepository.SoftDelete(expenseCategory);
            if (!isDeleted)
                return new ApiResponse("Failed to delete expense category");

            await _expenseCategoryRepository.SaveChangesAsync();
            return new ApiResponse();
        }

    }
}
