using Aula01.Model;

namespace Aula01.Services
{
	public interface ICategoriaService
	{
		public Task Cadastrar(CategoriaViewModel categoria);
		public CategoriaViewModel ObterPorId(int id);
		public IEnumerable<CategoriaViewModel> ObterTodos();
		public void Atualizar(int id);
	}
}