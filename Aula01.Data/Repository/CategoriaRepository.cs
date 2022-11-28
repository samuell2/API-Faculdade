using Aula01.Domain;
using Aula01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula01.Domain;
using Aula01.Domain.Enum;

namespace Aula01.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly GestaoProdutoContext _context;

        public CategoriaRepository(GestaoProdutoContext context)
        {
            _context = context;
        }
        public void Adicionar(Categoria categoria)
        {
            _context.CATEGORIA.Add(categoria);
            Gravar();
        }

        // public void Ativar(Categoria categoria)
        // {
        //     categoria.Ativar();
        //     _context.CATEGORIA.Update(categoria);
        //     Gravar();
        // }

        public void Atualizar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        // public void Inativar(Categoria categoria)
        // {
        //     categoria.Inativar();
        //     _context.CATEGORIA.Update(categoria);
        //     Gravar();
        // }

        public Categoria ObterPorId(int id)
        {
            return _context.CATEGORIA.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<Categoria> ObterTodosCategoria()
        {
            return _context.CATEGORIA;
        }
        // public void Remover(int id)
		// {
		// 	_context.Remove(id);
        //     Gravar();
        // }
		public void Gravar()
		{
			_context.SaveChanges();
		}
		public void Dispose()
		{
			_context.Dispose();
		}
    }
}