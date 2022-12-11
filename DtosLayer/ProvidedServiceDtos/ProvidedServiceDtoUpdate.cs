﻿using DtosLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtosLayer
{
    public class ProvidedServiceDtoUpdate:IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
        //bu dtolara sonrasında validationrullar yazmak lazım.
    }
}
