using CQRSUserDetails.Web.Infrastructure;

namespace CQRSUserDetails.Web.Application.UserDetails.Commands
{
    public class AddUserDetails : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }
}