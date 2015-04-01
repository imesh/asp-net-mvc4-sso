using System.Web;
using System.Web.Mvc;

namespace Mvc4SingleSignOnWSFederation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}