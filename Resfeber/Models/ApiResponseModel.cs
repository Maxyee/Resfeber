using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resfeber.Models
{
    public class ApiResponseModel
    {
        public string Message { get; set; }
        public ResponseCodes ResponseCode { get; set; }
        public object ResultPayload { get; set; }

        public enum ResponseCodes
        {
            Failed,
            Successful
        }
    }
}
