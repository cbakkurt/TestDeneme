using CicekSepeti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Core.IRepository
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<Basket> GetBasketsByUserIdAndProductId(Guid productId, Guid userId);
        Task<IEnumerable<Basket>> GetBasketsByUserId(Guid userId);
    }
}
