﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostBoard.Data.Enum;
using PostBoard.Data.Repository;

namespace PostBoard.Data.Models
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
