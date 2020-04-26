using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace RiverApi.Db.Configurations {
    public class SectionConfiguration : IEntityTypeConfiguration<Section> {
        public void Configure(EntityTypeBuilder<Section> builder) {
            
            builder.HasOne(s => s.LevelSpot)
                .WithMany()
                .HasForeignKey(s => s.LevelSpotId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(s => s.HotSpots)
                .WithOne();
        }
    }
}