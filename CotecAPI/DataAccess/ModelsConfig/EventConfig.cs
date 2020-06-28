using CotecAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class EventConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Event> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("Events");

            // Primary Key
            entityBuilder.HasKey(e => e.Id); 

            // Event Type
            entityBuilder.Property(e => e.Type)
                         .HasColumnType("varchar(20)")
                         .IsRequired();

            // Event Date
            entityBuilder.Property(e => e.Date)
                         .HasColumnType("date")
                         .IsRequired();

            // CountryCode
            entityBuilder.Property(e => e.CountryCode)
                         .HasColumnType("varchar(3)")
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<Country>(e => e.Country)
                         .WithMany(ctry => ctry.CountryEvents)
                         .HasForeignKey(e => e.CountryCode);

        }
    }
}