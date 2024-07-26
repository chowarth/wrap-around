using WrapAround.Application.Common.Abstractions.Messaging;
using WrapAround.Application.Common.Abstractions.Persistence;
using WrapAround.Domain.Sessions;

namespace WrapAround.Application.Sessions.GetSessionsForStudentId;

public record GetSessionsForStudentIdQuery(Guid StudentId) : IQuery<IEnumerable<Session>>;

public class GetSessionsForStudentIdQueryHandler : IQueryHandler<GetSessionsForStudentIdQuery, IEnumerable<Session>>
{
    private readonly ISessionRepository _sessionRepository;

    public GetSessionsForStudentIdQueryHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<IEnumerable<Session>> Handle(GetSessionsForStudentIdQuery request, CancellationToken cancellationToken)
    {
        var sessions = await _sessionRepository
            .GetByStudentIdAsync(request.StudentId.ToString(), cancellationToken);
        // TODO: Map to response DTO
            // Should this be done here or in the repository?
            // Should not include Attendees
        // TODO: Create Student entity
            // What domain should this be under, School?

        return sessions;
    }
}
