﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboDSLR.Data.Enum;
using TurboDSLR.Data.Models;
using TurboDSLR.Data.Repository;
using TurboDSLR.Framework;
using TurboDSLR.Framework.Caching;


namespace TurboDSLR.Services.Core
{
    public class ImageService: IImageService
    {
        private readonly IRepository<Image> _imageRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly ICacheManager _cacheManager;

        //http://www.interviewzen.com/interview/Ypk9k2
        //public int MaxConsecutiveSequence(int[] a)
        //{
        //    //Holds final count of consecutive Sequence.
        //    int maxConsecutiveSequence = 0;

        //    //This is used to increment values
        //    int elementValueToCheck = 1;
            
        //    //Loop through the array.
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        //If current element value is equal then it is considered as sequence.
        //        if (a[i] == elementValueToCheck)
        //        {
        //            if (elementValueToCheck > 1 && elementValueToCheck > maxConsecutiveSequence)
        //                maxConsecutiveSequence = elementValueToCheck;
        //        }
        //        else
        //        {
        //            elementValueToCheck = 0;
        //        }

        //        elementValueToCheck++;
        //    }

        //    return maxConsecutiveSequence;
        //}
        
        public ImageService(IRepository<Image> imageRepository, IRepository<Tag> tagRepository, ICacheManager cacheManager)
        {
            this._imageRepository = imageRepository;
            this._tagRepository = tagRepository;
            this._cacheManager = cacheManager;
        }

        public Image GetImageById(int id)
        {
            if (id < 0)
                return null;

            return _imageRepository.GetById(id); ;
        }

        public IPagedList<Image> GetImages(bool filterBySchedule = true, string slugToFilter = "", int? pageNo = null, int? pageSize = null)
        {
            var query = _imageRepository.Table;

            if (filterBySchedule)
                query = query.Where(c => c.ImageSchedules.Any(p=> p.Status == ScheduleStatus.Active && p.StartDate >= DateTime.UtcNow && (p.EndDate.HasValue == false || (p.EndDate.HasValue == true && p.EndDate.Value <= DateTime.UtcNow))));

            if (!string.IsNullOrWhiteSpace(slugToFilter))
                query = query.Where(c => c.ImageTags.Any(t=>t.Tag.SeoName.ToLower() == slugToFilter.ToLower()));

            int pNo = 1;
            int pSize = int.MaxValue;

            if (pageNo.HasValue)
                pNo = pageNo.Value;

            if (pageSize.HasValue)
                pSize = pageSize.Value;

            //paging
            return new PagedList<Image>(query.ToList(), pNo, pSize);
        }

        public IPagedList<Image> GetImagesByTagId(int tagId)
        {
            var query = _imageRepository.Table;

            query = query.Where(c => c.ImageTags.Any(p => p.TagId == tagId));

            //paging
            return new PagedList<Image>(query.ToList());
        }

        public IPagedList<Image> GetFeaturedImages(bool filterBySchedule = true, int? pageNo = null, int? pageSize = null)
        {
            var query = _imageRepository.Table;

            if (filterBySchedule)
                query = query.Where(c => c.ImageSchedules.Any(p => p.Status == ScheduleStatus.Active && p.StartDate >= DateTime.UtcNow && (p.EndDate.HasValue == false || (p.EndDate.HasValue == true && p.EndDate.Value <= DateTime.UtcNow))));

            int pNo = 1;
            int pSize = int.MaxValue;

            if (pageNo.HasValue)
                pNo = pageNo.Value;

            if (pageSize.HasValue)
                pSize = pageSize.Value;

            //paging
            return new PagedList<Image>(query.ToList(), pNo, pSize);
        }

        public void InsertImage(Image image)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            _imageRepository.Insert(image);
        }

        public void UpdateImage(Image image)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            _imageRepository.Update(image);
        }

        public void DeleteImage(Image image)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            _imageRepository.Delete(image);
        }

        public Tag GetTagById(int id)
        {
            if (id < 0)
                return null;

            return _tagRepository.GetById(id); ;
        }

        public Tag GetTagByTagSlug(string slug)
        {
            var query = _tagRepository.Table;

            if (!string.IsNullOrWhiteSpace(slug))
                query = query.Where(c => c.SeoName.ToLower() == slug.ToLower());

            return query.FirstOrDefault();
        }

        public IPagedList<Tag> GetTagByParentTagId(int tagId)
        {
            var query = _tagRepository.Table;

            query = query.Where(c => c.ParentId == tagId);

            return new PagedList<Tag>(query.ToList());
        }

        public void InsertTag(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            _tagRepository.Insert(tag);
        }

        public void UpdateTag(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            _tagRepository.Update(tag);
        }

        public void DeleteTag(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            _tagRepository.Delete(tag);
        }
    }
}
