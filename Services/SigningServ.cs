using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace mini_api.Services
{
    public class SigningServ : ISigningServ
    {
        private readonly X509Certificate2 _certificate;
        public SigningServ()
        {
            using var rsa = RSA.Create(2048);
            var certRequest = new CertificateRequest("cn=MyDemoCert", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            _certificate = certRequest.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));
        }
        public string SignData(string dataSign)
        {
            using var rsa = _certificate.GetRSAPrivateKey();
            var dataBytes = Encoding.UTF8.GetBytes(dataSign);
            var signatureBytes = rsa.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return Convert.ToBase64String(signatureBytes);
        }
        public bool VerifyData(string originalData, string signature)
        {
            try
            {
                using var rsa = _certificate.GetRSAPublicKey();
                var dataBytes = Encoding.UTF8.GetBytes(originalData);
                var signatureBytes = Convert.FromBase64String(signature);
                return rsa.VerifyData(dataBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
   