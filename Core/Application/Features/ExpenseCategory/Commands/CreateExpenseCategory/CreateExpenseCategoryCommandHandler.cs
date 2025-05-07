using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;


namespace Application.Features.ExpenseCategory.Commands.CreateExpenseCategory
{
    public class CreateExpenseCategoryCommandHandler:IRequestHandler<CreateExpenseCategoryCommandRequest, ApiResponse<CreateExpenseCategoryCommandResponse>>
    {

        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IMapper _mapper;

        public CreateExpenseCategoryCommandHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CreateExpenseCategoryCommandResponse>> Handle(CreateExpenseCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var existingExpenseCategory = await _expenseCategoryRepository.GetSingleAsync(x => x.Title == request.Title);
            if (existingExpenseCategory != null)
            {
                return new ApiResponse<CreateExpenseCategoryCommandResponse>("Expense Category Already Exists");
            }

            var mapped = _mapper.Map<Domain.Entities.ExpenseCategory>(request);

            var createdExpenseCategory = await _expenseCategoryRepository.AddAsync(mapped);

            await _expenseCategoryRepository.SaveChangesAsync();

            var mappedResponse = _mapper.Map<CreateExpenseCategoryCommandResponse>(createdExpenseCategory);
            return new ApiResponse<CreateExpenseCategoryCommandResponse>(mappedResponse);
        }
    }

}
