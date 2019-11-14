using System.Threading.Tasks;
using CQRSUserDetails.Web.Infrastructure;
using CQRSUserDetails.Web.UserDetails.Commands;
using CQRSUserDetails.Web.UserDetails.Dtos;
using CQRSUserDetails.Web.UserDetails.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSUserDetails.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDetailsController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public UserDetailsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;   
        }

        [HttpGet]
        public async Task<ActionResult<UserDetailsDto>> Get([FromRoute]GetUserDetails query)
        {
            var data = await _dispatcher.QueryAsync(query);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EditUserDetails command)
        {
            await _dispatcher.SendAsync(command);

            return Ok();
        }
    }
}
