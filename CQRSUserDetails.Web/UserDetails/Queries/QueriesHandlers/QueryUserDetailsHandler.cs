using System.Threading.Tasks;
using CQRSUserDetails.Web.Infrastructure;
using CQRSUserDetails.Web.UserDetails.Dtos;

namespace CQRSUserDetails.Web.UserDetails.Queries.Handlers 
{
    public class QueryUserDetailsHandler : IQueryHandler<GetUserDetails, UserDetailsDto>
    {
        public QueryUserDetailsHandler()
        {
            
        }

        public Task<UserDetailsDto> HadnleQuery(GetUserDetails query)
        {
            throw new System.NotImplementedException();
        }
    }
}