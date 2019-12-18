using System.Web;
using System.Web.Mvc;

namespace Lab_33_MVC_Framework_Entity_Helpdesk
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
