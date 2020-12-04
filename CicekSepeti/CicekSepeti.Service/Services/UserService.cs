using CicekSepeti.Core.IUnitOfWork;
using CicekSepeti.Domain.Entities;
using CicekSepeti.Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.UserRepositories.GetAllAsync();
        }
    }
}
