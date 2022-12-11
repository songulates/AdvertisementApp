using DtosLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtosLayer
{
    public class GenderListDto : IDtos
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
