using System;
using System.Globalization;
using System.Threading;
using System.Web;

namespace ProdTracking.Common
{
    /// <summary>
    /// Author      : CSI.VJ
    /// Create date : 2018-07-17
    /// Description : Http Helper
    /// Latest
    /// Modifier    : HA-SEUNGMIN
    /// Modify date : 2018-07-17
    /// Remark      : 
    /// </summary>
    public static class HttpHelper
    {
        public static void SetCulture(string culture)
        {
            if (string.IsNullOrEmpty(culture)) return;

            UserInfo.Culture = culture;

            Thread.CurrentThread.CurrentCulture =
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
        }

        public static void SetCookies(string name, string value, int day)
        {
            HttpContext.Current.Response.Cookies[name].Value = value;
            HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddDays(day);
        }

        public static string GetCookies(string name)
        {
            if (HttpContext.Current.Request == null || HttpContext.Current.Request.Cookies[name] == null)
            {
                return null;
            }
            else
            {
                return string.Format("{0}", HttpContext.Current.Request.Cookies[name].Value);
            }
        }

        public static string GetMessage(object obj)
        {
            return string.Format("<script>setTimeout(\"alert('{0}')\", 10)</script>", obj);
        }

        public static string GetMessage(string type, string key)
        {
            return GetMessage(type, key, UserInfo.Culture);
        }

        public static string GetMessage(string type, string key, string culture)
        {
            return GetMessage(HttpContext.GetGlobalResourceObject(type, key, new CultureInfo(culture)));
        }
    }
}