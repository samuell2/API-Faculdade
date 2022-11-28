using Aula01.Domain;
using Aula01.Domain.Enum;
using Aula01.Model;
using AutoMapper;

namespace Aula01.Mapper
{
	public class ApplicationToDomain : Profile
	{
		public ApplicationToDomain()
		{
			CreateMap<ProdutoViewModel, Produto>()
			   .ConstructUsing(q => new Produto(q.Nome, q.Preco, q.Estoque, q.Imagem, q.ForadeLinha));

			CreateMap<FornecedorViewModel, Fornecedor>()
				.ConstructUsing(f => new Fornecedor(f.Nome, f.tipoFornecedor, f.Documento, f.Ativo, f.Imagem));

			CreateMap<CategoriaViewModel, Categoria>()
				.ConstructUsing(c => new Categoria(c.Nome, c.Ativo));

			CreateMap<FreteViewModel, Frete>()
				.ConstructUsing(f => new Frete(f.UF, f.Peso, f.EhQuebravel));

			CreateMap<UsuarioViewModel, Usuario>()
			   .ConstructUsing(q => new Usuario(q.UserName, q.Password));
		}
	}
}

