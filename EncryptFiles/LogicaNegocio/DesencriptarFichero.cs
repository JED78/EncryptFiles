using EncryptFiles.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptFiles.LogicaNegocio
{
    public class DesencriptarFichero
    {

        public void Desencriptar(Fichero fichero)
        {
            using (var fsIn = new FileStream(fichero.RutaOrigen, FileMode.Open))
            {
                byte[] salt = new byte[32];
                byte[] iv = new byte[16];

                fsIn.Read(salt, 0, salt.Length);
                fsIn.Read(iv, 0, iv.Length);

                using (var aes = Aes.Create())
                {
                    var key = new Rfc2898DeriveBytes(fichero.Contrasena, salt, 100_000);
                    aes.Key = key.GetBytes(32);
                    aes.IV = iv;

                    using (var cs = new CryptoStream(fsIn, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (var fsOut = new FileStream(fichero.RutaDestino, FileMode.Create))
                    {
                        cs.CopyTo(fsOut);
                    }
                }
            }
        }

    }
}
