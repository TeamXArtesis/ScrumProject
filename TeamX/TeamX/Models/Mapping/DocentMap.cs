using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TeamX.Models.Mapping
{
    public class DocentMap : EntityTypeConfiguration<Docent>
    {
        public DocentMap()
        {
            // Primary Key
            this.HasKey(t => t.docent_id);

            // Properties
            this.Property(t => t.docent_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.naam)
                .HasMaxLength(50);

            this.Property(t => t.voornaam)
                .HasMaxLength(50);

            this.Property(t => t.email)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Docent");
            this.Property(t => t.docent_id).HasColumnName("docent_id");
            this.Property(t => t.naam).HasColumnName("naam");
            this.Property(t => t.voornaam).HasColumnName("voornaam");
            this.Property(t => t.email).HasColumnName("email");

            // Relationships
            this.HasMany(t => t.Olods)
                .WithMany(t => t.Docents)
                .Map(m =>
                    {
                        m.ToTable("Docent_olod");
                        m.MapLeftKey("docent_id");
                        m.MapRightKey("olod_id");
                    });


        }
    }
}
