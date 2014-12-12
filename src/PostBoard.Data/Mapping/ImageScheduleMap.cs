using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostBoard.Data.Models;

namespace PostBoard.Data.Mapping
{
    public partial class ImageScheduleMap : EntityTypeConfiguration<ImageSchedule>
    {
        public ImageScheduleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            this.Property(t => t.imageId)
            .IsRequired();

            this.Property(t => t.StatusId)
            .IsRequired();

            this.Property(t => t.StartDate)
                .IsRequired();

            this.Property(t => t.EndDate)
                .IsOptional();

            this.Ignore(t => t.Status);

            // Table & Column Mappings
            this.ToTable("ImageSchedule");

        }
    }
}
