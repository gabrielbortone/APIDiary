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
            CreateMap<DateTime, DataHoraDTO>().ReverseMap();
            CreateMap<Imagem, ImagemDTO>().ReverseMap();
        }
    }
}
