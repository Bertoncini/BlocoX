using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BlocoX.Utils
{
    public class Config
    {
        public static KeyValuePair<string, string> localSenhaCertificado = new KeyValuePair<string, string>();
        public static X509Certificate2 Certificado
        {
            get
            {
                if (string.IsNullOrWhiteSpace(localSenhaCertificado.Key))
                    throw new InvalidOperationException("Não foi informado o local do Certificado");

                if (string.IsNullOrWhiteSpace(localSenhaCertificado.Value))
                    throw new InvalidOperationException("Não foi informado a senha do Certificado");

                return new X509Certificate2(localSenhaCertificado.Key, localSenhaCertificado.Value);
            }
        }
    }
}
