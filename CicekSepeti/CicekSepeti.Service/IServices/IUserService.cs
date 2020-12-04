﻿using CicekSepeti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Service.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();

    }
}
