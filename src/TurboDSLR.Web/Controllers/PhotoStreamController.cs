using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurboDSLR.Framework.Caching;
using TurboDSLR.Framework.Web;
using TurboDSLR.Services.Core;
using TurboDSLR.Web.Models;

namespace TurboDSLR.Web.Controllers
{
    /// <summary>
    /// This controller does all the Ajax related loading of Public website
    /// </summary>
    [RoutePrefix("photostream")]
    public class PhotoStreamController : PublicApiControllerBase
    {
        #region Fields

        private readonly IImageService _imageService;
        private readonly ISettingService _settingService;
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctr

        public PhotoStreamController(IImageService imageService, ISettingService settingService, ICacheManager cacheManager)
        {
            this._imageService = imageService;
            this._settingService = settingService;
            this._cacheManager = cacheManager;
        }

        #endregion

        /// <summary>
        /// Returns JSON object for default portfolio page. Paging is supported.
        /// </summary>
        /// <param name="page">integer value of current page</param>
        /// <returns>JSON Coded Photo Values</returns>
        [Route("{page:int?}", Name = "Photostream")]
        [HttpGet]
        public IEnumerable<PhotoModel> Get(int page = 1)
        {
            IList<PhotoModel> pm = new List<PhotoModel>();

            for (int i = 0; i < 2; i++)
            {
                var p = new PhotoModel();

                p.FullSizeUrl = "http://www.jeyara.com/wp-content/uploads/2011/06/pink-peatals.jpg";

                pm.Add(p);
            }

            return pm;
        }

        /// <summary>
        /// Returns JSON object for selected tag in portfolio page. Paging is supported.
        /// </summary>
        /// <param name="tag">tag currently selected</param>
        /// <param name="page">integer value of current page</param>
        /// <returns></returns>
        [Route("tagged/{tag}/{page:int?}", Name = "TaggedPhotoStream")]
        [HttpGet]
        public IEnumerable<string> GetPaged(string tag, int page = 1)
        {
            return new string[] { tag, page.ToString() };
        }

        /// <summary>
        /// Returns JSON object for selected photo.
        /// </summary>
        /// <param name="id">integer value of current photo id</param>
        /// <returns></returns>
        [Route("view-photo/{id:int}")]
        [HttpGet]
        public IEnumerable<string> GetPaged(int id = 1)
        {
            return new string[] { id.ToString() };
        }
    }
}