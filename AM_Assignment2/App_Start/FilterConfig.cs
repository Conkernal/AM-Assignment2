using System.Web;
using System.Web.Mvc;

namespace AM_Assignment2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // Treats every page as one requiring authentication (redirect to login page) unless page specifies that anonymous users can access it
        }
    }
}
