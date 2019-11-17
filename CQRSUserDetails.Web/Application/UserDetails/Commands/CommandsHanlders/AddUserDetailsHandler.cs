using System;
using System.Linq;
using System.Threading.Tasks;
using CQRSUserDetails.Web.Core;
using CQRSUserDetails.Web.Infrastructure;

namespace CQRSUserDetails.Web.Application.UserDetails.Commands.CommandsHandlers
{
    public class AddUserDetailsHandler : ICommandHandler<AddUserDetails>
    {
        private readonly UserDetailsContext _context;

        public AddUserDetailsHandler(UserDetailsContext context)
        {
            _context = context;
        }

        public Task HandleAsync(AddUserDetails command)
        {
            var userDetails = new Models.UserDetails
            {
                CreationDate = DateTime.Now,
                EmailAddress = command.EmailAddress,
                Name = command.Name,
                Surname = command.Surname,
                Id = 3
            };

            _context.UserDetails.Add(userDetails);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}