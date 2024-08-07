﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrapAround.Domain.Students;

namespace WrapAround.Infrastructure.Students;

internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(student => student.Id);
        builder.Property(student => student.Id)
            .HasConversion(
                id => id.Value,
                value => StudentId.Create(value)
            );

        // TODO: Configure Student properties
    }
}
