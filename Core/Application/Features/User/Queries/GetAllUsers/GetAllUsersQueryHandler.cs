using Application.Features.ExpenseCategory.Queries.GetAllExpenseCategories;
using Application.Repositories;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQueryRequest, ApiResponse<List<GetAllUsersQueryResponse>>>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<GetAllUsersQueryResponse>>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll(false);

            var response = users.Select(x => new GetAllUsersQueryResponse
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                IBAN = x.IBAN,
                Role = x.Role

            }).ToList();

            var mapped = _mapper.Map<List<GetAllUsersQueryResponse>>(users);
            return new ApiResponse<List<GetAllUsersQueryResponse>>(mapped);
        }
    }
}
