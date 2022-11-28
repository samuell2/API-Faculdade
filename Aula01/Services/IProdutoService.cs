using Aula01.Model;

namespace Aula01.Services
{
	public interface IProdutoService
	{
		public Task Adicionar(ProdutoViewModel produto);
		public ProdutoViewModel ObterPorId(int id);
		public IEnumerable<ProdutoViewModel> ObterTodos();
		public void Atualizar (int id);
	}
}
