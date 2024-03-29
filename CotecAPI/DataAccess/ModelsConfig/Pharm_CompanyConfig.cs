using CotecAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class Pharm_CompanyConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PharmaceuticalCompany> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("PharmaceuticalCompanies");
            
            // Set Primary Key
            entityBuilder.HasKey(pc => pc.Id);
            
            // Id
            entityBuilder.Property(pc => pc.Id)
                         .HasColumnType("int")
                         .ValueGeneratedOnAdd()
                         .IsRequired();

            // Name
            entityBuilder.Property(pc => pc.Name)
                         .HasColumnType("varchar(60)")
                         .IsRequired();
        }
    }
}