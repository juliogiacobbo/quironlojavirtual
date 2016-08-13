using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
   public class ProdutosRepositorio
    {
	   //variavel para referenciar o Entity, vou cahma-lo de _context
	   private readonly EfDbContext _context = new EfDbContext();
	   //vou criar uma propriedade que retorna produto, vou chamar de Produtos
	   public IEnumerable<Produto> Produtos
	   {
		   //quando chamar agora o _context, posso fazer qualquer query que precisar com o Entity
		   get { return _context.Produtos; }
	   }
    }
}
