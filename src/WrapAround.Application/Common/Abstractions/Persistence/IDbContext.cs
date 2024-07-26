using Microsoft.EntityFrameworkCore;
using WrapAround.Domain.Common.Models;

namespace WrapAround.Application.Common.Abstractions.Persistence;

public interface IDbContext
{
    /// <summary>
    /// Gets the database set for <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <returns>The database set for the specified entity type.</returns>
    DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity;
}
