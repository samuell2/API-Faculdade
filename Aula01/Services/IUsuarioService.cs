using Aula01.Model;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Services
{
    public interface IUsuarioService
    {
        public Task<ActionResult<dynamic>> Authenticate(UsuarioViewModel usuario);
        public Task Cadastrar(UsuarioViewModel usuario);
        public void Atualizar(int id);
        public UsuarioViewModel ObterPorId(int id);
    }
}