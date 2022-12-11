using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public interface IResponse
    {
        string Message { get; set; }
        //enum respostype
        ResponseType ResponseType { get; set; }
    }
}
