using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class Helper
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var emailAddress = new System.Net.Mail.MailAddress(email);
                return emailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPassword(string password)
        {
            if (password.Length > 5)
                return true;
            return false;
        }

        public bool EmailExistsInDatabase(string userEmail) {
            MovieDBModel db = new MovieDBModel();
            foreach (var mail in db.Users.Select(e => e.AccountEmail))
                if (userEmail == mail)
                    return true;
            return false;
        }

        public bool PasswordExistsInDatabase(string userPassword)
        {
            MovieDBModel db = new MovieDBModel();
            foreach (var password in db.Users.Select(e => e.AccountPassword))
                if (userPassword == password)
                    return true;
            return false;
        }

        public string PasswordHashAndSalt (string password)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[8];
            rng.GetBytes(buff);
            string salt = Convert.ToBase64String(buff);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
            System.Security.Cryptography.SHA256Managed hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", string.Empty);             
        }
    }
}