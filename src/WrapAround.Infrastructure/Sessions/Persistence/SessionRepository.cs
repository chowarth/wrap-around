﻿using Microsoft.EntityFrameworkCore;
using WrapAround.Application.Common.Persistence;
using WrapAround.Domain.Sessions;
using WrapAround.Infrastructure.Common.Persistence;

namespace WrapAround.Infrastructure.Sessions.Persistence;

public class SessionRepository : ISessionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SessionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Session>> GetByStudentIdAsync(string studentId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Session>()
            // TODO: Filter on student
            .ToArrayAsync(cancellationToken);
    }
}
