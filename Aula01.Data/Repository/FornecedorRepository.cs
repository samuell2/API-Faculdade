using Aula01.Domain;
using Aula01.Domain.Enum;
using Aula01.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Data.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly GestaoProdutoContext _context;
        public FornecedorRepository(GestaoProdutoContext context)
        {
            _context = context;
        }

        public void Adicionar(Fornecedor fornecedor)
        {
            
           _context.FORNECEDOR.Add(fornecedor);
           Gravar();
        }

        // public void Ativar(Fornecedor fornecedor)
        // {
        //     fornecedor.Ativar();
        //     _context.FORNECEDOR.Update(fornecedor);
        //     Gravar();
        // }

        public void Atualizar(Fornecedor fornecedor)
        {
            _context.FORNECEDOR.Update(fornecedor);
            Gravar();
        }

        // public void Inativar(Fornecedor fornecedor)
        // {
        //      fornecedor.Inativar();
        //     _context.FORNECEDOR.Update(fornecedor);
        //     Gravar();
        // }

        public Fornecedor ObterPorId(int id)
        {
            return _context.FORNECEDOR.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Fornecedor> ObterTodosFornecedores()
        {
           return _context.FORNECEDOR.ToList();
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