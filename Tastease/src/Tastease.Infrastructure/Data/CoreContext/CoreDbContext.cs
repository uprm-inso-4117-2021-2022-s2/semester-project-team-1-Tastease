using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Tastease.Core.RecipeAggregate.Tables;
using Tastease.Infrastructure.Data.CoreContext.Config;

namespace Tastease.Infrastructure.Data.CoreContext;
public partial class CoreDbContext : DbContext
{
  public CoreDbContext() : base() { }
  public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer("Server=localhost;Database=TasteaseCore;Trusted_Connection=True;MultipleActiveResultSets=true");
      //throw new Exception($"{nameof(CoreDbContext)} {nameof(DbContextOptionsBuilder)} was not properly injected.");
    }
  }
  public virtual DbSet<AllergyTable> Allergies { get; set; }
  public virtual DbSet<ApplianceTable> Appliances { get; set; }
  public virtual DbSet<CookTable> Cooks { get; set; }
  public virtual DbSet<CuisineTable> Cuisines { get; set; }
  public virtual DbSet<IngredientTable> Ingredients { get; set; }
  public virtual DbSet<InstructionTable> Instructions { get; set; }
  public virtual DbSet<MeasuredIngredientTable> MeasuredIngredients { get; set; }
  public virtual DbSet<NutritionalPropertyTable> NutritionalProperties { get; set; }
  public virtual DbSet<PantryTable> Pantries { get; set; }
  public virtual DbSet<RecipeTable> Recipes { get; set; }
  public virtual DbSet<ShelfLifeTable> ShelfLifes { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new AllergyConfiguration());
    modelBuilder.ApplyConfiguration(new ApplianceConfiguration());
    modelBuilder.ApplyConfiguration(new CookConfiguration());
    modelBuilder.ApplyConfiguration(new CuisineConfiguration());
    modelBuilder.ApplyConfiguration(new IngredientConfiguration());
    modelBuilder.ApplyConfiguration(new InstructionConfiguration());
    modelBuilder.ApplyConfiguration(new MeasuredIngredientConfiguration());
    modelBuilder.ApplyConfiguration(new NutritionalPropertyConfiguration());
    modelBuilder.ApplyConfiguration(new PantryConfiguration());
    modelBuilder.ApplyConfiguration(new RecipeValueConfiguration());
    modelBuilder.ApplyConfiguration(new RecipeConfiguration()); 
    modelBuilder.ApplyConfiguration(new ShelfLifeConfiguration());
    }
}
