using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandRequest:IRequest<ApiResponse>
    {
        public long Id { get; set; }
    }
}
