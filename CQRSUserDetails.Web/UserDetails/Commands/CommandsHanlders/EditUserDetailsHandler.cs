using System.Threading.Tasks;
using CQRSUserDetails.Web.Infrastructure;

namespace CQRSUserDetails.Web.UserDetails.Commands.CommandsHandlers
{
    public class EditUserDetailsHandler : ICommandHandler<EditUserDetails>
    {
        public EditUserDetailsHandler()
        {
            
        }

        public Task HandleAsync(EditUserDetails command)
        {
            throw new System.NotImplementedException();
        }
    }
}