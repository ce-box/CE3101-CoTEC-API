using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class AdminConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Admin> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("Admins");

            // Primary Key
            entityBuilder.HasKey(a => a.Username); 

            // Admin Username
            entityBuilder.Property(a => a.Username)
                         .HasColumnType("varchar")
                         .HasMaxLength(20)
                         .IsRequired();

            // Admin Password
            entityBuilder.Property(a => a.Password)
                         .HasColumnType("varchar")
                         .HasMaxLength(20)
                         .IsRequired();

            // Admin Name
            entityBuilder.Property(a => a.Name)
                         .HasColumnType("varchar")
                         .HasMaxLength(20)
                         .IsRequired();

            // Admin LastName
            entityBuilder.Property(a => a.LastName)
                         .HasColumnType("varchar")
                         .HasMaxLength(20)
                         .IsRequired();

            // Admin CountryCode
            entityBuilder.Property(a => a.CountryCode)
                         .HasColumnType("varchar")
                         .HasMaxLength(3)
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<Country>(a => a.Country)
                         .WithMany(ctry => ctry.Admins)
                         .HasForeignKey(a => a.CountryCode);

        }        
    }
}