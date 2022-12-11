using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    //response T IResponse<T> den imlemente edilmeli
    public class Response<T> : Response, IResponse<T>
    {
        //NOT FOUNDLA birlikte ilgili ürün bulunamadı demek istiyoruz.
        public T Data { get; set; }
        //T tipinden data alıyoruz.

        public List<CustomValidationError> ValidationErrors { get; set; }
        public Response(ResponseType responseType, string message) : base(responseType, message)
        {

        }

        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }
        //busines ile ilgili işlem validasyon hatalarına yol açabilir bu hataları geri dönmek lazım.
        public Response(T data, List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            //validation error type responsevalidationerrordur.
            //ValidationErrors a errorsu verebiliriz.
            ValidationErrors = errors;
            Data = data;
        }
    }
}
