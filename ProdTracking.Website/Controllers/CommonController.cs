using ProdTracking.Business.Interfaces;
using ProdTracking.Website.Controllers;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace CMMS.Website.Controllers
{
    /// <summary>
    /// Author      : CSI.VJ
    /// Create date : 2020-07-27
    /// Description : CommonController
    /// Latest
    /// Modifier    : PHUOC.IT
    /// Modify date : 2020-07-27
    /// Remark      : 
    /// </summary>
    public partial class CommonController : BaseController
    {
        #region Variables

        ICommonServices _CommonServices { get; set; }

        #endregion

        #region Constructors

        public CommonController(ICommonServices commonServices)
        {
            _CommonServices = commonServices;
        }

        #endregion

        #region Controller

        #region Get Company / Factory / Plant / Location

        public JsonResult GetPlantList(string type)
        {
            return Json(_CommonServices.GetPlantList(type), JsonRequestBehavior.AllowGet);
        }

        #endregion
        #endregion
    }
}