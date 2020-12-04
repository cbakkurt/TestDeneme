using CicekSepeti.Core.IRepository;
using CicekSepeti.Domain.Context;
using CicekSepeti.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepeti.Core.Repositories
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(ICicekSepetiDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Basket>> GetBasketsByUserId(Guid userId)
        {
            return await _context.Baskets.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Basket> GetBasketsByUserIdAndProductId(Guid productId, Guid userId)
        {
            return await _context.Baskets.FirstOrDefaultAsync(x => x.ProductId == productId && x.UserId == userId);
        }

    }
}
