using Microsoft.AspNetCore.Mvc.Rendering;

namespace WK_Services.Utility
{
    public static class HtmlHelper
    {
        public static string IsSelected(this IHtmlHelper htmlHelper, string controller, string cssClass)
        {
            string currentController = htmlHelper.ViewContext.RouteData.Values["controller"] as string;
            var allControllers = controller.Split(",");
            return allControllers.Contains(currentController) ? cssClass : "";
        }
    }
}
