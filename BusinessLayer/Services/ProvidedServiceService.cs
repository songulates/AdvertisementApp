using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccesLayer.UnitOfWork;
using DtosLayer;
using EntitiesLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ProvidedServiceService : Service<ProvidedServiceDtoCreate, ProvidedServiceDtoUpdate, ProvidedServicesDtoList, ProvidedService>, IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper,IValidator<ProvidedServiceDtoCreate> createdtovalidator, IValidator<ProvidedServiceDtoUpdate> updatetovalidator,IUow uow) :base(mapper, createdtovalidator, updatetovalidator,uow)
        {

        }
    }
}
