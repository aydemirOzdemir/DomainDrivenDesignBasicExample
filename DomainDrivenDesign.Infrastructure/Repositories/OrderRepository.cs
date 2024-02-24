using DomainDrivenDesign.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Repositories;

public sealed class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext context;

    public OrderRepository(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
    {
        Order order = new Order(Guid.NewGuid(), "1", DateTime.Now, OrderStatus.AwaitingApproval);
        order.CreateOrder(createOrderDtos);
        await context.Orders.AddAsync(order,cancellationToken); 
        return order;

    }

    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
       return await context.Orders.Include(p=>p.OrderLines).ThenInclude(p=>p.Product).ToListAsync(cancellationToken);
    }
}
