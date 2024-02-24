using DomainDrivenDesign.Application.Features.Orders.CreateOrder;
using DomainDrivenDesign.Application.Features.Orders.GetAllOrders;
using DomainDrivenDesign.Application.Features.Users.CreateUser;
using DomainDrivenDesign.Application.Features.Users.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator mediator;

    public OrdersController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellation)
    {
        await mediator.Send(request, cancellation);
        return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllOrderQuery request, CancellationToken cancellation)
    {

        return Ok(await mediator.Send(request, cancellation));
    }
}
