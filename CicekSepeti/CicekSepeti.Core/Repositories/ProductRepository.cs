using CicekSepeti.Core.IRepository;
using CicekSepeti.Domain.Context;
using CicekSepeti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Core.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ICicekSepetiDbContext context)
            : base(context)
        { }

        public Task<IEnumerable<Product>> GetAllWithMusicsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetWithMusicsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
