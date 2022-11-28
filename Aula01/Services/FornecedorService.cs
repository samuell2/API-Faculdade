using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using AutoMapper;
using Aula01.Utilitarios;

namespace Aula01.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task Cadastrar(FornecedorViewModel fornecedor)
        {
            var imagemNome = Guid.NewGuid() + "-" + fornecedor.file.FileName;
            fornecedor.Imagem = imagemNome;


            var retornoArquivo = await ValidadorImages.UploadArquivo(fornecedor.file, imagemNome);

            if (!retornoArquivo.Status)
                throw new ApplicationException(retornoArquivo.Mensagem);

            _fornecedorRepository.Adicionar(_mapper.Map<Fornecedor>(fornecedor));
        }

        public FornecedorViewModel ObterPorId(int id)
        {
            var pesquisa = _mapper.Map<FornecedorViewModel>(_fornecedorRepository.ObterPorId(id));
            if (pesquisa == null) throw new ApplicationException("Fornecedor não encontrado.");
            return pesquisa;
        }

        public IEnumerable<FornecedorViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorRepository.ObterTodosFornecedores());
        }

        public void Atualizar(int id)
        {
            var fornecedorBusca = _fornecedorRepository.ObterPorId(id);

            if (fornecedorBusca == null)
                throw new ApplicationException("Fornecedor não encontrado.");

            _fornecedorRepository.Atualizar(_mapper.Map<Fornecedor>(fornecedorBusca));
        }
    }
}