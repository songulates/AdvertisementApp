using AutoMapper;
using BusinessLayer.Services;
using DataAccesLayer.UnitOfWork;
using DtosLayer;
using EntitiesLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IGenderService : IService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>
    {
    }
}
