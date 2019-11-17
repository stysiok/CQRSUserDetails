using CQRSUserDetails.Web.Infrastructure;
using CQRSUserDetails.Web.Application.UserDetails.Dtos;

namespace CQRSUserDetails.Web.Application.UserDetails.Queries
{
    public class GetUserDetails : IQuery<UserDetailsDto>
    {
        public int UserId { get; set; }
    }
}