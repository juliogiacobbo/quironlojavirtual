using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
		//criação de uma variavel
		private ProdutosRepositorio _repositorio;
		public int ProdutosPorPagina = 3;

		// GET: Produtos
		public ActionResult ListaProdutos(int pagina = 1)
		{
			_repositorio = new ProdutosRepositorio();
			//ordena os produtos retornados e seleciona 3, depois pagina removando os que já foram exibidos.
			var produtos = _repositorio.Produtos.OrderBy(p => p.Descricao).Skip((pagina - 1) * ProdutosPorPagina).Take(ProdutosPorPagina);

			return View(produtos);

		}
    }
}