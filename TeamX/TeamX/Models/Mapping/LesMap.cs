using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TeamX.Models.Mapping
{
    public class LesMap : EntityTypeConfiguration<Les>
    {
        public LesMap()
        {
            // Primary Key
            this.HasKey(t => t.les_id);

            // Properties
            this.Property(t => t.les_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.lokaal)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Les");
            this.Property(t => t.les_id).HasColumnName("les_id");
            this.Property(t => t.tijd).HasColumnName("tijd");
            this.Property(t => t.olod_id).HasColumnName("olod_id");
            this.Property(t => t.duur_in_minuten).HasColumnName("duur_in_minuten");
            this.Property(t => t.lokaal).HasColumnName("lokaal");
            this.Property(t => t.dag).HasColumnName("dag");
            this.Property(t => t.week).HasColumnName("week");

            // Relationships
            this.HasOptional(t => t.Olod)
                .WithMany(t => t.Les)
                .HasForeignKey(d => d.olod_id);

        }
    }
}
