using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Orders;

public sealed class Order:Entity
{
    private Order(Guid id) : base(id) { }
    public Order(Guid id,string orderNumber, DateTime createdDate, OrderStatus status ):base(id)
    {
        OrderNumber = orderNumber;
        CreatedDate = createdDate;
        Status = status;

    }

    public string OrderNumber { get; private set; }
    public DateTime CreatedDate { get;private set; }
    public OrderStatus Status { get; private set; }
    public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();
    public void CreateOrder(List<CreateOrderDto> createOrderDtos)
    {
       foreach(CreateOrderDto dto in createOrderDtos)
        {
            if (dto.Quantity < 1) throw new ArgumentException("Şipariş edilen ürün miktarı 0dan büyük olmalıdır.");
            OrderLine orderLine = new(Guid.NewGuid(),Id,dto.ProductId,dto.Quantity,new(dto.Amount,Currency.FromCode(dto.Currency)));
            OrderLines.Add(orderLine);
        }
    }
    public void RemoveOrderLine(Guid orderLineId)
    {
        OrderLine orderline = OrderLines.FirstOrDefault(o=>o.Id==orderLineId);
        if (orderline == null) throw new ArgumentException("Silmek istediğiniz sipariş kalemi bulunamadı.");
        OrderLines.Remove(orderline);
    }
}
