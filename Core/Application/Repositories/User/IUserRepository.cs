﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        bool SoftDelete(User user);
    }
}
