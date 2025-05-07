using Application.Abstractions.Services;
using Application.DTOs;
using Application.Features.Expense.Commands.CreateExpense;
using Application.Features.Expense.Commands.UpdateExpense;
using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {

        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IAuthService authService, IMapper mapper, IUserRepository userRepository)
        {
            _authService = authService;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = new RegisterDto
            {
                UserName = request.UserName,
                Password = request.Password,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                IBAN = request.IBAN,
                Role = request.Role
            };

            await _authService.RegisterAsync(dto);

            var response = new CreateUserCommandResponse { Success = true };

            var user = _userRepository.GetSingleAsync(x => x.UserName == request.UserName);
            if(user == null)
            {
                response.Success = false;
                response.Message = "Registration failed.";
            }
            response.Message = "Registration successful.";

            return response;

        }
    }
}
