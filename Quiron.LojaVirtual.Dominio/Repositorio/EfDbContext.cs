using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
	public class EfDbContext : DbContext
	{
		//Mapeamento da classe Produtos que criamos no Entity
		public DbSet<Produto> Produtos { get; set; }

		//Remove a Pluralização que o Entity faz automaticamente. Ex: Pessoa fica Pesssoas
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
			//Tenho que falar que a minha tabela Produto posso chamar de produtos
			modelBuilder.Entity<Produto>().ToTable("Produtos");
		}
	}
}
