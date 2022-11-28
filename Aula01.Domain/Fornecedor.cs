using Aula01.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula01.Domain;
using System.Security.Cryptography.X509Certificates;

namespace Aula01.Domain
{
	public class Fornecedor : Entity      
	{
		protected Fornecedor()
		{

		}
		public string Imagem { get; set; }
		public string Nome { get; private set; }
		public EnumTipoFornecedor TIPO_FORNECEDOR { get; set; }
		public string Documento { get; private set; }
		public bool Ativo { get; set; }
		public Fornecedor(string nome, EnumTipoFornecedor tipoFornecedor, string documento, bool ativo, string imagem)
		{
			Nome = nome;
			TIPO_FORNECEDOR = tipoFornecedor;
			Documento = documento;
			Ativo = ativo;
			Imagem = imagem;
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
