using System.Configuration;
using System.Web.Mvc;
using TurboDSLR.Data.Repository;
using TurboDSLR.Framework.Caching;
using TurboDSLR.Framework.Web;
using TurboDSLR.Services.Core;
using StackExchange.Profiling;
using TurboDSLR.Web.Models;
using TurboDSLR.Framework.DependencyManagement;

namespace TurboDSLR.Controllers
{
    public class HomeController : PublicControllerBase
    {
        #region Fields

        private readonly IImageService _imageService;
        private readonly ISettingService _settingService;
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctr

        public HomeController(IImageService imageService, ISettingService settingService, ICacheManager cacheManager)
        {
            this._imageService = imageService;
            this._settingService = settingService;
            this._cacheManager = cacheManager;
        }

        #endregion

        #region Home Page

        // GET: /Home/
        public ActionResult Index()
        {
            HomeModel homeModel = new HomeModel();

            PhotoModel pm = new PhotoModel();
            pm.Caption = "Image One Caption";
            pm.Title = "Image One Title";
            pm.FullSizeUrl = "/assets/opera-house.jpg";
            pm.AltText = "Image One Alt Text";
            pm.Id = 1;
            homeModel.HomePhotos.Add(pm);

            PhotoModel pm2 = new PhotoModel();
            pm2.Caption = "Image 2 Caption";
            pm2.Title = "Image 2 Title";
            pm2.FullSizeUrl = "/assets/parliment-house.jpg";
            pm2.AltText = "Image 2 Alt Text";
            pm2.Id = 2;
            homeModel.HomePhotos.Add(pm2);

            PhotoModel pm3 = new PhotoModel();
            pm3.Caption = "Image 3 Caption";
            pm3.Title = "Image 3 Title";
            pm3.FullSizeUrl = "/assets/pier-sunrise.jpg";
            pm3.AltText = "Image 3 Alt Text";
            pm3.Id = 3;
            homeModel.HomePhotos.Add(pm3);

            return View(homeModel);
            //return View(BuildHomeModel());
        }

        #endregion

        #region Portfolio Page

        [Route("portfolio/tagged/{tag}/{page:int?}", Name = "Tags")]
        public ActionResult Portfolio(string tag, int page = 1)
        {
            var profiler = MiniProfiler.Current; // it's ok if this is null
            using (profiler.Step("Set page title"))
            {
                ViewBag.Title = tag + " " + page.ToString();
            }

            var x = _imageService.GetImageById(1);

            return View();
        }

        [Route("portfolio/{page:int?}", Name = "Portfolio")]
        public ActionResult Portfolio(int page = 1)
        {
            var profiler = MiniProfiler.Current; // it's ok if this is null
            using (profiler.Step("Set page title"))
            {
                ViewBag.Title = "all" + " " + page.ToString();
            }

            var x = _imageService.GetImageById(1);

            return View();
        }

        #endregion

        #region About Us

        [Route("about", Name = "About")]
        public ActionResult About()
        {
            return View();
        }

        #endregion

        #region Private Methods

        private HomeModel BuildHomeModel()
        {
            HomeModel homeModel = new HomeModel();

            var featuredImages = _imageService.GetFeaturedImages(true);

            foreach (var image in featuredImages)
            {
                PhotoModel pm = new PhotoModel();
                pm.Caption = image.Caption;
                pm.Title =  image.Title;
                pm.FullSizeUrl = image.FileName;
                pm.AltText = image.AltText;
                pm.Id = image.Id;
                homeModel.HomePhotos.Add(pm);
            }

            return homeModel;
        }

        #endregion
    
    }
}