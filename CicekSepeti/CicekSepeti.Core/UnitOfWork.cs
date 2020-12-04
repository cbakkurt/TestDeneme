﻿using CicekSepeti.Core.IRepository;
using CicekSepeti.Core.Repositories;
using CicekSepeti.Domain.Context;
using System.Threading.Tasks;

namespace CicekSepeti.Core
{
    public class UnitOfWork : CicekSepeti.Core.IUnitOfWork.IUnitOfWork
    {
        private readonly ICicekSepetiDbContext _context;
        private BasketRepository _basketRepository;
        private ProductRepository _productRepository;
        private UserRepository _userRepository;

        public UnitOfWork(ICicekSepetiDbContext context)
        {
            this._context = context;
        }

        public IBasketRepository BasketRepositories => _basketRepository = _basketRepository ?? new BasketRepository(_context);

        public IProductRepository ProductRepositories => _productRepository = _productRepository ?? new ProductRepository(_context);
        public IUserRepository UserRepositories => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
