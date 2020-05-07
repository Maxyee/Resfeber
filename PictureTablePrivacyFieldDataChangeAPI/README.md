### Logic File which will changed the value from database.

```cs
[System.Web.Mvc.HttpPost]
[System.Web.Http.Route("yourroute/{userId}/{pictureId}/{privacy}")]
public IHttpActionResult YourMethodName(string userId, int pictureId, string privacy)
{

    var response = new ApiResponseModel();

    ApplicationUser appUser = _context.Users.FirstOrDefault(w => w.Id == userId);

    try
    {
        var changePicturePrivacy = _context.Pictures.FirstOrDefault(x => x.User_Id == appUser.Id && x.Id == pictureId);

        if (changePicturePrivacy != null)
        {
            changePicturePrivacy.Privacy = privacy;
            _context.Entry(changePicturePrivacy).State = EntityState.Modified;
            _context.SaveChanges();


            response.ResponseCode = ResponseCodes.Successful;
            response.ResultPayload = new
            {
                res = true,
                msg = "Picture Privacy Changed to " + privacy
            };
            return Ok(response);
        }
        else
        {
            response.ResponseCode = ResponseCodes.Failed;
            response.ResultPayload = new
            {
                res = false,
                msg = "No User or PictureId Found into the Database"
            };
            return Ok(response);
        }
       
    }
    catch (Exception ex)
    {
        return InternalServerError(ex);
    }
}

```

### Customized Response for giving JSON response to the client end

```cs
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
        public object ResultPayload { get; set; }
    }

    public enum ResponseCodes
    {
        Failed, 
        Successful
    }
}

```
