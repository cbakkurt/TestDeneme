using CicekSepeti.Core.IUnitOfWork;
using CicekSepeti.Domain.Entities;
using CicekSepeti.Service.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _unitOfWork.ProductRepositories.GetAllAsync();
        }
    }
}
