using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Models
{
	//O Conceito de ViewModel é representar coisas além da classe. Essa viewModel nao faz parte do Dominio, irá representar Itens do meu dominio, por isso não fica no projeto Dominio:
	public class ProdutosViewModel
	{
		//coleção de produto
		public IEnumerable<Produto> Produtos { get; set; }

		public Paginacao Paginacao { get; set; }

		public string CategoriaAtual { get; set; }
	}
}