using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TeamX.Models.Mapping;

namespace TeamX.Models
{
    public class TimetableContext : DbContext
    {
        static TimetableContext()
        {
            Database.SetInitializer<TimetableContext>(null);
        }

		public TimetableContext()
			: base("Name=TimetableContext")
		{
		}

        public DbSet<Docent> Docents { get; set; }
        public DbSet<Klas> Klas { get; set; }
        public DbSet<Les> Les { get; set; }
        public DbSet<Olod> Olods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DocentMap());
            modelBuilder.Configurations.Add(new KlasMap());
            modelBuilder.Configurations.Add(new LesMap());
            modelBuilder.Configurations.Add(new OlodMap());
        }
    }
}
