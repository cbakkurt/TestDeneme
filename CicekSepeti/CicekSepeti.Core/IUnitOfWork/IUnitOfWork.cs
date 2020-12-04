using CicekSepeti.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Core.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBasketRepository BasketRepositories { get; }
        IProductRepository ProductRepositories { get; }
        IUserRepository UserRepositories { get; }
        Task<int> CommitAsync();
    }
}
