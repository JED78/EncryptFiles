using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptFiles.Entidades
{
    public class Fichero
    {
        public Fichero(string rutaOrigen, string rutaDestino, string contrasena) 
        {
            RutaOrigen = rutaOrigen;
            RutaDestino = rutaDestino;
            Contrasena = contrasena;
        }

        public string RutaOrigen { get; set; }
        public string RutaDestino { get; set; }
        public string Contrasena { get; set; }

    }
}
