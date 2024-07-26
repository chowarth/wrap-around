using WrapAround.Domain.Sessions;

namespace WrapAround.Application.Common.Abstractions.Persistence;

public interface ISessionRepository
{
    Task<IEnumerable<Session>> GetByStudentIdAsync(string studentId, CancellationToken cancellationToken = default);
}
