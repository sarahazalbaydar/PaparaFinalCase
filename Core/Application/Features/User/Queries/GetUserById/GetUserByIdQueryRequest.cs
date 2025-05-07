using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetUserById
{
    public class GetUserByIdQueryRequest : IRequest<ApiResponse<GetUserByIdQueryResponse>>
    {
        public long Id { get; set; }
    }
}
