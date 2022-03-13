using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tastease.Core.Literals;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Tastease.Infrastructure.Data.CoreContext.Config;
public class RecipeConfiguration : IEntityTypeConfiguration<RecipeTable>
{
  public void Configure(EntityTypeBuilder<RecipeTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasIndex(x => x.Guid)
      .IsUnique();
    builder.Property(x => x.ExecutionDifficulty)
      .HasConversion(new EnumToStringConverter<ExperienceLevel>());

    builder.HasMany(x => x.Ingredients);

    builder.HasMany(x => x.Appliances);

    builder.HasMany(x => x.Instructions)
        .WithOne(x => x.Recipe)
        .HasForeignKey(x => x.RecipeId)
        .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(x => x.Values)
        .WithOne(x => x.Recipe)
        .HasForeignKey(x => x.RecipeId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
public class RecipeValueConfiguration : IEntityTypeConfiguration<RecipeValueTable>
{
    public void Configure(EntityTypeBuilder<RecipeValueTable> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Type)
          .HasConversion(new EnumToStringConverter<RecipeType>());
    }
}
