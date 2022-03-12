using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tastease.Core.Literals;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Tastease.Infrastructure.Data.CoreContext.Config;

public class AllergyConfiguration : IEntityTypeConfiguration<AllergyTable>
{
  public void Configure(EntityTypeBuilder<AllergyTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasIndex(x => x.Guid)
      .IsUnique();
    builder.Property(x => x.Serverity)
      .HasConversion(new EnumToStringConverter<Serverity>());

    builder.HasOne(x => x.Ingredient);
  }
}
