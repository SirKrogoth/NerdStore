using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(p => new Produto(p.nome, p.descricao, p.ativo, p.valor, p.categoriaId, p.dataCadastro,
                    p.imagem, new Dimensoes(p.altura, p.largura, p.profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
