using System;

namespace Quiron.LojaVirtual.Web.Models
{
	public class Paginacao
	{
		//total de itens que tem no banco:
		public int ItensTotal { get; set; }
		//quantos itens eu quero em uma pagina:
		public int ItensPorPagina { get; set; }
		//qual a página que esta sendo exibida no momento, serve para setar a cor do botao de paginacao:
		public int PaginaAtual { get; set; }
		//retorna quantas paginas terão que aparecer para exibir todos os produtos, serve para renderizar somento os botões de paginação necessários (só GET pois só vai ler os dados / Ceiling arredonda para cima a divisão):
		public int TotalPaginas
		{
			get
			{
				return (int)Math.Ceiling((decimal)ItensTotal / ItensPorPagina);
			}
		}
	}
}