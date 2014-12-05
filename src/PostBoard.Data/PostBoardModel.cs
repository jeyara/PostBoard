namespace PostBoard.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PostBoardModel : DbContext
    {
        public PostBoardModel()
            : base("name=PostBoardDB")
        {
        }

        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ImageAttribute> ImageAttributes { get; set; }
        public virtual DbSet<ImageSchedule> ImageSchedules { get; set; }
        public virtual DbSet<ImageTag> ImageTags { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.ImageAttributes)
                .WithRequired(e => e.Attribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.ImageAttributes)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.ImageSchedules)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.ImageTags)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.ImageTags)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.Tag1)
                .WithRequired(e => e.Tag2)
                .HasForeignKey(e => e.ParentId);
        }
    }
}
