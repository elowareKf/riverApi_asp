using Microsoft.EntityFrameworkCore;
using Models;
using RiverApi.Db.Configurations;

namespace RiverApi.Db {
    public class RiverApiContext : DbContext {
        private readonly string _connectionString;

        public DbSet<User> User { get; set; }
        public DbSet<HotSpot> HotSpots { get; set; }
        public DbSet<LevelSpot> LevelSpots { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<River> Rivers { get; set; }
        public DbSet<Section> Sections { get; set; }
        
        /// <summary>
        /// For CLI usages only
        /// </summary>
        public RiverApiContext() {
        }

        public RiverApiContext(string connectionString) : this(){
            _connectionString = connectionString;
            Database.EnsureCreated();
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