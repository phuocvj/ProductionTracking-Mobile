using ProdTracking.Business.Interfaces;
using ProdTracking.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdTracking.Website.Controllers
{
    public class HomeController : BaseController
    {
        ICommonServices _CommonServices { get; set; }
        IHomeServices _HomeServices { get; set; }
        #region Constructors
        public HomeController(ICommonServices commonServices,IHomeServices homeServices)
        {
            _CommonServices = commonServices;
            _HomeServices = homeServices;
        }

        #endregion
        public ActionResult Index()
        {
            
            HttpCookie cookie = null;
            if (HttpContext.Request.Cookies["PLANT_CODE"] != null)
                cookie = HttpContext.Request.Cookies.Get("PLANT_CODE");
            List<FacType> facTypeList = new List<FacType>()
            {
                new FacType() {
                    Value = "1",
                    Text = "Plant View"
                },
                new FacType() {
                    Value = "2",
                    Text = "Factory View"
                }
            };
            
            ViewBag.UserIP = Request.UserHostAddress;
            ViewBag.FacType = facTypeList;
            ViewBag.Plant = _CommonServices.GetPlantList("Q");
            return View();
        }
        public ActionResult ProdListModelRead(string Type,string PlantCode)
        {
            HttpCookie cookie = new HttpCookie("PLANT_CODE", PlantCode);
            cookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Response.Cookies.Remove("PLANT_CODE");
            Response.Cookies.Add(cookie);
            var result = _HomeServices.ProdListModelRead(Type,PlantCode);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}