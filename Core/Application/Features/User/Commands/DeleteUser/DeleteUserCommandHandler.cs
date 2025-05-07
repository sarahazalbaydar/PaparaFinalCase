using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler:IRequestHandler<DeleteUserCommandRequest, ApiResponse>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                return new ApiResponse("User not found");
            if (!user.IsActive)
                return new ApiResponse("User is not active");

            var isDeleted = _userRepository.SoftDelete(user);
            if (!isDeleted)
                return new ApiResponse("Failed to delete user");


            await _userRepository.SaveChangesAsync();
            return new ApiResponse();
        }
    }
}
