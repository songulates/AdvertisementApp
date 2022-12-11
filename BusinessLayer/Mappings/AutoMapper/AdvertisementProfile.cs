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
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            //Advertisement ı AdvertisementListDto ya cevir. reversemaple tersinide yapabil
            CreateMap<Advertisement, AdvertisementListDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementCreateDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap();
            //sonra dependency extensiona ekle AdvertisementProfile
        }
    }
}
