using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappings.AutoMapper;
using BusinessLayer.Services;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Context;
using DataAccesLayer.UnitOfWork;
using DtosLayer;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolvers.Microsoft
{//ekstension yazıp database migrate edip ayağa kaldıralım
    //microsoftun DI ı kullanılıyo
    //extension clas veya metod yazarken static olması lazım.IServiceCollection genişletiliyo
    //asağdaki metodda static olcak
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
            //automapper kütüphanesi eklendi,
            //mapper conf nesnesi var ve bundan örnek alıyoruz.
           
            //bu sayede DI da mapperı ele alabiliyıruz.
            //IUOW gördüğün zaman bize uow ver 
            services.AddScoped<IUow, Uow>();
            services.AddTransient<IValidator<ProvidedServiceDtoCreate>, ProvidedCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceDtoUpdate>, ProvidedServiceUpdateDtoValidator>();
           
            //userde kaydetme yaparken genderde isteyeceğğiz
            //sonra uı a gidelim
            //dto ve validatordan sonra extensionları yaz
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();
            //sonra servicesler yazılcak provided service profile olan yere auto mapperde advertisemen için oluştur
            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
            //IGenderService gördüğünde GenderServicei örnekle
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();


        }
        

    }
}
