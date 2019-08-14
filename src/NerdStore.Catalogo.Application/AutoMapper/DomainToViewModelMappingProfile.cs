using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(d => d.largura, o => o.MapFrom(s => s.dimensoes.largura))
                .ForMember(d => d.altura, o => o.MapFrom(s => s.dimensoes.altura))
                .ForMember(d => d.profundidade, o => o.MapFrom(s => s.dimensoes.profundidade));

            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
