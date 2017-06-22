using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Models
{
    public class RegistrationUser
    {
        public string userName;

        private string email;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MaritalStatus { get; set; }

        public string Hobbys { get; set; }

        public string Country { get; set; }

        public string BirthMonth { get; set; }

        public string BirthDay { get; set; }

        public string BirthYear { get; set; }

        public string Phone { get; set; }

        public string UserName
        {
            get { return this.userName; }
            set
            {
                if (value != null)
                {
                    this.userName = DateTime.Now.Millisecond + value;
                }
                else
                {
                    this.userName = string.Empty;
                }
            }
        }
        
        public string Email
        {
            get { return this.email; }
            set
            {
                if (value != null)
                {
                    this.email = DateTime.Now.Millisecond + value;
                }
                else
                {
                    this.email = string.Empty;
                }
            }
        }
        public string Picture { get; set; }

        public string Description { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorLocator { get; set; }
    }
}
