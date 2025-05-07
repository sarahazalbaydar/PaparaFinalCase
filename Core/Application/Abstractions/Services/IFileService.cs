using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<string> SaveAttachmentAsync(IFormFile file);
    }
}
