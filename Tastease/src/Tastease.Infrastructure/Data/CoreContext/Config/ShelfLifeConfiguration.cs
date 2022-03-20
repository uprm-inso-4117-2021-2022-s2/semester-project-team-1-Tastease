using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tastease.Core.Literals;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Tastease.Infrastructure.Data.CoreContext.Config;

public class ShelfLifeConfiguration : IEntityTypeConfiguration<ShelfLifeTable>
{
  public void Configure(EntityTypeBuilder<ShelfLifeTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.Property(x => x.State)
      .HasConversion(new EnumToStringConverter<State>());
  }
}
