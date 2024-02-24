using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure;

public sealed class ApplicationDbContext:DbContext,IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt):base(opt)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<User> Users { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region User
        modelBuilder.Entity<User>().Property(p => p.Name).HasConversion(name=>name.Value,value=>new(value));
        modelBuilder.Entity<User>().Property(p => p.Email).HasConversion(email=>email.Value,value=>new(value));
        modelBuilder.Entity<User>().Property(p => p.Password).HasConversion(password=>password.Value,value=>new(value));
        modelBuilder.Entity<User>().OwnsOne(p => p.Address);
        #endregion
        #region Category
        modelBuilder.Entity<Category>().Property(p => p.Name).HasConversion(name => name.Value, value => new(value));
        #endregion
        #region Order
        #endregion
        #region Product
        modelBuilder.Entity<Product>().Property(p => p.Name).HasConversion(name => name.Value, value => new(value));
        modelBuilder.Entity<Product>().OwnsOne(p => p.Price, pricebuilder =>
        {
            pricebuilder.Property(p => p.Currency).HasConversion(currency=>currency.Code,code=>Currency.FromCode(code));
            pricebuilder.Property(p=>p.Amount).HasColumnType("money");
        });
        modelBuilder.Entity<OrderLine>().OwnsOne(p => p.Price, pricebuilder =>
        {
            pricebuilder.Property(p => p.Currency).HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            pricebuilder.Property(p => p.Amount).HasColumnType("money");
        });
        #endregion




        base.OnModelCreating(modelBuilder);
    }

}
