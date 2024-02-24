using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Orders.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.CreateOrder;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IOrderRepository orderRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;

    public CreateOrderCommandHandler(IOrderRepository orderRepository,IUnitOfWork unitOfWork,IMediator mediator)
    {
        this.orderRepository = orderRepository;
        this.unitOfWork = unitOfWork;
        this.mediator = mediator;
    }
    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
       Order order= await orderRepository.CreateAsync(request.createOrderDtos,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        await mediator.Publish(new OrderDomainEvent(order));

    }
}
