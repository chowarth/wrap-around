using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrapAround.Domain.Sessions;

namespace WrapAround.Infrastructure.Sessions.Persistence;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(session => session.Id);
        builder.Property(session => session.Id)
            .HasConversion(
                id => id.Value,
                value => SessionId.Create(value)
            );
    }
}
