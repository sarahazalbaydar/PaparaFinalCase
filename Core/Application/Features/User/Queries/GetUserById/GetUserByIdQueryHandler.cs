using Application.Features.ExpenseCategory.Queries.GetExpenseCategoryById;
using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetUserById
{
    public class GetUserByIdQueryHandler:IRequestHandler<GetUserByIdQueryRequest, ApiResponse<GetUserByIdQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<GetUserByIdQueryResponse>> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, false);
            if (user == null)
            {
                return new ApiResponse<GetUserByIdQueryResponse>("User Not Found");
            }
            var response = _mapper.Map<GetUserByIdQueryResponse>(user);
            return new ApiResponse<GetUserByIdQueryResponse>(response);

        }
    }
}
