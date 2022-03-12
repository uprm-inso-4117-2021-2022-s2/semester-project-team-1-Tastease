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
  }
}
