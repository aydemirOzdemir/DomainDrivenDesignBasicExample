using DomainDrivenDesign.Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Orders.GetAllOrders;

public sealed record GetAllOrderQuery():IRequest<IEnumerable<Order>>;
