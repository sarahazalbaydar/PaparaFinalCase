using Application.Consts;
using Application.Features.ExpenseCategory.Commands.CreateExpenseCategory;
using Application.Features.ExpenseCategory.Commands.DeleteExpenseCategory;
using Application.Features.ExpenseCategory.Commands.UpdateExpenseCategory;
using Application.Features.ExpenseCategory.Queries.GetAllExpenseCategories;
using Application.Features.ExpenseCategory.Queries.GetExpenseCategoryById;
using Application.Repositories;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseCategoriesController : ControllerBase
    {

        private readonly IMediator _mediator;
        readonly private IExpenseCategoryRepository _expenseCategoryRepository;

        public ExpenseCategoriesController(IMediator mediator, IExpenseCategoryRepository expenseCategoryRepository)
        {
            _mediator = mediator;
            _expenseCategoryRepository = expenseCategoryRepository;
        }

        [Authorize(Roles = RoleConstants.Both)]
        [HttpGet("GetAll")]
        public async Task<ApiResponse<List<GetAllExpenseCategoriesQueryResponse>>> GetAll()
        {
            var response = await _mediator.Send(new GetAllExpenseCategoriesQueryRequest());
            return response;
        }

        [Authorize(Roles = RoleConstants.Both)]
        [HttpGet("{id}")]
        public async Task<ApiResponse<GetExpenseCategoryByIdQueryResponse>> GetById(long id)
        {
            var response = await _mediator.Send(new GetExpenseCategoryByIdQueryRequest { Id = id });
            return response;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpPost]
        public async Task<ApiResponse<CreateExpenseCategoryCommandResponse>> Post([FromBody] CreateExpenseCategoryCommandRequest createExpenseCategoryCommandRequest)
        {
            var response = await _mediator.Send(createExpenseCategoryCommandRequest);
            return response;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpPut]
        public async Task<ApiResponse> Put([FromBody] UpdateExpenseCategoryCommandRequest updateExpenseCategoryCommandRequest)
        {
            var response = await _mediator.Send(updateExpenseCategoryCommandRequest);
            return response;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete([FromRoute] long id)
        {
            var response = await _mediator.Send(new DeleteExpenseCategoryCommandRequest { Id = id});
            return response;
        }
    }
}
