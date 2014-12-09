using System.Configuration;
using System.Web.Mvc;
using PostBoard.Data.Repository;

namespace PostBoard.Controllers
{
	public class HomeController : Controller
	{
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

        public ActionResult Stream()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}