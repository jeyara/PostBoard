using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostBoard.Data.Models;
using PostBoard.Framework;


namespace PostBoard.Services.Core
{
    public class ImageService: IImageService
    {
        public Image GetImageById(int id)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Image> GetImages(bool filterBySchedule = true, string slugToFilter = "", int? pageNo = null)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Image> GetImagesByTagId(int tagId)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Image> GetFeaturedImages(bool filterBySchedule = true, int? pageNo = null)
        {
            throw new NotImplementedException();
        }

        public void InsertImage(Image image)
        {
            throw new NotImplementedException();
        }

        public void UpdateImage(Image image)
        {
            throw new NotImplementedException();
        }

        public void DeleteImage(Image image)
        {
            throw new NotImplementedException();
        }

        public Tag GetTagById(int id)
        {
            throw new NotImplementedException();
        }

        public Tag GetTagByTagSlug(string slug)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Tag> GetTagByParentTagId(int tagId)
        {
            throw new NotImplementedException();
        }

        public void InsertTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void UpdateTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(Tag tag)
        {
            throw new NotImplementedException();
        }

    }
}
