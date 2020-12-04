using CicekSepeti.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Core.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithMusicsAsync();
        Task<Product> GetWithMusicsByIdAsync(int id);
    }
}
