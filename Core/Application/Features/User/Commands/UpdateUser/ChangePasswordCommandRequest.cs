using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.UpdateUser;

public class ChangePasswordCommandRequest : IRequest<ApiResponse>
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
