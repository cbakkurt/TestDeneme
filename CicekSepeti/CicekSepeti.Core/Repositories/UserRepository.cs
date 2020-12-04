using CicekSepeti.Core.IRepository;
using CicekSepeti.Domain.Context;
using CicekSepeti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Core.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ICicekSepetiDbContext context)
           : base(context)
        { }
    }
}
