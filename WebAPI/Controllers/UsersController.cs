using Application.Consts;
using Application.Features.User.Commands.CreateUser;
using Application.Features.User.Commands.DeleteUser;
using Application.Features.User.Commands.UpdateUser;
using Application.Features.User.Queries.GetAllUsers;
using Application.Features.User.Queries.GetUserById;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpGet]
        public async Task<ApiResponse<List<GetAllUsersQueryResponse>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQueryRequest());
            return result;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpGet("{id}")]
        public async Task<ApiResponse<GetUserByIdQueryResponse>> GetById(long id)
        {
            var result = await _mediator.Send(new GetUserByIdQueryRequest { Id = id });
            return result;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpPost]
        public async Task<CreateUserCommandResponse> Register([FromBody] CreateUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [Authorize(Roles = RoleConstants.Both)]
        [HttpPut("ChangePassword")]
        public async Task<ApiResponse> ChangePassword([FromBody] ChangePasswordCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteUserCommandRequest { Id = id });
            return result;
            
        }
    }
}
