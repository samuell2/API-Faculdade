using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using AutoMapper;
using Aula01.Utilitarios;

using Microsoft.AspNetCore.Mvc;

namespace Aula01.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, 
            IMapper mapper
        )
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task Cadastrar(CategoriaViewModel categoria)
        {
            _categoriaRepository.Adicionar(_mapper.Map<Categoria>(categoria));
        }

        public CategoriaViewModel ObterPorId(int id)
        {
            var pesquisa = _mapper.Map<CategoriaViewModel>(_categoriaRepository.ObterPorId(id));
            if (pesquisa == null) throw new ApplicationException("Categoria não encontrado.");
            return pesquisa;
        }

        public IEnumerable<CategoriaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaRepository.ObterTodosCategoria());
        }

        public void Atualizar(int id)
        {
            var categoriaBusca = _categoriaRepository.ObterPorId(id);

            if (categoriaBusca == null)
                throw new ApplicationException("Categoria não encontrado.");

            _categoriaRepository.Atualizar(_mapper.Map<Categoria>(categoriaBusca));
        }
    }
}