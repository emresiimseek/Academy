using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Acedemy.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) //Existing method
        {
            filters.Add(new HandleErrorAttribute());
        }

       

    }
}
