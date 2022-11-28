using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using AutoMapper;
using Aula01.Utilitarios;

namespace Aula01.Services
{
	public class ProdutoService : IProdutoService
	{

		private readonly IProdutoRepository _produtoRepository;
		private IMapper _mapper;

		public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
		}

		public async Task Adicionar(ProdutoViewModel produtoViewModel)
		{
			var imagemNome = Guid.NewGuid() + "-" + produtoViewModel.file.FileName;
			produtoViewModel.Imagem = imagemNome;


			var retornoArquivo = await ValidadorImages.UploadArquivo(produtoViewModel.file, imagemNome);

			if (!retornoArquivo.Status)
				throw new ApplicationException(retornoArquivo.Mensagem);

			_produtoRepository.Adicionar(_mapper.Map<Produto>(produtoViewModel));
		}

		public ProdutoViewModel ObterPorId(int id)
		{
			return _mapper.Map<ProdutoViewModel>(_produtoRepository.ObterPorId(id));
		}


		public IEnumerable<ProdutoViewModel> ObterTodos()
		{
			return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterTodos());
		}

		public void Atualizar (int id)
        {
			var produtoBusca = _produtoRepository.ObterPorId(id);

			if (produtoBusca == null)
				throw new ApplicationException("Produto não encontrado.");

			_produtoRepository.Atualizar(_mapper.Map<Produto>(produtoBusca));
		}
	}
}
