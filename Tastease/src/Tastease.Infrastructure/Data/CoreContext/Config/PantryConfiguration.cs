using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tastease.Infrastructure.Data.CoreContext.Config;

public class PantryConfiguration : IEntityTypeConfiguration<PantryTable>
{
  public void Configure(EntityTypeBuilder<PantryTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasIndex(x => x.Guid)
      .IsUnique();
  }
}
