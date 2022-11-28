using Aula01.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain
{
	public class Categoria : Entity
	{

        protected Categoria()
        {

        }

        public string Nome {get; set;}
        public bool Ativo {get; set;}
		public Categoria(string nome, bool ativo)
		{
			Nome = nome;
			Ativo = ativo;
		}

		public void Ativar()
		{
			Ativo = true;
		}
		public void Inativar()
		{
			Ativo = false;
		}
	}
}
