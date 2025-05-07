using Application.Responses;
using MediatR;

namespace Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryRequest: IRequest<ApiResponse<List<GetAllUsersQueryResponse>>>
    {
    }
}
