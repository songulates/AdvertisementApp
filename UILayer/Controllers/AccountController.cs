using AutoMapper;
using BusinessLayer.Interfaces;
using CommonLayer.Enums;
using DtosLayer;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UILayer.Extensions;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IValidator<AppUserLoginDto> _appuserlogindto;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserService, IMapper mapper, IValidator<AppUserLoginDto> appuserlogindto)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserService = appUserService;
            _mapper = mapper;
            _appuserlogindto = appuserlogindto;
        }

        //user create işlemi yapılacak
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel
            {
                Genders = new SelectList(response.Data,"Id","Definition")
            };
            //boşbir usercreatemodeli geriye dönüyoruz
           
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result=_userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                //member kayıt 2
                //2 yi bilmek için enum oluştru
                //user role ile oluşturuluyo
                var createresponse = await _appUserService.CreateWithRoleAsync(dto,(int)RoleType.Member);
                return this.ResponseRedirectAction(createresponse, "SignIn");
                //sonra authentication-authorizationa baktık
                
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
             model.Genders = new SelectList(response.Data, "Id", "Definition",model.GenderId);
            
             return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        //service de appuserlogindto olan metoda ihtiyac var
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType == CommonLayer.ResponseType.Success)
            {
                var roleResult = await _appUserService.GetRolesByUserIdAsync(result.Data.Id);
                // ilgili kullanıcının rollerini çekmemiz.
                var claims = new List<Claim>();

                if (roleResult.ResponseType == CommonLayer.ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                }

                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Kullanıcı adı veya şifre hatalı", result.Message);
            return View(dto);
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
