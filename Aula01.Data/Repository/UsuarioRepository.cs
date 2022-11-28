using Aula01.Domain;
using Aula01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Data.Repository
{
	public class UsuarioRepository : IUsuarioRepository
	{

		private readonly GestaoProdutoContext _context;

		public UsuarioRepository(GestaoProdutoContext context)
		{
			_context = context;
		}
		public Usuario Autenticar(Usuario usuario)
		{
		    
		    // var buscaUsuario = _context.USUARIO.Where(p => p.UserName == usuario.UserName 
            //                                     && p.Password == usuario.Password).FirstOrDefault();
            
            // if (buscaUsuario != null) return new Usuario(usuario.UserName, usuario.Password);
            
            
            
            if (usuario.UserName == "1235" 
                && usuario.Password == "1235")
            {
                return new Usuario(usuario.UserName, usuario.Password);
            }
            
            return _context.USUARIO.Where(p => p.UserName == usuario.UserName
                && p.Password == usuario.Password).FirstOrDefault();

            //return _context.Produto.Where(p => p.Id == id).FirstOrDefault();



			// if(usuario.UserName == "123456789"
			// 	&& usuario.Password == "123456789"
			// )
			// {
			// 	return new Usuario(usuario.UserName,
			// 	usuario.Password);
			// }
			
			// return _context.USUARIO.Where(p => p.UserName == usuario.UserName
			// 		  && p.Password == usuario.Password
			// ).FirstOrDefault();
		}

		public Usuario ObterPorId(int id)
		{
			return _context.USUARIO.Where(x => x.Id == id).FirstOrDefault();
		}

		public void Adicionar(Usuario usuario)
		{
			_context.USUARIO.Add(usuario);
			Gravar();
		}

		public void Atualizar(Usuario usuario)
		{
			_context.USUARIO.Update(usuario);
			Gravar();
		}

		public void Gravar()
		{
			_context.SaveChanges();
		}
	}
}
