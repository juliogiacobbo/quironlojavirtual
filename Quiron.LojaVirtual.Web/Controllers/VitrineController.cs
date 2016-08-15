using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
	public class VitrineController : Controller
	{
		//criação de uma variavel
		private ProdutosRepositorio _repositorio;
		public int ProdutosPorPagina = 3;

		// GET: Produtos
		public ViewResult ListaProdutos(int pagina = 1)
		{
			_repositorio = new ProdutosRepositorio();

			ProdutosViewModel model = new ProdutosViewModel
			{

				//ordena os produtos retornados e seleciona 3, depois pagina removando os que já foram exibidos.
				Produtos = _repositorio.Produtos
				.OrderBy(p => p.Descricao)
				.Skip((pagina - 1) * ProdutosPorPagina)
				.Take(ProdutosPorPagina),

				Paginacao = new Paginacao
				{
					PaginaAtual = pagina,
					ItensPorPagina = ProdutosPorPagina,
					//conta quantos produtos tem no banco:
					ItensTotal = _repositorio.Produtos.Count()
				}

			};

			return View(model);
		}
	}
}