using Application.Abstractions.Services;
using Application.DTOs;
using Application.Repositories;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Commands.UpdateExpense
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommandRequest, UpdateExpenseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseService _expenseService;

        public UpdateExpenseCommandHandler(IMapper mapper, IExpenseService expenseService)
        {
            _mapper = mapper;
            _expenseService = expenseService;
        }

        public async Task<UpdateExpenseCommandResponse> Handle(UpdateExpenseCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<UpdateExpenseDto>(request);
            return await _expenseService.UpdateExpenseStatusAsync(dto);
        }
    }
}
