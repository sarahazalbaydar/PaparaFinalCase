using Application.DTOs;
using Application.Features.Expense.Commands.CreateExpense;
using Application.Features.Expense.Commands.UpdateExpense;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services;

public interface IExpenseService
{
    Task<Expense> CreateExpenseAsync(CreateExpenseDto dto);
    Task<UpdateExpenseCommandResponse> UpdateExpenseStatusAsync(UpdateExpenseDto request);

}
