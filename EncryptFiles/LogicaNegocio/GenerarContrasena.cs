using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptFiles.LogicaNegocio
{
    public class GenerarContrasena
    {
        #region Constantes
        const string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string minusculas = "abcdefghijklmnopqrstuvwxyz";
        const string numeros = "0123456789";
        const string simbolos = "!@#$%^&*()_-+=<>?";
        #endregion

        #region Funciones Públicas
        /// <summary>
        /// Función para generar una contraseña segura.
        /// </summary>
        /// <param name="longitud">Longitud de la contraseña</param>
        /// <returns>Devuelve contraseña</returns>
        /// <exception cref="ArgumentException"></exception>
        public string GenerarContrasenaSegura(int longitud)
        {
            if (longitud < 4)
                throw new ArgumentException("La longitud debe ser al menos 4 para incluir todos los tipos de caracteres.");

            string todos = mayusculas + minusculas + numeros + simbolos;
            StringBuilder contraseña = new StringBuilder();

            // Asegurar al menos un carácter de cada tipo
            contraseña.Append(ObtenerCaracterAleatorio(mayusculas));
            contraseña.Append(ObtenerCaracterAleatorio(minusculas));
            contraseña.Append(ObtenerCaracterAleatorio(numeros));
            contraseña.Append(ObtenerCaracterAleatorio(simbolos));

            // Rellenar el resto
            for (int i = 4; i < longitud; i++)
            {
                contraseña.Append(ObtenerCaracterAleatorio(todos));
            }

            // Mezclar los caracteres
            return new string(contraseña.ToString().OrderBy(c => Guid.NewGuid()).ToArray());
        }

        #endregion

        #region Funciones Privadas
        /// <summary>
        /// Función para obtener un carácter aleatorio de un conjunto de caracteres.
        /// </summary>
        /// <param name="caracteres">caracteres definidos en las constantes</param>
        /// <returns>Caracter aleatorio</returns>
        private char ObtenerCaracterAleatorio(string caracteres)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] data = new byte[4];
                rng.GetBytes(data);
                int index = BitConverter.ToInt32(data, 0) % caracteres.Length;
                index = Math.Abs(index);
                return caracteres[index];
            }
        }
        #endregion
    }
}
