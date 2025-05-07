using Application.Abstractions.Services;
using Application.DTOs;
using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler:IRequestHandler<CreateExpenseCommandRequest, ApiResponse<CreateExpenseCommandResponse>>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IExpenseService _expenseService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper, IExpenseService expenseService, IHttpContextAccessor httpContextAccessor)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _expenseService = expenseService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<CreateExpenseCommandResponse>> Handle(CreateExpenseCommandRequest request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userIdString = httpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdString) || !long.TryParse(userIdString, out var tokenUserId))
                return new ApiResponse<CreateExpenseCommandResponse>("Unauthorized access");

            if (request.UserId != tokenUserId)
                return new ApiResponse<CreateExpenseCommandResponse>("You are not authorized to perform this action");

            var dto = new CreateExpenseDto
            {
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Amount = request.Amount,
                Attachment = request.AttachmentFilePath,
                ExpensedDate = request.ExpensedDate
            };

            var response = await _expenseService.CreateExpenseAsync(dto);

            var mappedResponse = _mapper.Map<CreateExpenseCommandResponse>(response);
            return new ApiResponse<CreateExpenseCommandResponse>(mappedResponse);

        }

    }
}
