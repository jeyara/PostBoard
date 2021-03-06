﻿using System;
using System.Collections.Generic;
using TurboDSLR.Data.Enum;
using TurboDSLR.Data.Repository;

namespace TurboDSLR.Data.Models
{
    public class Image : BaseEntity
    {
        private ICollection<ImageAttribute> _ImageAttributes { get; set; }

        private ICollection<ImageTag> _ImageTags { get; set; }

        private ICollection<ImageSchedule> _ImageSchedules { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string AltText { get; set; }

        public string FileName { get; set; }

        public int StatusId { get; set; }

        public ImageStatus Status
        {
            get
            {
                return (ImageStatus)this.StatusId;
            }
            set
            {
                this.StatusId = (int)value;
            }
        }

        public DateTime AddedOnUtc { get; set; }

        public virtual ICollection<ImageTag> ImageTags
        {
            get { return _ImageTags ?? (_ImageTags = new List<ImageTag>()); }
            protected set { _ImageTags = value; }
        }

        public virtual ICollection<ImageAttribute> ImageAttributes
        {
            get { return _ImageAttributes ?? (_ImageAttributes = new List<ImageAttribute>()); }
            protected set { _ImageAttributes = value; }
        }

        public virtual ICollection<ImageSchedule> ImageSchedules
        {
            get { return _ImageSchedules ?? (_ImageSchedules = new List<ImageSchedule>()); }
            protected set { _ImageSchedules = value; }
        }
    }
}
