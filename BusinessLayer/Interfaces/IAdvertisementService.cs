using CommonLayer;
using DtosLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        //servise gidelim
        //aktif olan gett all gelcek sadece
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}
