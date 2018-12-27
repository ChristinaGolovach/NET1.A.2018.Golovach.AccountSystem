using System.Web;
using System.Web.Mvc;

namespace MvcPL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //TODO in web config 
            filters.Add(new HandleErrorAttribute());
        }
    }
}
