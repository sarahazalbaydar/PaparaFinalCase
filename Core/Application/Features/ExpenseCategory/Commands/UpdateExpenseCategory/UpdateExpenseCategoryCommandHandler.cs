using Application.Repositories;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.ExpenseCategory.Commands.UpdateExpenseCategory
{
    public class UpdateExpenseCategoryCommandHandler:IRequestHandler<UpdateExpenseCategoryCommandRequest, ApiResponse>
    {

        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateExpenseCategoryCommandHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateExpenseCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var expenseCategory = await _expenseCategoryRepository.GetByIdAsync(request.Id);
            if (expenseCategory == null)
                return new ApiResponse("Expense category not found");

            expenseCategory.Title = request.Title;
            expenseCategory.Description = request.Description;
            expenseCategory.IsActive = request.IsActive;

            var isUpdated = _expenseCategoryRepository.Update(expenseCategory);

            if (!isUpdated)
                return new ApiResponse("Failed to update expense category");

            await _expenseCategoryRepository.SaveChangesAsync();

            return new ApiResponse();
        }
    }

}
