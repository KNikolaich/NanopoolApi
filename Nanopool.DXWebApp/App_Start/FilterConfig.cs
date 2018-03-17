using System.Web;
using System.Web.Mvc;

namespace Nanopool_DXWebApp {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}