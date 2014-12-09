using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PostBoard.Data.Models;

namespace PostBoard.Data.Mapping
{
    public partial class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
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

            this.Property(t => t.SeoName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ParentId)
                .IsRequired();

            this.HasMany(t => t.ChildCategories)
            .WithRequired()
            .HasForeignKey(t => t.ParentId);

            //this.HasRequired(t => t.ParentTag)
            //.WithMany()
            //.HasForeignKey(x => x.Id);

            // Table & Column Mappings
            this.ToTable("Tag");

        }
    }
}
