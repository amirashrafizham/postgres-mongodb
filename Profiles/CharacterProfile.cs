using System;
using AutoMapper;
using temp_api.DTOs;
using temp_api.Models;

namespace temp_api.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<AddCharacterDTO, Character>();
        }
    }
}
