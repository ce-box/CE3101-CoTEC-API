using CotecAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class PersonConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ContactedPerson> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("ContactedPersons");

            // Primary Key
            entityBuilder.HasKey(con => con.Dni); 

            // Person Dni
            entityBuilder.Property(con => con.Dni)
                         .HasColumnType("varchar(30)")
                         .IsRequired();

            // Person Name
            entityBuilder.Property(con => con.Name)
                         .HasColumnType("varchar(20)")
                         .IsRequired();

            // Person LastName
            entityBuilder.Property(con => con.LastName)
                         .HasColumnType("varchar(20)")
                         .IsRequired();
                        
            // Person Birth date
            entityBuilder.Property(con => con.DoB)
                         .HasColumnType("date")
                         .IsRequired();
                        
            // Person Email
            entityBuilder.Property(con => con.Email)
                         .HasColumnType("varchar(60)")
                         .IsRequired();
            
            // Person Address
            entityBuilder.Property(con => con.Address)
                         .HasColumnType("varchar(255)");

            // Person Region
            entityBuilder.Property(con => con.Region)
                         .HasColumnType("varchar(50)")
                         .IsRequired();
                        
            // Person Country
            entityBuilder.Property(con => con.Country)
                         .HasColumnType("varchar(3)")
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<Region>(con => con.PersonRegion)
                         .WithMany(r => r.ContactedPersons)
                         .HasForeignKey(con => new{con.Region,con.Country})
                         .OnDelete(DeleteBehavior.NoAction);

        }
        
    }
}