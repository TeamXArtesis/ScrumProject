using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TeamX.Models.Mapping
{
    public class KlasMap : EntityTypeConfiguration<Klas>
    {
        public KlasMap()
        {
            // Primary Key
            this.HasKey(t => t.klas_id);

            // Properties
            this.Property(t => t.klas_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.afkorting)
                .HasMaxLength(5);

            this.Property(t => t.naam)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Klas");
            this.Property(t => t.klas_id).HasColumnName("klas_id");
            this.Property(t => t.afkorting).HasColumnName("afkorting");
            this.Property(t => t.naam).HasColumnName("naam");

            // Relationships
            this.HasMany(t => t.Olods)
                .WithMany(t => t.Klas)
                .Map(m =>
                    {
                        m.ToTable("Klas_olod");
                        m.MapLeftKey("klas_id");
                        m.MapRightKey("olod_id");
                    });


        }
    }
}
