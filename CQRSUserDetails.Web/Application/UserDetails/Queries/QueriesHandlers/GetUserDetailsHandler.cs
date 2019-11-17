using System.Linq;
using System.Threading.Tasks;
using CQRSUserDetails.Web.Core;
using CQRSUserDetails.Web.Infrastructure;
using CQRSUserDetails.Web.Application.UserDetails.Dtos;

namespace CQRSUserDetails.Web.Application.UserDetails.Queries.Handlers
{
    public class GetUserDetailsHandler : IQueryHandler<GetUserDetails, UserDetailsDto>
    {
        private readonly UserDetailsContext _context;

        public GetUserDetailsHandler(UserDetailsContext context)
        {
            _context = context;
        }

        public Task<UserDetailsDto> HandleAsync(GetUserDetails query)
        {
            var userDetails = _context.UserDetails.FirstOrDefault(u => u.Id == query.UserId);

            var userDetailsDto = new UserDetailsDto
            {
                Id = userDetails.Id,
                Email = userDetails.EmailAddress,
                FullName = $"{userDetails.Name} {userDetails.Surname}"
            };

            return Task.FromResult(userDetailsDto);
        }
    }
}