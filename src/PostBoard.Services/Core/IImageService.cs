using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostBoard.Data.Models;
using PostBoard.Framework;

namespace PostBoard.Services.Core
{
    public interface IImageService
    {
        #region Image Service

        Image GetImageById(int id);

        IPagedList<Image> GetImages(bool filterBySchedule = true, string slugToFilter = "", int? pageNo = null, int? pageSize = null);

        IPagedList<Image> GetImagesByTagId(int tagId);

        IPagedList<Image> GetFeaturedImages(bool filterBySchedule = true, int? pageNo = null, int? pageSize = null);

        void InsertImage(Image image);

        void UpdateImage(Image image);

        void DeleteImage(Image image);

        #endregion

        #region Tag Service

        Tag GetTagById(int id);

        Tag GetTagByTagSlug(string slug);

        IPagedList<Tag> GetTagByParentTagId(int tagId);

        void InsertTag(Tag tag);

        void UpdateTag(Tag tag);

        void DeleteTag(Tag tag);

        #endregion
    }
}
