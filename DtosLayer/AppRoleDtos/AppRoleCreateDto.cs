using DtosLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtosLayer.AppRoleDtos
{
    public class AppRoleCreateDto : IDtos
    {
        public string Definition { get; set; }
    }
}
