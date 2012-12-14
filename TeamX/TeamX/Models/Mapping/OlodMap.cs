using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TeamX.Models.Mapping
{
    public class OlodMap : EntityTypeConfiguration<Olod>
    {
        public OlodMap()
        {
            // Primary Key
            this.HasKey(t => t.olod_id);

            // Properties
            this.Property(t => t.olod_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.naam)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Olod");
            this.Property(t => t.olod_id).HasColumnName("olod_id");
            this.Property(t => t.naam).HasColumnName("naam");
            this.Property(t => t.studiepunten).HasColumnName("studiepunten");
            this.Property(t => t.omschrijving).HasColumnName("omschrijving");
        }
    }
}
