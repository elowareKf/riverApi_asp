using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace RiverApi.Db.Configurations {
    public class RiverConfiguration : IEntityTypeConfiguration<River> {
        public void Configure(EntityTypeBuilder<River> builder) {
            builder.HasMany(r => r.LevelSpots)
                .WithOne()
                .HasForeignKey(l => l.RiverId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Sections)
                .WithOne(s => s.River)
                .HasForeignKey(s => s.RiverId);

        }
    }
}