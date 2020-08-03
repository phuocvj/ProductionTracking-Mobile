using System.Collections.Generic;
using System.Web.Mvc;

namespace ProdTracking.Business.Interfaces
{
    public interface ICommonServices
    {
        #region get Plant
        List<SelectListItem> GetPlantList(string type);
        #endregion
    }
}