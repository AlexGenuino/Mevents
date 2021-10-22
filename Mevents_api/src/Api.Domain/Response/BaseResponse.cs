using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public abstract class BaseResponse
    {
        public BaseResponse(string message, bool success)
        {
            this.Message = message;
            this.Success = success;
        }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
