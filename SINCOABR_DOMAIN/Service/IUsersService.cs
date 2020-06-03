﻿using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_DOMAIN.Service
{
    public interface IUsersService
    {
        Task<Users> createUser(Users model);
        Task<UsersDOT> getUser(string email);
        Task<UsersDOT> updateUser(UsersDOT model);
    }
}
