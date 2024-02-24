namespace DomainDrivenDesign.Domain.Orders;

public enum OrderStatus
{
    AwaitingApproval=1,
    BeingPrepared=2,
    InTransit=3,
    Delivered=4
}