using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class SanitaryMeasureConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<SanitaryMeasure> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("SanitaryMeasures");

            // Primary Key
            entityBuilder.HasKey(sm => sm.Id);

            // SM Id
            entityBuilder.Property(sm => sm.Id)
                         .IsRequired()
                         .ValueGeneratedOnAdd(); // AutoIncremental

            // SM Name
            entityBuilder.Property(sm => sm.Name)
                         .HasColumnType("varchar")
                         .HasMaxLength(255)
                         .IsRequired();

            // SM Description
            entityBuilder.Property(ctry => ctry.Name)
                         .HasColumnType("varchar")
                         .HasMaxLength(255);

        }
    }
}