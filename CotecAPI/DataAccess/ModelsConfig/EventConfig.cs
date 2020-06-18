using CotecAPI.Models;
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
                         .HasColumnType("varchar")
                         .HasMaxLength(20)
                         .IsRequired();

            // Event Date
            entityBuilder.Property(e => e.Date)
                         .HasColumnType("date")
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<Country>(e => e.Country)
                         .WithMany(ctry => ctry.CountryEvents)
                         .HasForeignKey(e => e.CountryCode);

        }
    }
}