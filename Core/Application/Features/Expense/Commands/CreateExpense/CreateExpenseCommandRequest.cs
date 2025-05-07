using Application.Responses;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.Expense.Commands.CreateExpense
{
    public class CreateExpenseCommandRequest:IRequest<ApiResponse<CreateExpenseCommandResponse>>
    {
        public long UserId { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public IFormFile AttachmentFilePath { get; set; }
        public DateTime ExpensedDate { get; set; }

    }
}
