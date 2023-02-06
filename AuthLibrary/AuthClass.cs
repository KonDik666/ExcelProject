using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentsExampleApp.Model;

namespace AuthLibrary
{
    public class AuthClass
    {

        public int UsersCount()
        {
            Core bd = new Core();
            var allUsers = bd.context.Users.ToList();
            int count = allUsers.Count();
            return count;
        }
        public string[] userLogins() {
            Core bd = new Core();
            var allUsers = bd.context.Users.ToList();
            string[] logins = new string[allUsers.Count()];
            for (int i = 0; i < allUsers.Count();i++)
            {
                logins[i] = allUsers[i].login;
            }
            return logins;
        }
        public string[] userPasswords()
        {
            Core bd = new Core();
            var allUsers = bd.context.Users.ToList();
            string[] passwords = new string[allUsers.Count()];
            for (int i = 0; i < allUsers.Count(); i++)
            {
                passwords[i] = allUsers[i].password;
            }
            return passwords;
        }

        public int CorrectLoginPasswordCount(string cLogin, string cPassword)
        {
            int countRec = 0;
            for (int i = 0; i < UsersCount(); i++)
            {
                if (cLogin == userLogins()[i] && cPassword == userPasswords()[i])
                {
                    countRec++;
                }
            }
            return countRec;
        }
    }
}
