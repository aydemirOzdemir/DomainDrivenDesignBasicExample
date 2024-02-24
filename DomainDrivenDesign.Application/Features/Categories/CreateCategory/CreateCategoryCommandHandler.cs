using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository categoryRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
    {
        this.categoryRepository = categoryRepository;
        this.unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryRepository.CreateAsync(request.name,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
