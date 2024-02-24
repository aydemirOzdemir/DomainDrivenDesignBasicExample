using DomainDrivenDesign.Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(List<CreateOrderDto> createOrderDtos) :IRequest;
