using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
		//acesso ao banco
		private ProdutosRepositorio _repositorio;


        // GET: Categoria
        public PartialViewResult Menu(String categoria = null)
        {
			//para saber qual botão marcar como ativo
			ViewBag.CategoriaSelecionada = categoria;

			//query no banco para trazer todas as categorias
			_repositorio = new ProdutosRepositorio();

			//lista IEnuberable que recebe todas as categorias, uma de cada ordenada por ordem alfabetica:
			IEnumerable<string> categorias = _repositorio.Produtos
				.Select(c => c.Categoria)
				.Distinct()
				.OrderBy(c => c);

				//retorna uma Partialview com as categorias
			return PartialView(categorias);
        }
    }
}