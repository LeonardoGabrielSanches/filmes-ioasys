using System.Text;

namespace FilmesIoasys.Dominio.Services
{
    public static class Criptografia
    {
        const string criptoHash = "d41d8cd98f00b204e9800998ecf8427e";
        const string formato = "x2";

        public static string CriptografarSenha(string senha)
        {
            var md5Cripto = System.Security.Cryptography.MD5.Create();
            var senhaCriptografada = new StringBuilder();

            senhaCriptografada.Clear();
            var hash = md5Cripto.ComputeHash(Encoding.Default.GetBytes(senha + criptoHash));

            foreach (var h in hash)
                senhaCriptografada.Append(h.ToString(formato));

            return senhaCriptografada.ToString();
        }

        public static bool VerificarSenha(string senha, string senhaCriptografada)
        {
            string senhaComparar = CriptografarSenha(senha);

            return senhaComparar == senhaCriptografada;
        }
    }
}