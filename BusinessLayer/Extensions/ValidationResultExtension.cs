using CommonLayer;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Extensions
{
    public static class ValidationResultExtension
    {
        //burda validation resultu genişletiyoruz
        public static List<CustomValidationError> customValidationErrors(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            //foreach ile fluentvalidation errorslarında dönelim
            //errrorsa valdiation errordaki herbir hatayı ekleyelim
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage=error.ErrorMessage,
                    PropertyName=error.PropertyName,

                });
            }
            return errors;
        }
    }
}
