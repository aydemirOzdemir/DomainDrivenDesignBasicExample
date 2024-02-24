using DomainDrivenDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext context;

    public UserRepository(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<User> CreateAsync(string name, string email, string password, string country, string city, string street, string pastalCode, string fullAddress, CancellationToken cancellationToken = default)
    {
        User user = User.CreateUser(name, password, email, country, pastalCode, fullAddress, city, street);
        await context.Users.AddAsync(user,cancellationToken);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Users.ToListAsync(cancellationToken);
    }
}
