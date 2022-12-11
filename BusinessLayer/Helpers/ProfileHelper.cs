using AutoMapper;
using BusinessLayer.Mappings.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
   public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        //get profiles service içinden cağırcaz
        //genişletme yyok  DExtenction üzerinden getprofile çağır
        {
            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile(),
                new AdvertisementAppUserProfile(),
                new AdvertisementAppUserStatusProfile(),
                new MilitaryStatusProfile(),
                //    var mapper = mapperconfiguration.CreateMapper();
                ////mapperi servislere ekliyoruz.
                //    services.AddSingleton(mapper);
            };
            //mapper üretelim  
        }
    }
}
