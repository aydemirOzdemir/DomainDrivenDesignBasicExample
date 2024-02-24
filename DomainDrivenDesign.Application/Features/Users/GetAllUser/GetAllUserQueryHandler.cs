using DomainDrivenDesign.Domain.Users;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.GetAllUser;

internal sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
{
    private readonly IUserRepository repository;
 

    public GetAllUserQueryHandler(IUserRepository repository)
    {
        this.repository = repository;
        
    }
    public async Task<IEnumerable<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync();
       
    }
}
