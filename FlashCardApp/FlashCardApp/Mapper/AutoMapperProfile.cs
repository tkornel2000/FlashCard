using AutoMapper;
using FlashCardApp.Dtos;
using FlashCardApp.Models;

namespace Stock_Manager_Simulator_Backend.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CardDto, Card>();

        }
    }
}
