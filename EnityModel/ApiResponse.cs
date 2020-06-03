
using System.Collections.Generic;


namespace EnityModel
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse()
        {
            Success = true;
            Errors = new List<string>();
        }
        public T Data { set; get; }
        public bool Success { set; get; }
        public List<string> Errors { set; get; }
    }
}
