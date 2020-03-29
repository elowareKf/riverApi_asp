using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Database.Configurations {
    public class SectionConfiguration : IEntityTypeConfiguration<Section> {
        public void Configure(EntityTypeBuilder<Section> builder) {
            builder.HasOne(s => s.LevelSpot)
                .WithMany()
                .HasForeignKey(s => s.LevelSpotId)
                .HasPrincipalKey(l=>l.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(s => s.HotSpots)
                .WithOne();
        }
    }
}