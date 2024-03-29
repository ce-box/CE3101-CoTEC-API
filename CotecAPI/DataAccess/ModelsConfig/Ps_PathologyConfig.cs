using CotecAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class Ps_PathologyConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PersonPathologies> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("PersonPathologies");

            // Primary Key
            entityBuilder.HasKey(pp => new{pp.PathologyName,pp.PersonDni}); 

            // PersonDni
            entityBuilder.Property(pp => pp.PersonDni)
                         .HasColumnType("varchar(30)")
                         .IsRequired();
                        
            // PathologyName
            entityBuilder.Property(pp => pp.PathologyName)
                         .HasColumnType("varchar(50)")
                         .IsRequired();


            // Foreign Key
            entityBuilder.HasOne<ContactedPerson>(pp => pp.Contacted)
                         .WithMany(cp => cp.Pathologies)
                         .HasForeignKey(pp => pp.PersonDni)
                         .OnDelete(DeleteBehavior.NoAction);

            entityBuilder.HasOne<Pathology>(pp => pp.Pathology)
                         .WithMany(p => p.PersonPathologies)
                         .HasForeignKey(pp => pp.PathologyName)
                         .OnDelete(DeleteBehavior.NoAction);

        }
    }
}