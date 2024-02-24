using DomainDrivenDesign.Application.Features.Categories.CreateCategory;
using DomainDrivenDesign.Application.Features.Categories.GetAllCategories;
using DomainDrivenDesign.Application.Features.Orders.CreateOrder;
using DomainDrivenDesign.Application.Features.Orders.GetAllOrders;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator mediator;

    public CategoriesController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellation)
    {
        await mediator.Send(request, cancellation);
        return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCategoriesQuery request, CancellationToken cancellation)
    {

        return Ok(await mediator.Send(request, cancellation));
    }
}
