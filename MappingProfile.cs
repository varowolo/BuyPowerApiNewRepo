using AutoMapper;
using BuyPowerApiNew.DataTransferObjects;
using BuyPowerApiNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyPowerApiNew
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserForRegistrationDto, User>();

        }

    }
}
