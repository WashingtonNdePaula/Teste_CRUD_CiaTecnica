using System.Web;
using System.Web.Mvc;

namespace Teste_CRUD_CiaTecnica.Presentation.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
