using System.Configuration;
using System.Web.Mvc;
using PostBoard.Data.Repository;
using PostBoard.Framework.Caching;
using PostBoard.Framework.Web;
using PostBoard.Services.Core;
using StackExchange.Profiling;

namespace PostBoard.Controllers
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
           // IDbContext context = new DAObjectContext(ConfigurationManager.ConnectionStrings["PostBoardDB"].ConnectionString);


			return View();
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
    }
}