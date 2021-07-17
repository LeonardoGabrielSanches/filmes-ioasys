using System.Text;

namespace MoviesIoasys.Domain.Provider
{
    public static class EncryptProvider
    {
        const string criptoHash = "d41d8cd98f00b204e9800998ecf8427e";
        const string format = "x2";

        public static string EncryptPassword(string password)
        {
            var md5Cripto = System.Security.Cryptography.MD5.Create();
            var encryptedPassowrd = new StringBuilder();

            encryptedPassowrd.Clear();
            var hash = md5Cripto.ComputeHash(Encoding.Default.GetBytes(password + criptoHash));

            foreach (var h in hash)
                encryptedPassowrd.Append(h.ToString(format));

            return encryptedPassowrd.ToString();
        }

        public static bool ComparePassword(string password, string encryptedPassword)
        {
            string passwordToCompare = EncryptPassword(password);

            return passwordToCompare == encryptedPassword;
        }
    }
}
