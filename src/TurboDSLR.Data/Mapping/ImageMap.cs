using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TurboDSLR.Data.Models;

namespace TurboDSLR.Data.Mapping
{
    public partial class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(140)
                .IsRequired();

            this.Property(t => t.Caption)
                .HasMaxLength(1500)
                .IsRequired();

            this.Property(t => t.AltText)
                .HasMaxLength(140)
                .IsRequired();

            this.Property(t => t.FileName)
                .HasMaxLength(500)
                .IsRequired();

            this.Property(t => t.AddedOnUtc)
                .IsRequired();

            this.Property(t => t.StatusId)
                .IsRequired();

            this.Ignore(t => t.Status);

            //this.HasMany(t => t.ImageTags)
            //.WithRequired()
            //.HasForeignKey(t => t.ImageId);

            //this.HasMany(t => t.ImageAttributes)
            //.WithRequired()
            //.HasForeignKey(t => t.AttributeId);


            // Table & Column Mappings
            this.ToTable("Image");

        }
    }
}
