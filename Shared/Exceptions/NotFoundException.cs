using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public ResponseDtoWithoutData ExceptionResponse { get; set; }
        public NotFoundException(string message) : base(message)
        {
            ExceptionResponse = new ResponseDtoWithoutData();
            ExceptionResponse.IsSuccess = false;
            ExceptionResponse.Message = Message;
            ExceptionResponse.StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}
