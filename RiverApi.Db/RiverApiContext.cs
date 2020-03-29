using Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Database {
    public class RiverApiContext : DbContext {
        private readonly string _connectionString;

        public DbSet<User> User { get; set; }
        public DbSet<HotSpot> HotSpots { get; set; }
        public DbSet<LevelSpot> LevelSpots { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<River> River { get; set; }
        public DbSet<Section> Sections { get; set; }
        
        /// <summary>
        /// For CLI usages only
        /// </summary>
        public RiverApiContext() {
            
        }

        public RiverApiContext(string connectionString) {
            _connectionString = connectionString;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer(_connectionString ??
                              "Data Source=.,1434;Initial Catalog=RiverApi;user=sa;pwd=SqlServer.1");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            
            //TODO: Include IEntityTypeConfiguration<Model> here
            modelBuilder.ApplyConfiguration(new RiverConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new LevelSpotConfiguration());
        }
    }
}