using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Gender:BaseEntity
    {
        public string Definition { get; set; }
        //bir genderin birden çok useri olabilir
        public List<AppUser> AppUsers { get; set; }
    }
}
