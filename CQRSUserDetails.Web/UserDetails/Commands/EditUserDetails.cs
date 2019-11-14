using CQRSUserDetails.Web.Infrastructure;

namespace CQRSUserDetails.Web.UserDetails.Commands
{
    public class EditUserDetails : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int Phonenumber { get; set; }
    }
}