﻿using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExpenseCategory:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
