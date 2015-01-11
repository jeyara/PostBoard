using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboDSLR.Data.Enum;
using TurboDSLR.Data.Repository;

namespace TurboDSLR.Data.Models
{
    public partial class ImageSchedule : BaseEntity
    {
        public int imageId  { get; set; }

        public int StatusId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ScheduleStatus Status
        {
            get
            {
                return (ScheduleStatus)this.StatusId;
            }
            set
            {
                this.StatusId = (int)value;
            }
        }

        public virtual Image Image { get; set; }

    }
}
