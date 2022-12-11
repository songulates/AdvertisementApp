using CommonLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Extensions
{
    public static class ControllerExtensions
    {
        //responsview yapısını oluşturcaz
        //controller klası extend edilecek
        public static IActionResult ResponseRedirectAction<T>(this Controller controller,IResponse<T> response,string actionname, string controllerName="")
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return controller.RedirectToAction(actionname);
            }
            else
            {
                return controller.RedirectToAction(actionname, controllerName);
            }
                
        }
        //bir datayı getirme durumumuz var
        public static IActionResult ResponseView<T>(this Controller controller,IResponse<T> response)
        {
            if(response.ResponseType==ResponseType.NotFound)
                return controller.NotFound();
            return controller.View(response.Data);
        }
        //T opsiyonunu taşımyan yani generic olmayanı,
        public static IActionResult ResponseRedirectAction(this Controller controller, IResponse response, string actionname)
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            return controller.RedirectToAction(actionname);
        }
    }
}
