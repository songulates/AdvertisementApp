using DtosLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IProvidedServiceService:IService<ProvidedServiceDtoCreate, ProvidedServiceDtoUpdate,ProvidedServicesDtoList,ProvidedService>
    {
        //ilgili interface i Iservicedeki metodları çağıracak şekilde yaptık.
    }
}
