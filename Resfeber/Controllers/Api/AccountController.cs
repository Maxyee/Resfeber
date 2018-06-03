using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resfeber.Models;
using System.Web.Http;
using System.Net.Http;
namespace Resfeber.Controllers.Api
{
    [Produces("application/json")]
    [System.Web.Http.Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public AccountController()
        {

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public async Task<IHttpActionResult> Register(Account model)
        {
            var listError = new ArrayList();
            var user = new Account
            {
                Name = model.Name,
                Email = model.Email,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Location = model.Location
            };


            if(user.Name == null)
            {
                var response = new ApiResponseModel();
                response.Message = "You missed to insert your Name";
                response.ResultPayload = new
                {
                    result = false
                };
                return Ok(response);
                //var response = new ApiResponseModel();
                //response.ResultPayload = 
                //return returtype;
            }
            else if(user.Email == null)
            {

            }
            else if(user.Gender == null)
            {

            }
            else if(user.PhoneNumber == null)
            {

            }
            else if(user.Password == null)
            {

            }
            else if(user.Location == null)
            {

            }
            else
            {

            }
            return null;
        }

        
    }
}