using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Orders.Events;

public sealed class SendOrderEmail : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        //orderdomaineventin içinde id var işlemlerini yapabilirsin artık burada mail göndermek için
        return Task.CompletedTask;
    }
}
