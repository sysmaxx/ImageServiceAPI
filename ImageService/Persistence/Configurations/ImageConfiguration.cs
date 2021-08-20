using ImageServiceApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImageServiceApi.Persistence.Configurations
{                      
    public class ImageConfiguration : IEntityTypeConfiguration<ImageData>
    {
        public void Configure(EntityTypeBuilder<ImageData> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.MimeType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PhysicalDirectory)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.MimeType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Deleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(e => e.PhysicalFileName)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("Image");
        }
    }
}
