using EncryptFiles.Entidades;
using EncryptFiles.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptFiles
{
    public partial class EncryptFiles : Form
    {
        public EncryptFiles()
        {
            InitializeComponent();
        }

        #region Eventos
        private void desencriptarFicheroButton_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcionErrorValidacion = ObtenerErroresDeValidacionDesencriptarDeFormulario();
                Fichero fichero = ObtenerDatosDesencriptarFormulario();

                if (string.IsNullOrEmpty(descripcionErrorValidacion))
                {
                    DesencriptarFichero desencriptarFichero = new DesencriptarFichero();
                    desencriptarFichero.Desencriptar(fichero);
                    MessageBox.Show("Fichero desencriptado correctamente.", "Fichero Desencriptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(descripcionErrorValidacion, "Error al validar datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desencriptar fichero", "Error al desencriptar fichero", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void encriptarFicheroButton_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcionErrorValidacion = ObtenerErroresDeValidacionEncriptarDeFormulario();
                Fichero fichero = ObtenerDatosEncriptarFormulario();

                if (string.IsNullOrEmpty(descripcionErrorValidacion))
                {
                    EncriptarFichero encriptarFichero = new EncriptarFichero();
                    encriptarFichero.Encriptar(fichero);

                    MessageBox.Show("Fichero encriptado correctamente.", "Fichero Encriptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(descripcionErrorValidacion, "Error al validar datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al encriptar fichero: " + ex.Message, "Error al encriptar fichero", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void seleccionarArchivoEncriptarButton_Click(object sender, EventArgs e)
        {
            seleccionarFicheroEncriptarTextBox.Text = SeleccionarFichero();
        }

        private void seleccionarDirectorioDestinoButton_Click(object sender, EventArgs e)
        {
            seleccionarDestinoFicheroEncriptarTextBox.Text = SeleccionarRutaDestino();
        }

        private void SeleccionarFicheroDesencriptarButton_Click(object sender, EventArgs e)
        {
            seleccionarFicheroDesencriptarTextBox.Text = SeleccionarFichero();
        }

        private void seleccionarDestinoDesencriptarButton_Click(object sender, EventArgs e)
        {
            seleccionarFicheroDesencriptarDestinoTextBox.Text = SeleccionarRutaDestino();
        }
        #endregion 


        #region Funciones Privadas

        /// <summary>
        /// Seleccionamos el fichero para encriptar/desencriptar
        /// </summary>
        /// <returns>Ruta Fichero</returns>
        private string SeleccionarFichero()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        /// <summary>
        /// Seleccionamos ruta para almacenar fichero Encriptado/Desencriptado
        /// </summary>
        /// <returns>Ruta del fichero Encriptar/Desencriptar</returns>
        private string SeleccionarRutaDestino()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Selecciona una carpeta";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Función que obtiene los errores de validacion. 
        /// Si disponemos de un error en la validación devuelve
        /// un texto con la descripcion del error por el contrario
        /// si la validacion es correcta devuelve un String.Empty
        /// </summary>
        /// <returns>Descripcion del error o cadena vacia.</returns>
        private string ObtenerErroresDeValidacionEncriptarDeFormulario()
        {
            Validaciones validaciones = new Validaciones();
            return validaciones.DescripcionErroresValidaciones(seleccionarFicheroEncriptarTextBox.Text, seleccionarDestinoFicheroEncriptarTextBox.Text, contrasenaEncriptarTextBox.Text);
        }

        /// <summary>
        /// Función que obtiene los errores de validacion. 
        /// Si disponemos de un error en la validación devuelve
        /// un texto con la descripcion del error por el contrario
        /// si la validacion es correcta devuelve un String.Empty
        /// </summary>
        /// <returns>Descripcion del error o cadena vacia.</returns>
        private string ObtenerErroresDeValidacionDesencriptarDeFormulario()
        {
            Validaciones validaciones = new Validaciones();
            return validaciones.DescripcionErroresValidaciones(seleccionarFicheroDesencriptarTextBox.Text, seleccionarFicheroDesencriptarDestinoTextBox.Text, contrasenaDesencriptarTextBox.Text);
        }

        private string ObtenerNombreDelFichero(string rutaDestino)
        {
            return Path.GetFileName(rutaDestino);
        }

        /// <summary>
        /// Obtener los datos del formulario de encriptar fichero
        /// </summary>
        /// <returns>Devuelve los datos del formulario en la clase Fichero</returns>
        private Fichero ObtenerDatosEncriptarFormulario()
        {
            return new Fichero(seleccionarFicheroEncriptarTextBox.Text,
                               seleccionarDestinoFicheroEncriptarTextBox.Text + ObtenerNombreDelFichero(seleccionarFicheroEncriptarTextBox.Text),
                               contrasenaEncriptarTextBox.Text);
        }

        /// <summary>
        /// Obtener los datos del formulario de desencriptar fichero
        /// </summary>
        /// <returns>Devuelve los datos del formulario en la clase Fichero</returns>
        private Fichero ObtenerDatosDesencriptarFormulario()
        {
            return new Fichero(seleccionarFicheroDesencriptarTextBox.Text,
                               seleccionarFicheroDesencriptarDestinoTextBox.Text + ObtenerNombreDelFichero(seleccionarFicheroDesencriptarTextBox.Text),
                               contrasenaDesencriptarTextBox.Text);
        }

        #endregion

      
    }
}
