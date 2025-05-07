using Application.Abstractions.Services;
using Application.Consts;
using Application.Features.Expense.Commands.CreateExpense;
using Application.Features.Expense.Commands.DeleteExpense;
using Application.Features.Expense.Commands.UpdateExpense;
using Application.Features.Expense.Queries.GetAllExpenses;
using Application.Features.Expense.Queries.GetExpenseById;
using Application.Features.ExpenseCategory.Queries.GetExpenseCategoryById;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {

        private readonly ExpenseManagementDbContext _context;

        private readonly IFileService _fileService;

        private readonly IMediator _mediator;

        public ExpensesController(ExpenseManagementDbContext context, IFileService fileService, IMediator mediator)
        {
            _context = context;
            _fileService = fileService;
            _mediator = mediator;
        }

        [Authorize(Roles = RoleConstants.Both)]
        [HttpGet]
        public async Task<ApiResponse<List<GetAllExpensesQueryResponse>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllExpensesQueryRequest());
            return result;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpGet("{id}")]
        public async Task<ApiResponse<GetExpenseByIdQueryResponse>> GetById(long id)
        {
            var response = await _mediator.Send(new GetExpenseByIdQueryRequest { Id = id });
            return response;
        }

        [Authorize(Roles = RoleConstants.Both)]
        [HttpPost]
        public async Task<ApiResponse<CreateExpenseCommandResponse>> Post([FromForm] CreateExpenseCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpPut]
        public async Task<UpdateExpenseCommandResponse> Put([FromBody] UpdateExpenseCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(long id)
        {
            var response = await _mediator.Send(new DeleteExpenseCommandRequest { Id = id });

            return response;
        }

    }
}
