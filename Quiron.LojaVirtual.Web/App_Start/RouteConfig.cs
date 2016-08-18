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


			//1 - Quando a URL for "/" vai trazer produtos de todas as categorias

			routes.MapRoute(null,
				"",
				new
				{
					controller = "Vitrine"
					,
					action = "ListaProdutos"
					,
					categoria = (string)null,
					pagina = 1
				});


			// 2 - Quando for a URL "/Pagina{X}" traz todas as categorias da Página X

			routes.MapRoute(null,
				"Pagina{pagina}",
				new
				{
					controller = "Vitrine",
					action = "ListaProdutos",
					categoria = (string)null
				},
				new { pagina = @"\d+" }); // expressao reglar para tratamento para receber somente numero


			//3 - Quando for a URL "/{Categoria}" Primeira página da Categoria X

			routes.MapRoute(null, "{categoria}", new
			{
				controller = "Vitrine",
				action = "ListaProdutos",
				pagina = 1
			});


			//4 - Quando for a URL "{Categoria X}/{Pagina X}" Página X da Categoria X

			routes.MapRoute(null,
				"{categoria}/Pagina{pagina}",
				new
				{
					controller = "Vitrine",
					action = "ListaProdutos"
				},
				new { pagina = @"\d+" });



			routes.MapRoute(null, "{controller}/{action}");

		}
	}
}
