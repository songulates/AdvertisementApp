using AutoMapper;
using DtosLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappings.AutoMapper
{
    public class ProvidedServiceProfile:Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceDtoCreate, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServicesDtoList, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceDtoUpdate, ProvidedService>().ReverseMap();
        }
    }
}
