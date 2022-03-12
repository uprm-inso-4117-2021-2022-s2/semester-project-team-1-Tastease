using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tastease.Core.Literals;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Tastease.Infrastructure.Data.CoreContext.Config;

public class CookConfiguration : IEntityTypeConfiguration<CookTable>
{
  public void Configure(EntityTypeBuilder<CookTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasIndex(x => x.Guid)
      .IsUnique();

    builder.HasIndex(x => x.Name);

    builder.Property(x => x.ExperienceLevel)
      .HasConversion(new EnumToStringConverter<ExperienceLevel>());

    builder.HasMany(x => x.Pantries)
      .WithOne(x => x.Cook)
      .OnDelete(DeleteBehavior.Cascade);
    builder.HasMany(x => x.Allergies);
    builder.HasMany(x => x.Recipes)
      .WithOne(x => x.Cook)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
