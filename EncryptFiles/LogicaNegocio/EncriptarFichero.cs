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
    public class EncriptarFichero
    {
        #region Funciones Públicas
        /// <summary>
        /// Función que encripta el fichero seleccionado
        /// </summary>
        /// <param name="rutaOrigen">Fichero seleccionado para encriptar</param>
        /// <param name="rutaDestino">Ruta destino donde se desencriptara el fichero</param>
        /// <param name="contrasena">Contraseña</param>
        public void Encriptar(Fichero fichero)
        {
            byte[] salt = GenerarBytesAleatorios(32);
            using (var aes = Aes.Create())
            {
                var key = new Rfc2898DeriveBytes(fichero.Contrasena, salt, 100_000);
                aes.Key = key.GetBytes(32); // 256 bits
                aes.IV = GenerarBytesAleatorios(16); // 128 bits

                using (var fsOut = new FileStream(fichero.RutaDestino, FileMode.Create))
                {
                    fsOut.Write(salt, 0, salt.Length); // Guardar salt
                    fsOut.Write(aes.IV, 0, aes.IV.Length); // Guardar IV

                    using (var cs = new CryptoStream(fsOut, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var fsIn = new FileStream(fichero.RutaOrigen, FileMode.Open))
                    {
                        fsIn.CopyTo(cs);
                    }
                }
            }
        }

        #endregion

        #region Funciones Privadas
        /// <summary>
        /// Función que genera Byter aleatorios 
        /// </summary>
        /// <param name="longitud">Longitud de los bytes</param>
        /// <returns>Bytes aleatorioss</returns>
        private byte[] GenerarBytesAleatorios(int longitud)
        {
            var bytes = new byte[longitud];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return bytes;
        }

        #endregion
    }
}
