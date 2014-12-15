using System.Configuration;
using System.Web.Mvc;
using PostBoard.Data.Repository;
using PostBoard.Framework.Caching;
using PostBoard.Services.Core;
using StackExchange.Profiling;

namespace PostBoard.Controllers
{
	public class HomeController : Controller
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

        //
		// GET: /Home/
		public ActionResult Index()
		{
           // IDbContext context = new DAObjectContext(ConfigurationManager.ConnectionStrings["PostBoardDB"].ConnectionString);


			return View();
		}

        public ActionResult Login()
        {
            return View();
        }

        #region Portfolio Page


        #endregion

        [Route("portfolio/{tag?}", Name = "Portfolio")]
        [Route("home/stream/{tag?}", Name = "Stream")]
        public ActionResult Stream(string tag)
        {
            var profiler = MiniProfiler.Current; // it's ok if this is null
            using (profiler.Step("Set page title"))
            {
                ViewBag.Title = tag;
            }

            var x = _imageService.GetImageById(1);

            return View();
        }

        [Route("portfolio/page/{number:int}", Name = "PortfolioDefaultPaging")]
        public ActionResult Stream(int number)
        {
            var profiler = MiniProfiler.Current; // it's ok if this is null
            using (profiler.Step("Set page title"))
            {
                ViewBag.Title = string.Format("default page of page {0}", number);
            }

            return View();
        }

        [Route("portfolio/{tag}/page/{number:int}", Name = "PortfolioTagsPaging")]
        public ActionResult Stream(string tag, int number)
        {
            var profiler = MiniProfiler.Current; // it's ok if this is null
            using (profiler.Step("Set page title"))
            {
                ViewBag.Title = string.Format("{0} of page {1}", tag, number);
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}