using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
   public class Advertisement:BaseEntity
    {
        //bir kullanıcı birden fazla ilana basvurabilir,bir iilanın birden fazla useri olabilr
        public string Title { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
