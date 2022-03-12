using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tastease.Infrastructure.Data.CoreContext.Config;
public class ApplianceConfiguration : IEntityTypeConfiguration<ApplianceTable>
{
  public void Configure(EntityTypeBuilder<ApplianceTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasIndex(x => x.Guid)
      .IsUnique();
    builder.HasIndex(x => x.Name)
      .IsUnique();
  }
}

