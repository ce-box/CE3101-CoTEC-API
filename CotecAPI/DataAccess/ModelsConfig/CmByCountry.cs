using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class CmByCountry
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CountryContainmentMeasures> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("CountryContainmentMeasures");

            // Primary Key
            entityBuilder.HasKey(c => new{c.CountryCode,c.MeasureId});

            // CM StartDate
            entityBuilder.Property(c => c.StartDate)
                         .HasColumnType("date")
                         .IsRequired();

            // CM EndDate
            entityBuilder.Property(c => c.EndDate)
                         .HasColumnType("date")
                         .IsRequired();

            // CM Description
            entityBuilder.Property(c => c.Status)
                         .HasColumnType("varchar(15)")
                         .IsRequired();

            // CM CountryCode
            entityBuilder.Property(c => c.CountryCode)
                         .HasColumnType("varchar(3)")
                         .IsRequired();

            // CM MeasureId
            entityBuilder.Property(c => c.MeasureId)
                         .HasColumnType("int")
                         .IsRequired();

            // Foreign Keys
            entityBuilder.HasOne<Country>(c => c.Country)
                         .WithMany(ctry => ctry.ImplementedContainmentMeasures)
                         .HasForeignKey(c => c.CountryCode)
                         .OnDelete(DeleteBehavior.NoAction);

             entityBuilder.HasOne<ContainmentMeasure>(c => c.Measure)
                         .WithMany(m => m.ImplementedMeasures)
                         .HasForeignKey(c => c.MeasureId)
                         .OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}