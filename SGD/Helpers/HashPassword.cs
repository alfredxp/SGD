using BCrypt.Net;
namespace SGD.Helpers
{
    public class HashPassword
    {
         private readonly string _password;

        public HashPassword(string password)
        {
            _password = password;
        }

        public string Hash() => BCrypt.Net.BCrypt.HashPassword(_password);
        public bool PasswordVerify(string hashedPasswordFromDatabase) => BCrypt.Net.BCrypt.Verify(_password, hashedPasswordFromDatabase);
    }
}
