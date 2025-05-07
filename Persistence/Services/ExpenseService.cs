using Application.Abstractions.Services;
using Application.DTOs;
using Application.Features.Expense.Commands.CreateExpense;
using Application.Features.Expense.Commands.UpdateExpense;
using Application.Repositories;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Persistence.Repositories;
using System.Security.Claims;

namespace Persistence.Services;
public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPaymentRepository _paymentRepository;

    public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper, IFileService fileService, IHttpContextAccessor httpContextAccessor, IPaymentRepository paymentRepository)
    {
        _expenseRepository = expenseRepository;
        _mapper = mapper;
        _fileService = fileService;
        _httpContextAccessor = httpContextAccessor;
        _paymentRepository = paymentRepository;
    }

    public async Task<Expense> CreateExpenseAsync(CreateExpenseDto dto)
    {
        var userId = _expenseRepository.GetByIdAsync(dto.UserId);
        if (userId == null)
            throw new ArgumentException("User not found.");

        var categoryId = _expenseRepository.GetByIdAsync(dto.CategoryId);
        if (categoryId == null)
            throw new ArgumentException("Category not found.");

        if (dto.Attachment == null || dto.Attachment.Length == 0)
            throw new ArgumentException("Attachment cannot be null or empty.");

        if (string.IsNullOrEmpty(dto.Attachment.FileName))
            throw new ArgumentException("Attachment file name cannot be null or empty.");

        var savedFilePath = await _fileService.SaveAttachmentAsync(dto.Attachment);

        var expense = new Expense
        {
            UserId = dto.UserId,
            CategoryId = dto.CategoryId,
            Description = dto.Description,
            Amount = dto.Amount,
            AttachmentFilePath = savedFilePath,
            ExpensedDate = dto.ExpensedDate,
            Status = ExpenseStatus.Pending,
            CreatedDate = DateTime.UtcNow,
            IsActive = true
        };

        await _expenseRepository.AddAsync(expense);
        await _expenseRepository.SaveChangesAsync();

        return expense;
    }

    public async Task<UpdateExpenseCommandResponse> UpdateExpenseStatusAsync(UpdateExpenseDto dto)
    {
        var userId = GetCurrentUserId();
        var expense = await GetExpenseOrThrowAsync(dto.Id);

        expense.Status = dto.Status;
        expense.DecisionUserId = long.Parse(userId);
        expense.DecisionDate = DateTime.Now;

        if (expense.Status == Domain.Enums.ExpenseStatus.Rejected)
            expense.RejectionReason = dto.RejectionReason;

        _expenseRepository.Update(expense);
        await _expenseRepository.SaveChangesAsync();

        var response = new UpdateExpenseCommandResponse { Success = true };

        if (expense.Status == Domain.Enums.ExpenseStatus.Approved)
        {
            await CreatePaymentAsync(expense);
            response.Message = "Expense approved and paymented";
        }
        else if (expense.Status == Domain.Enums.ExpenseStatus.Rejected)
        {
            response.Message = "Expense rejected";
        }
        else
        {
            response.Success = false;
            response.Message = "Error updating expense";
        }

        return response;
    }

    private string GetCurrentUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            throw new Exception("Please login");
        return userId;
    }

    private async Task<Expense> GetExpenseOrThrowAsync(long expenseId)
    {
        var expense = await _expenseRepository.GetByIdAsync(expenseId);
        if (expense == null)
            throw new Exception("Expense not found");
        return expense;
    }

    private async Task CreatePaymentAsync(Expense expense)
    {
        var payment = new Payment
        {
            ExpenseId = expense.Id,
            PaidAmount = expense.Amount,
            PaymentDate = DateTime.Now,
            IsActive = true
        };

        await _paymentRepository.AddAsync(payment);
        await _paymentRepository.SaveChangesAsync();
    }
}

