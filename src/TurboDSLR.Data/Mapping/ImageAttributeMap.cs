using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TurboDSLR.Data.Models;

namespace TurboDSLR.Data.Mapping
{
    public partial class ImageAttributeMap : EntityTypeConfiguration<ImageAttribute>
    {
        public ImageAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            this.Property(t => t.ImageId)
                .IsRequired();

            this.Property(t => t.AttributeId)
                .IsRequired();

            this.Property(t => t.Value)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ImageAttribute");

        }
    }
}
