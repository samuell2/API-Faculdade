using Aula01.Model;

namespace Aula01.Services
{
	public interface IFornecedorService
	{
		public Task Cadastrar(FornecedorViewModel fornecedor);
		public FornecedorViewModel ObterPorId(int id);
		public IEnumerable<FornecedorViewModel> ObterTodos();
		public void Atualizar(int id);
	}
}