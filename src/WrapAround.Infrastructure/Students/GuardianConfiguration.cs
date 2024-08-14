using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrapAround.Domain.Students;

namespace WrapAround.Infrastructure.Students;

internal sealed class GuardianConfiguration : IEntityTypeConfiguration<Guardian>
{
    public void Configure(EntityTypeBuilder<Guardian> builder)
    {
        builder.HasKey(guardian => guardian.Id);
        builder.Property(guardian => guardian.Id)
            .HasConversion(
                id => id.Value,
                value => GuardianId.Create(value)
            );

        builder.Property(guardian => guardian.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(guardian => guardian.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(guardian => guardian.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasIndex(guardian => guardian.Email)
            .IsUnique();

        builder.OwnsOne(guardian => guardian.Address, addressBuilder =>
        {
            addressBuilder.Property(address => address.StreetLine1)
                .HasMaxLength(50);

            addressBuilder.Property(address => address.StreetLine2)
                .HasMaxLength(50);

            addressBuilder.Property(address => address.StreetLine3)
                .HasMaxLength(50);

            addressBuilder.Property(address => address.TownOrCity)
                .HasMaxLength(50);

            addressBuilder.Property(address => address.County)
                .HasMaxLength(50);

            addressBuilder.Property(address => address.PostCode)
                .HasMaxLength(15);

            addressBuilder.Property(address => address.Country)
                .HasMaxLength(50);
        });

        builder.OwnsMany(guardian => guardian.PhoneNumbers, phoneNumberBuilder =>
        {
            phoneNumberBuilder.Property(phoneNumber => phoneNumber.CountryCode)
                .HasMaxLength(3)
                .IsRequired();

            phoneNumberBuilder.Property(phoneNumber => phoneNumber.Value)
                .HasMaxLength(15)
                .IsRequired();
        });

        //builder.HasMany<Student>()
        //    .WithOne()
        //    .HasForeignKey("StudentId")
        //    .OnDelete(DeleteBehavior.NoAction)
        //    .IsRequired();
    }
}
