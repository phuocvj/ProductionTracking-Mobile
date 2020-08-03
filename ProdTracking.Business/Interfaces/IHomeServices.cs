using ProdTracking.Models.Home;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProdTracking.Business.Interfaces
{
    public interface IHomeServices
    {
        IEnumerable<ProdListModel> ProdListModelRead(string Type,string PlantCode);
    }
}
