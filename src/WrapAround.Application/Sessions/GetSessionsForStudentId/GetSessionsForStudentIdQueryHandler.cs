using WrapAround.Application.Common.Messaging;
using WrapAround.Application.Common.Persistence;
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
            // Should not include Students
            // Return ErrorOr

        return sessions;
    }
}
