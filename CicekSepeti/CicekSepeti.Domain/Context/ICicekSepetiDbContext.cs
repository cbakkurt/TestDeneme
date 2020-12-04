using CicekSepeti.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CicekSepeti.Domain.Context
{
    public interface ICicekSepetiDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<Product> Products { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
