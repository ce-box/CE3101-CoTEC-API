using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class CountryConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Country> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("Countries");

            // Primary Key
            entityBuilder.HasKey(ctry => ctry.Code); 

            // Country Code
            entityBuilder.Property(ctry => ctry.Code)
                         .HasColumnType("varchar(3)")
                         .IsRequired();

            // Country Name
            entityBuilder.Property(ctry => ctry.Name)
                         .HasColumnType("varchar(60)")
                         .IsRequired();

            // Flag Url
            entityBuilder.Property(ctry => ctry.FlagUrl)
                         .HasColumnType("varchar(45)");

            // ContinentCode
            entityBuilder.Property(ctry => ctry.ContinentCode)
                         .HasColumnType("varchar(2)")
                         .IsRequired();


            // Foreign Key
            entityBuilder.HasOne<Continent>(ctry => ctry.Continent)
                         .WithMany(cnt => cnt.Countries)
                         .HasForeignKey(ctry => ctry.ContinentCode);

        }
    }
}