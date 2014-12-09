using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PostBoard.Data.Mapping
{
    public partial class AttributeMap : EntityTypeConfiguration<PostBoard.Data.Models.Attribute>
    {
        public AttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .IsRequired().HasMaxLength(250);

            this.Property(t => t.Type)
                .IsRequired().HasMaxLength(30);

            //this.HasMany(t => t.ImageAttributes)
            //.WithRequired()
            //.HasForeignKey(t => t.AttributeId)
            //.WillCascadeOnDelete(false);

            // Table & Column Mappings
            this.ToTable("Attribute");


        }
    }
}
