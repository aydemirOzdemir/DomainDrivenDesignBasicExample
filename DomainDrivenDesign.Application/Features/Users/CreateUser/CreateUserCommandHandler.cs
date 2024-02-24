using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Domain.Users.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.CreateUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;

    public CreateUserCommandHandler(IUserRepository repository,IUnitOfWork unitOfWork,IMediator mediator)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mediator = mediator;
    }
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
       User user= await repository.CreateAsync(request.Name,request.Email,request.Password,request.Country,request.City,request.Street,request.PastalCode,request.FullAddress,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        await mediator.Publish(new UserDomainEvent(user));
    }
}
