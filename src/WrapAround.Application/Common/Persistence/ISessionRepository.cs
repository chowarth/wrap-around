using WrapAround.Domain.Sessions;

namespace WrapAround.Application.Common.Persistence;

public interface ISessionRepository
{
    Task<IEnumerable<Session>> GetByStudentIdAsync(string studentId, CancellationToken cancellationToken = default);
}
