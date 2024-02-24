using DomainDrivenDesign.Application.Features.Orders.CreateOrder;
using DomainDrivenDesign.Application.Features.Orders.GetAllOrders;
using DomainDrivenDesign.Application.Features.Products.CreateProduct;
using DomainDrivenDesign.Application.Features.Products.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellation)
    {
        await mediator.Send(request, cancellation);
        return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllProductsQuery request, CancellationToken cancellation)
    {

        return Ok(await mediator.Send(request, cancellation));
    }
}
