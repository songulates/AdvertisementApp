using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UILayer.Extensions;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService)
        {
            _providedServiceService = providedServiceService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedServiceService.GetAllAsync();
            return this.ResponseView(response);
            //ilgili data dönecek
        }
        public async Task<IActionResult> HumanResource()
        {
            var response = await _advertisementService.GetActivesAsync();
            return this.ResponseView(response);
           
        }
        //not önce dto oluştur sonra dto validaition ruller,  extension kısmına kaydet,,mapper oluştur,mapperi  extensionda yaz,
        //interface oluştur,uıda kullan
    }
}
