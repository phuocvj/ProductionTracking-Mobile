using ProdTracking.Models.Common;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc.Html;

namespace System.Web.Mvc
{
    /// <summary>
    /// Author      : CSI.VJ
    /// Create date : 2018-07-17
    /// Description : System.Web.Mvc Extension
    /// Latest
    /// Modifier    : HA-SEUNGMIN
    /// Modify date : 2018-07-17
    /// Remark      : 
    /// </summary>
    public static class SystemWebMvcExtension
    {
        public static string GetResource(this WebViewPage page, string key)
        {
            return page.ViewContext.HttpContext.GetLocalResourceObject(page.Url.RequestContext.RouteData.Values["action"].ToString(), key) as string;
        }

        public static string GetResource(this WebViewPage page, string type, string key)
        {
            return page.ViewContext.HttpContext.GetLocalResourceObject(type, key) as string;
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> listOfValues)
        {
            return RadioButtonListFor<TModel, TProperty>(htmlHelper, expression, listOfValues, Position.Horizontal);
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> listOfValues, string @class)
        {
            return RadioButtonListFor<TModel, TProperty>(htmlHelper, expression, listOfValues, Position.Horizontal, @class);
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> listOfValues, Position position, string @class = "")
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var sb = new StringBuilder();
            if (listOfValues != null)
            {
                foreach (SelectListItem item in listOfValues)
                {
                    var id = string.Format("{0}_{1}", metaData.PropertyName, item.Value);
                    var label = htmlHelper.Label(id, item.Text, new { @class = "k-radio-label" + (string.IsNullOrEmpty(@class) ? "" : " " + @class) });
                    var radio = htmlHelper.RadioButtonFor(expression, item.Value, new { id = id, @class = "k-radio" }).ToHtmlString();
                    sb.AppendFormat("<{2} class=\"radio-group\">{0}{1}</{2}>&nbsp;&nbsp;", radio, label, (position == Position.Horizontal ? "span" : "div"));
                }
            }
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<CodeModel> listOfModels)
        {
            return RadioButtonListFor<TModel, TProperty>(htmlHelper, expression, listOfModels, Position.Horizontal);
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<CodeModel> listOfModels, string @class)
        {
            return RadioButtonListFor<TModel, TProperty>(htmlHelper, expression, listOfModels, Position.Horizontal, @class);
        }

        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<CodeModel> listOfModels, Position position, string @class = "")
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var sb = new StringBuilder();
            if (listOfModels != null)
            {
                foreach (CodeModel item in listOfModels)
                {
                    var id = string.Format("{0}_{1}", metaData.PropertyName, item.COMM_CD);
                    var label = htmlHelper.Label(id, item.COMM_NM, new { @class = "k-radio-label" });
                    var radio = htmlHelper.RadioButtonFor(expression, item.COMM_CD, new { id = id, @class = "k-radio" + (string.IsNullOrEmpty(@class) ? "" : " " + @class) }).ToHtmlString();
                    sb.AppendFormat("<{2} class=\"radio-group\">{0}{1}</{2}>&nbsp;&nbsp;", radio, label, (position == Position.Horizontal ? "span" : "div"));
                }
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }

    public enum Position
    {
        Vertical, Horizontal
    }
}