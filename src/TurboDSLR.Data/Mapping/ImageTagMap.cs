using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TurboDSLR.Data.Models;

namespace TurboDSLR.Data.Mapping
{
    public partial class ImageTagMap : EntityTypeConfiguration<ImageTag>
    {
        public ImageTagMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            this.Property(t => t.ImageId)
                .IsRequired();

            this.Property(t => t.TagId)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ImageTag");
        }
    }
}
