using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingCart.API.Product
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}