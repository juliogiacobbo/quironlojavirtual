using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ProdutosController : Controller
    {
		//criação de uma variavel
		private ProdutosRepositorio _repositorio;

        // GET: Produtos
        public ActionResult Index()
        {
			_repositorio = new ProdutosRepositorio();
			//selecionar uma lista com 10 produtos
			var produtos = _repositorio.Produtos.Take(10);
			//retorna uma View de Produtos, para criar foi só clicar com o botão direito e ADD VIEW, Template: List, e Model class: Produto (Quiron.LojaVirtual.Dominio.Entidades), Data Context: EfDbContext (Quiron.LojaVirtual.Dominio.Repositorio)
            return View(produtos);

        }
    }
}