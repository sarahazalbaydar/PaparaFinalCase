using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategory.Queries.GetAllExpenseCategories
{
    public class GetAllExpenseCategoriesQueryHandler:IRequestHandler<GetAllExpenseCategoriesQueryRequest, ApiResponse<List<GetAllExpenseCategoriesQueryResponse>>>
    {

        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IMapper _mapper;

        public GetAllExpenseCategoriesQueryHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<GetAllExpenseCategoriesQueryResponse>>> Handle(GetAllExpenseCategoriesQueryRequest request, CancellationToken cancellationToken)
        {

            var expenseCategories = _expenseCategoryRepository.GetAll(false);

            var response = expenseCategories.Select(x => new GetAllExpenseCategoriesQueryResponse
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CreatedDate = x.CreatedDate
            }).ToList();

            var mapped = _mapper.Map<List<GetAllExpenseCategoriesQueryResponse>>(expenseCategories);
            return new ApiResponse<List<GetAllExpenseCategoriesQueryResponse>>(mapped);
        }
    }
}
