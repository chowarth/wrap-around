using Microsoft.EntityFrameworkCore;
using WrapAround.Application.Common.Abstractions.Messaging;
using WrapAround.Application.Common.Abstractions.Persistence;
using WrapAround.Domain.Sessions;

namespace WrapAround.Application.Sessions.GetSessionsForStudentId;

public record GetSessionsForStudentIdQuery(Guid StudentId) : IQuery<List<Session>>;

public class GetSessionsForStudentIdQueryHandler : IQueryHandler<GetSessionsForStudentIdQuery, List<Session>>
{
    private readonly IDbContext _dbContext;

    public GetSessionsForStudentIdQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Session>> Handle(GetSessionsForStudentIdQuery request, CancellationToken cancellationToken)
    {
        var sessions = await _dbContext.Set<Session>()
            .Where(x => x.Attendees.Contains(request.StudentId.ToString()))
            // TODO: Project to response DTO
                // Should not include Attendees
            // TODO: Create Student entity
                // What domain should this be under, School?
            .ToListAsync(cancellationToken);

        return sessions;
    }
}
