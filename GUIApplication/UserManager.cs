using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIApplication
{
    public class UserManager
    {
        private Dictionary<string, string> Users; 

        public UserManager()//class to keep track of all users 
        {
            
            Users = new Dictionary<string, string>
            {
                { "user1", "password1" },
                { "user2", "password2" },
                
            };
        }

        public bool Login(string username, string password)//check if user and password are correct
        {
            
            if (Users.ContainsKey(username) && Users[username] == password)
            {
                return true; 
            }
            return false; 
        }
    }
}
