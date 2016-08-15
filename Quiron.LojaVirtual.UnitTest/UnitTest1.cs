using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.HtmlHelpers;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
	[TestClass]
	public class UnitTest1
	{

		[TestMethod]
		public void Take()
		{
			//O operador Take é usado para selecionar os primeiros n objetos de uma coleção.

			int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

			var resultado = from num in numeros.Take(5) select num;

			int[] teste = { 5, 4, 1, 3, 9 };

			CollectionAssert.AreEqual(resultado.ToArray(), teste);

		}


		[TestMethod]
		public void Skip()
		{

			//O operador Skip ignora o(s) primeiro(s) n objetos de uma coleção.

			int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

			var resultado = from num in numeros.Take(5).Skip(2) select num;

			int[] teste = { 1, 3, 9 };

			CollectionAssert.AreEqual(resultado.ToArray(), teste);

		}


		[TestMethod]
		public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
		{
			//Testando com AAA (Arrange, Act, Assert) Fonte: http://blog.lambda3.com.br/2010/08/testando-com-aaa-arrange-act-assert/
			/*
			 Não, AAA não é só uma pilha, é também uma forma de testar. O que eu vou mostrar aqui talvez você já conheça, talvez você já faça, mas talvez nunca tenha parado pra pensar no assunto.

	Todo teste passa por uma preparação, seja de ambiente, variáveis, banco de dados, etc. Essa preparação pode ser chamada em inglês de Arrange. Nosso primeiro A.
	Em seguida, todo teste passa por um momento onde estimulamos o sistema sendo testado (System Under Test em inglês, ou SUT). Isso é o Act, nosso segundo A.
	E logo em seguida, verificarmos se os resultados obtidos batem com os resultados esperados. Isso é o Assert, o terceiro A.
			 */


			//Arrange:

			HtmlHelper html = null;

			Paginacao paginacao = new Paginacao
			{
				PaginaAtual = 2,
				ItensPorPagina = 10,
				ItensTotal = 28
			};

			Func<int, string> paginaUrl = i => "Pagina" + i;

			//Act

			MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

			//Assert

			Assert.AreEqual(
					@"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
				 + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
				 + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
				 );
		}

	}
}
