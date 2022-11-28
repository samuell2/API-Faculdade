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
	public class ProdutoRepository : IProdutoRepository
	{
		private readonly GestaoProdutoContext _context;

		public ProdutoRepository(GestaoProdutoContext context)
		{
			_context = context;
		}

		public void Adicionar(Produto produto)
		{
			_context.PRODUTO.Add(produto);
			Gravar();
		}

		public void Atualizar(Produto produto)
		{
			_context.PRODUTO.Update(produto);
            Gravar();
        }

		public Produto ObterPorId(int id)
		{
			return _context.PRODUTO.Where(x => x.Id == id).FirstOrDefault();
		}

		// public Produto ObterProdutoName(string name)
		// {
        //     return _context.PRODUTO.Where(x => x.Nome == name).FirstOrDefault();
        // }

		public IEnumerable<Produto> ObterTodos()
		{
			return _context.PRODUTO.ToList();
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
