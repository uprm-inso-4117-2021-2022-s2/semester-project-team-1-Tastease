using Tastease.Core.RecipeAggregate.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Tastease.Infrastructure.Extensions.ValueConversionExtensions;
namespace Tastease.Infrastructure.Data.CoreContext.Config;
public class InstructionConfiguration : IEntityTypeConfiguration<InstructionTable>
{
  public void Configure(EntityTypeBuilder<InstructionTable> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasIndex(x => x.Guid)
      .IsUnique();
    builder.Property(x => x.Adjustments).HasJsonConversion();
    builder.HasOne(x => x.MeasuredIngredients);
    builder.HasOne(x => x.Appliance);
  }
}

