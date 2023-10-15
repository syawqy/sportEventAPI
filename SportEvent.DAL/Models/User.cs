using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.DAL.Models
{
    public class User : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
