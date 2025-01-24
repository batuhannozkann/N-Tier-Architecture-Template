using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class ResponseDto<T>
        where T : class
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public List<string>? Errors { get; set; }
    }
    public class ResponseDtoWithoutData
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public List<string>? Errors { get; set; }
    }
}
