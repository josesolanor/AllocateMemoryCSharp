using AutoMapper;
using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Block, BlockDTO>();
            CreateMap<Process, ProcessDTO>();
        }
    }
}
