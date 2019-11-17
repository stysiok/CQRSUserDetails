using System.Threading.Tasks;
using CQRSUserDetails.Web.Infrastructure;
using CQRSUserDetails.Web.Application.UserDetails.Commands;
using CQRSUserDetails.Web.Application.UserDetails.Dtos;
using CQRSUserDetails.Web.Application.UserDetails.Queries;
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

        [HttpGet("{UserId}")]
        public async Task<ActionResult<UserDetailsDto>> Get([FromRoute]GetUserDetails query)
        {
            var data = await _dispatcher.QueryAsync(query);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddUserDetails command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
