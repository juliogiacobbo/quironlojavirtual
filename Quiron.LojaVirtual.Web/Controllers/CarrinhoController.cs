using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Controllers
{
	

    public class CarrinhoController : Controller
    {
		//Acesso ao banco
		private ProdutosRepositorio _repositorio;

        // GET: Carrinho. Recebe por parâmetro o ProdutoId e a URL
        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
			//Cria um objeto repositorio
			_repositorio = new ProdutosRepositorio();
			//Query nesse produto
			Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
			//Vê se ja tem esse produto no carrinho:
			if (produto != null)
			{
				//Chama esse método que pede como parâmetro o produto e a Qtd
				ObterCarrinho().AdicionarItem(produto, 1);
			}
			return RedirectToAction("Index", new { returnUrl });
        }

		private Carrinho ObterCarrinho()
		{
			//É criada uma sessão para guardar o estado do carrinho!
			//como retorna um carrinho é precisa criar um
			Carrinho carrinho = (Carrinho)Session["Carrinho"];
			//se o carrinho não existir:
			if (carrinho == null)
			{
				carrinho = new Carrinho();
				Session["Carrinho"] = carrinho;
			}
			return carrinho;
		}

		public RedirectToRouteResult Remover(int produtoId, string returnUrl)
		{
			_repositorio = new ProdutosRepositorio();

			Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

			if (produto != null)
			{
				ObterCarrinho().RemoverItem(produto);
			}

			return RedirectToAction("Index", new { returnUrl });
		}
    }
}