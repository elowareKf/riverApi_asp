using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace RiverApi.Db.Configurations {
    public class LevelSpotConfiguration : IEntityTypeConfiguration<LevelSpot> {
        public void Configure(EntityTypeBuilder<LevelSpot> builder) {
            builder.HasMany(l => l.Measurements)
                .WithOne();
        }
    }
}