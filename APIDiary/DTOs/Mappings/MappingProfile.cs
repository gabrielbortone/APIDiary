using APIDiary.Models;
using APIDiary.Models.ValueType;
using AutoMapper;
using System;

namespace APIDiary.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entrada, EntradaDTO>().ReverseMap();
            CreateMap<DataHoraDTO, DateTime>();
            CreateMap<Imagem, ImagemDTO>().ReverseMap();
        }
    }
}
