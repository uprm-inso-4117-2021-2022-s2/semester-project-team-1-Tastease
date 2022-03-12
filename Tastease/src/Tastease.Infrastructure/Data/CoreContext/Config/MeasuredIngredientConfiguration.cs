using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tastease.Core.Literals;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Tastease.Infrastructure.Data.CoreContext.Config;

public class MeasuredIngredientConfiguration : IEntityTypeConfiguration<MeasuredIngredientTable>
{
  public void Configure(EntityTypeBuilder<MeasuredIngredientTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasIndex(x => x.Guid)
      .IsUnique();
    builder.Property(x => x.Unit)
      .HasConversion(new EnumToStringConverter<MeasurementUnit>());
    builder.HasOne(x => x.Ingredient);
  }
}

