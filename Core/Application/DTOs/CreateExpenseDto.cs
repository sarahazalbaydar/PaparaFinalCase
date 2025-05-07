using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateExpenseDto
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpensedDate { get; set; }

        [Required]
        public IFormFile Attachment { get; set; }

    }
}
