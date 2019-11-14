using CQRSUserDetails.Web.Infrastructure;
using CQRSUserDetails.Web.UserDetails.Dtos;

namespace CQRSUserDetails.Web.UserDetails.Queries
{
    public class GetUserDetails : IQuery<UserDetailsDto>
    {
        public int UserId { get; set; }
    }
}