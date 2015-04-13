using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TurboDSLR.Data.Models;
using TurboDSLR.Framework.Caching;
using TurboDSLR.Framework.Exif;
using TurboDSLR.Framework.Web;
using TurboDSLR.Services;
using TurboDSLR.Services.Core;
using TurboDSLR.Web.Controllers;
using TurboDSLR.Web.Models;

namespace TurboDSLR.Controllers
{
    public class AdminController : PrivateControllerBase
    {
        #region Fields

        private readonly IImageService _imageService;
        private readonly ISettingService _settingService;
        private readonly ICacheManager _cacheManager;
        private readonly IExifService _exifService;

        #endregion

        #region Ctr

        public AdminController(IImageService imageService, ISettingService settingService, ICacheManager cacheManager, IExifService exifService)
        {
            this._imageService = imageService;
            this._settingService = settingService;
            this._cacheManager = cacheManager;
            this._exifService = exifService;
        }

        #endregion

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadeFiles()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SaveUploadedFiles()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Assets\\", Server.MapPath(@"\")));

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                        var imageFileName = Path.GetFileName(file.FileName);

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);

                        var col = _exifService.ReadExifTags(path);

                        ExifModel dt = new ExifModel(col);

                        //Image img = HelperMethods.GetBaseImage(fileName);


                        //_imageService.InsertImage(img);

                        foreach (var item in col)
                        {
                            Console.WriteLine(item.Value.ToString());
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
        }
    }
}