using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class AdvertisementAppUserStatus:BaseEntity
    {
        public string Definition { get; set; }
        //statusda birden fazla appuser olabilir.
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
