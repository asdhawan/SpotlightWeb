using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SpotlightWebUI {
    public static class UIHelper {
        public static List<SelectListItem> GetSelectListForEnum(Type enumType) {
            Dictionary<Enum, string> dictionary = CommonUtils.Utils.GetEnumDictionary(enumType);
            return dictionary.Select(x => new SelectListItem() { Value = x.Key.ToString(), Text = x.Value }).ToList();
        }
        public static string AbsoluteRouteUrl(
            this UrlHelper urlHelper,
            string routeName,
            object routeValues = null) {
            string scheme = urlHelper.RequestContext.HttpContext.Request.Url.Scheme;
            return urlHelper.RouteUrl(routeName, routeValues, scheme);
        }
    }
}