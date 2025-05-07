using Application.Features.ExpenseCategory.Queries.GetAllExpenseCategories;
using Application.Repositories;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Queries.GetAllExpenses
{
    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQueryRequest, ApiResponse<List<GetAllExpensesQueryResponse>>>
    {

        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public GetAllExpensesQueryHandler(IExpenseRepository expenseRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ApiResponse<List<GetAllExpensesQueryResponse>>> Handle(GetAllExpensesQueryRequest request, CancellationToken cancellationToken)
        {

            var role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            IQueryable<Domain.Entities.Expense> expensesQuery;

            if (role == "Admin")
                expensesQuery = _expenseRepository.GetAll();
            else if (role == "Employee" && long.TryParse(userId, out var id))
                expensesQuery = _expenseRepository.GetAll().Where(e => e.UserId == id);
            else
                return new ApiResponse<List<GetAllExpensesQueryResponse>>("Unauthorized or invalid user");

            var expensesList = await expensesQuery.ToListAsync(cancellationToken);
            var mapped = _mapper.Map<List<GetAllExpensesQueryResponse>>(expensesList);
            return new ApiResponse<List<GetAllExpensesQueryResponse>>(mapped);
        }

    }
}
