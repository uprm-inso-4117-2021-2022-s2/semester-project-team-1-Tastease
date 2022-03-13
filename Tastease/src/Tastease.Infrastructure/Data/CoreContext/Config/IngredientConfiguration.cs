using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tastease.Core.Literals;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Tastease.Infrastructure.Data.CoreContext.Config;

public class IngredientConfiguration : IEntityTypeConfiguration<IngredientTable>
{
  public void Configure(EntityTypeBuilder<IngredientTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasIndex(x => x.Guid)
      .IsUnique();
    builder.HasIndex(x => x.Name)
      .IsUnique();

    builder.Property(x => x.Type)
      .HasConversion(new EnumToStringConverter<IngredientType>());

    builder.HasMany(x => x.MeasuredIngredients)
        .WithOne(x => x.Ingredient)
        .HasForeignKey(x => x.IngredientId)
        .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(x => x.NutritionalValues);
    builder.HasMany(x => x.ShelfLives);
  }
}

