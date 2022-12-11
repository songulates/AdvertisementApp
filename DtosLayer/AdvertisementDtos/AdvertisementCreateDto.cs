using DtosLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtosLayer/*.AdvertisementDtos*/
{
   public class AdvertisementCreateDto:IDtos
    {
        public string Title { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }
    }
}
