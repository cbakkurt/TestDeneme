using CicekSepeti.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Domain.Context
{
    public class CicekSepetiDbContext : DbContext, ICicekSepetiDbContext
    {
        public CicekSepetiDbContext(DbContextOptions<CicekSepetiDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public void Dispose()
        {
            base.Dispose();
        }

        public async Task<int>SaveChangesAsync()
        {
           return await base.SaveChangesAsync();
        }

        //public DbSet<T> EntitySet<T>() where T : class
        //{
        //    return Set<T>();
        //}
        DbSet<TEntity> ICicekSepetiDbContext.Set<TEntity>() where TEntity : class
        {
            try
            {
                return Set<TEntity>();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(new User("cihan", "abc123"));
        //    modelBuilder.Entity<User>().HasData(new User("bulut", "123abc123"));

        //    modelBuilder.Entity<Product>().HasData(new Product("laptop", 123, 100));
        //    modelBuilder.Entity<Product>().HasData(new Product("telefon", 123, 100));

        //    //base.OnModelCreating(modelBuilder);
        //}
    }
}
