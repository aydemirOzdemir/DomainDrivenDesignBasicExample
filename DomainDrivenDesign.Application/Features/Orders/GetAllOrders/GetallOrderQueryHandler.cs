using DomainDrivenDesign.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.GetAllOrders;

internal sealed class GetallOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository orderRepository;

    public GetallOrderQueryHandler(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }
    public async Task<IEnumerable<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        return await orderRepository.GetAllAsync(cancellationToken);

    }
}
