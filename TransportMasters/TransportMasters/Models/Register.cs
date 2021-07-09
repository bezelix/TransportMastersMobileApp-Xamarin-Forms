using System;
using System.Collections.Generic;
using System.Text;

namespace TransportMasters.Models
{
    class Register
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int AccountBalance { get; set; }
        public int Level { get; set; }
        public int PremiumPoints { get; set; }
    }
}
