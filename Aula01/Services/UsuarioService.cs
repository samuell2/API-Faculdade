using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using AutoMapper;
using Aula01.Utilitarios;
using Aula01.Token;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<dynamic>> Authenticate(UsuarioViewModel usuario)
        {
            // Recupera o usuário
            var buscaUsuario = _usuarioRepository.Autenticar(_mapper.Map<Usuario>(usuario));

            // Verifica se o usuário existe
            if (buscaUsuario == null)
                throw new ApplicationException("Usuário não existe e/ou Senha inválida!");

            // Gera o Token
            var token = TokenService.GenerateToken(buscaUsuario);

            return new
            {
                message = "Login efetuado com sucesso"
                             ,
                token
            };

            // // Oculta a senha
            buscaUsuario.Password = "";
        }

        public async Task Cadastrar(UsuarioViewModel usuario)
        {
            _usuarioRepository.Adicionar(_mapper.Map<Usuario>(usuario));
        }

        public void Atualizar(int id)
        {
            var categoriaBusca = _usuarioRepository.ObterPorId(id);

            if (categoriaBusca == null)
                throw new ApplicationException("Usuario não encontrado.");

            _usuarioRepository.Atualizar(_mapper.Map<Usuario>(categoriaBusca));
        }

        public UsuarioViewModel ObterPorId(int id)
        {
            return _mapper.Map<UsuarioViewModel>(_usuarioRepository.ObterPorId(id));
        }
    }
}