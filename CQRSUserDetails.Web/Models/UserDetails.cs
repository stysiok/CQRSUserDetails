using System;

namespace CQRSUserDetails.Web.Models
{
    public class UserDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public DateTime CreationDate { get; set; }
    }
}