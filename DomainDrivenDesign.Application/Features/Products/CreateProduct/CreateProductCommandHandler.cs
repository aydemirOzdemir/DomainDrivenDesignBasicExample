using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Products.CreateProduct;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository productRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository,IUnitOfWork unitOfWork)
    {
        this.productRepository = productRepository;
        this.unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await productRepository.CreateAsync(request.name,request.quantity,request.amount,request.currency,request.categoryId,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
