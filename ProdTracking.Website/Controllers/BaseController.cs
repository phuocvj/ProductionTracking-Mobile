using ProdTracking.Business.Interfaces;
using ProdTracking.Business.Services;
using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProdTracking.Website.Controllers
{

    public class BaseController : Controller
    {
        #region Variables

        Assembly assembly = Assembly.GetExecutingAssembly();
        ICommonServices _CommonServices { get; set; }

        #endregion

        #region Constructors

        public BaseController()
        {
            _CommonServices = new CommonServices();
        }

        public BaseController(ICommonServices commonServices) : this()
        {
            _CommonServices = commonServices;
        }

        #endregion

        #region Override Events

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);
        }


        protected override void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                if (context != null &&
                    context.HttpContext != null &&
                    context.HttpContext.Request.Params != null &&
                    context.HttpContext.Request.Params["scroll"] != null)
                {
                    object viewModel = System.Web.HttpContext.Current.Session["ViewModel"];
                    if (viewModel != null)
                    {
                        string typeName = viewModel.GetType().UnderlyingSystemType.FullName;
                        var type = Type.GetType(typeName);
                        if (type == null)
                        {
                            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                            {
                                type = a.GetType(typeName);
                                if (type != null) break;
                            }
                        }

                        PropertyInfo propertyInfo = type.GetProperty("Scroll");
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(viewModel, Convert.ToInt32(context.HttpContext.Request.Params["scroll"]), null);
                        }
                    }
                }
            }
            catch { }

            base.OnActionExecuted(context);
        }
        #endregion

        #region Methods

        protected void ViewModelSave(object obj, string name)
        {
            System.Web.HttpContext.Current.Session[name] = obj;
        }

        protected T ViewModelRestore<T>(object obj, string name)
        {
            return (T)System.Web.HttpContext.Current.Session[name];
        }

        protected string GetResource(string type, string key)
        {
            return HttpContext.GetLocalResourceObject(type, key) as string;
        }

        #endregion
    }
}