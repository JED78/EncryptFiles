using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptFiles.LogicaNegocio
{
    public class Validaciones
    {
        #region Funiones Públicas
        /// <summary>
        /// Funcion que nos devuelve el error en la validacion
        /// de los datos del formulario. 
        /// 
        /// Disponemos de 3 validaciones: 
        ///         1 - Validar ruta origen si existe el fichero
        ///         2 - Validar ruta destino si existe
        ///         3 - Si el usuario introdujo contraseña para encriptar
        /// </summary>
        /// <param name="rutaOrigen">Ruta donde se localiza el archivo encriptar</param>
        /// <param name="rutaDestino">Ruta donde se almacena el fichero encriptado</param>
        /// <param name="contrasena">Contraseña para encriptar</param>
        /// <returns></returns>
        public string DescripcionErroresValidaciones(string rutaOrigen, string rutaDestino, string contrasena)
        {
            if (ExisteRutaOrigen(rutaOrigen))
            {
                if (ExisteRutaDestino(rutaDestino))
                {
                    if (!EsContrasenaValida(contrasena))
                    {
                        return "Error: Introduce contraseña.";
                    }
                }
                else
                {
                    return "Error: Ruta destino no existe.";
                }
            }
            else
            {
                return "Error: Fichero no existe. Seleccione un fichero para encriptar.";
            }

            return string.Empty;

        }
        #endregion

        #region Funciones Privadas
        /// <summary>
        /// Función que valida ruta origen si existe el fichero
        /// </summary>
        /// <param name="rutaOrigen">Ruta del fichero que selecciono el usuario para encriptar</param>
        /// <returns>True/False</returns>
        private bool ExisteRutaOrigen(string rutaOrigen)
        {
            if (File.Exists(rutaOrigen))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Función que indica si existe la ruta destino 
        /// seleccionada por el usuario. 
        /// </summary>
        /// <param name="rutaDestino">Ruta destino seleccionada por el usuario</param>
        /// <returns>True/False</returns>
        private bool ExisteRutaDestino(string rutaDestino)
        {

            if (Directory.Exists(rutaDestino))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Función que indica si la contraseña es valida
        /// Por ahora solo se comprueba que no sea cadena vacia.
        /// </summary>
        /// <param name="contrasena">Contraseña introducida por le usuario</param>
        /// <returns>True/False</returns>
        private bool EsContrasenaValida(string contrasena)
        {
            if (string.IsNullOrEmpty(contrasena))
            {
                return false;
            }
           
           return true;

            //if (string.IsNullOrWhiteSpace(contrasena)) return false;
            //if (contrasena.Length < 8) return false;
            //if (!contrasena.Any(char.IsUpper)) return false;
            //if (!contrasena.Any(char.IsLower)) return false;
            //if (!contrasena.Any(char.IsDigit)) return false;
            //if (!contrasena.Any(ch => "!@#$%^&*()_+-=[]{}|;:'\",.<>?/".Contains(ch))) return false;

        }

        #endregion
    }
}
