using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tastease.Infrastructure.Data.CoreContext.Config;

public class CuisineConfiguration : IEntityTypeConfiguration<CuisineTable>
{
  public void Configure(EntityTypeBuilder<CuisineTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasIndex(x => x.Guid)
      .IsUnique();
    builder.HasIndex(x => new { x.Name, x.Region })
      .IsUnique();

  }
}
