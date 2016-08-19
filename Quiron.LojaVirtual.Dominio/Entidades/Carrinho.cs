using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
	public class Carrinho
	{

		//Lista carrinho
		private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

		//Adicionar - Método Adicionar Produto que vai receber como parâmetro o produto e a Quantidade

		public void AdicionarItem(Produto produto, int quantidade)
		{
			//Verifica se ja tem o item adicionado no carrinho, pois dai ele só soma. Faz query na lista | FirstOrDefault: esse método retorna o primeiro elemento da sequencia ou Default se nao conter elemento
			ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);
			//Checar se o produto ja esta ou nao:
			if (item == null)
			{
				_itemCarrinho.Add(new ItemCarrinho
				{
					Produto = produto,
					Quantidade = quantidade
				});
			}
			else
			{
				item.Quantidade += quantidade;
			}
		}

		//Remover item do carrinho

		public void RemoverItem(Produto produto)
		{
			//remove todos os elementos com a condição passada
			_itemCarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
		}

		//Obter o valor total

		public decimal ObterValorTotal()
		{
			return _itemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
		}

		//Limpar o carrinho

		public void LimparCarrinho()
		{
			_itemCarrinho.Clear();
		}

		//Itens do carrinho

		public IEnumerable<ItemCarrinho> ItensCarrinho
		{
			get { return _itemCarrinho; }
		}
	}

	public class ItemCarrinho
	{
		public Produto Produto { get; set; }

		public int Quantidade { get; set; }
	}
}
