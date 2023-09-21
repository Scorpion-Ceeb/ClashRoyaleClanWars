﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class SpellConfiguration : IEntityTypeConfiguration<SpellModel>
    {
        public void Configure(EntityTypeBuilder<SpellModel> builder)
        {
            builder.Property(c => c.Radius).HasColumnName("Radius");

        }
    }
}