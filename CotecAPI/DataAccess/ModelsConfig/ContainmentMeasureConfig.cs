using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class ContainmentMeasureConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ContainmentMeasure> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("ContainmentMeasures");

            // Primary Key
            entityBuilder.HasKey(cm => cm.Id);

            // cm Id
            entityBuilder.Property(cm => cm.Id)
                         .IsRequired()
                         .ValueGeneratedOnAdd(); // AutoIncremental

            // cm Name
            entityBuilder.Property(cm => cm.Name)
                         .HasColumnType("varchar")
                         .HasMaxLength(255)
                         .IsRequired();

            // cm Description
            entityBuilder.Property(ctry => ctry.Name)
                         .HasColumnType("varchar")
                         .HasMaxLength(255);

        }
    }
}