using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class ContactsByPatientConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PersonsContactedByPatient> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("PersonsContactedByPatient");

            // Primary Key
            entityBuilder.HasKey(p => new{p.ContactDni,p.PatientDni}); 

            // Meeting Date
            entityBuilder.Property(p => p.MeetingDate)
                         .HasColumnType("date");

            // CBP PatientDni
            entityBuilder.Property(p => p.PatientDni)
                         .HasColumnType("varchar(30)")
                         .IsRequired();

            // CBP ContactDni
            entityBuilder.Property(p => p.ContactDni)
                         .HasColumnType("varchar(30)")
                         .IsRequired();
            
            // Foreign Key
            entityBuilder.HasOne<Patient>(p => p.Patient)
                         .WithMany(pat => pat.ContactedPersons)
                         .HasForeignKey(p => p.PatientDni)
                         .OnDelete(DeleteBehavior.NoAction);

            entityBuilder.HasOne<ContactedPerson>(p => p.Contacted)
                         .WithMany(cp => cp.ContactedPatients)
                         .HasForeignKey(p => p.ContactDni)
                         .OnDelete(DeleteBehavior.NoAction);

        }


    }
}