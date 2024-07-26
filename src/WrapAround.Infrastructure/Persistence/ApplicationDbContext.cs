using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WrapAround.Application.Common.Abstractions.Persistence;
using WrapAround.Domain.Common.Models;

namespace WrapAround.Infrastructure.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<User>(options), IDbContext
{
    /// <inheritdoc/>
    public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
    {
        return base.Set<TEntity>();
    }
}
