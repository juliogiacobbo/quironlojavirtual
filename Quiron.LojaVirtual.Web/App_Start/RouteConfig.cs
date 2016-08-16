using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


			//alterando a URL da paginação para ficar mais amigável
			routes.MapRoute(
				name: null,
				url: "Pagina{pagina}",
				defaults: new { controller = "Vitrine", action = "ListaProdutos" }
				);


			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Produtos", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
