using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace your.name.space
{
    public class ApiResponseModel
    {
        public string Message { get; set; }
        public ResponseCodes ResponseCode { get; set; }
        //object representation of the newly created resource
        public object ResultPayload { get; set; }

        //this line added by julhas
        //public object ResultSideSectionPayload { get; set; }
    }

    //this is for custom use as sometimes, the regular HTTP status codes do not capture subtle differences in responses that should be returned
    public enum ResponseCodes
    {
        Failed, 
        Successful
    }
}