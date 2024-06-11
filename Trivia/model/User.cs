using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.model
{
    public class User
    {
        private int id { get; set; }
        private string name { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private int IsAdmin { get; set; }

        public User(int id, string name, string email, string password, int admin)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.IsAdmin = admin;
        }
    }
}
