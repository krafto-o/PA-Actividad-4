using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace _3MLIDTS_IsaacSelvas_04_C_

{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tboxEdad.TextChanged += ValidarEdad;
            tboxApellidos.TextChanged += ValidarApellidos;
            tboxNombre.TextChanged += ValidarNombre;
            tboxEstatura.TextChanged += ValidarEstatura;
            tboxTelefono.Leave += ValidarTelefono;
        }

        private void ValidarEdad(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EnteroValido(textbox.Text))
            {
                MessageBox.Show("Ingrese valores correctos para la edad", 
                    "Error Edad",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarNombre(object sender, EventArgs e)
        {
            TextBox cajaNombre = (TextBox)sender;
            if (!EsTextoValido(cajaNombre.Text))
            {
                MessageBox.Show("Ingrese valores correctos para el Nombre", "Error Nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cajaNombre.Clear();
            }
        }

        private void ValidarApellidos(object sender, EventArgs e)
        {
            TextBox cajaApellidos = (TextBox)sender;
            if (!EsTextoValido(cajaApellidos.Text))
            {
                MessageBox.Show("Ingrese valores correctos para el apellido", "Error Apellido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cajaApellidos.Clear();
            }
        }

        private void ValidarEstatura(object sender, EventArgs e)
        {
            TextBox textBoxEstatura = (TextBox)sender;
            if (!EsFlotanteValido(textBoxEstatura.Text))
            {
                MessageBox.Show("Ingrese valores correctos para la estatura", "Error Estatura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEstatura.Clear();
            }
        }

        private void ValidarTelefono(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            if (input.Length > 10)
            {
                if (!EsEnteroValidoDe10Digitos(input))
                {
                    textBox.BackColor = Color.Red;
                }
            }
            else if (!EsEnteroValidoDe10Digitos(input))
            {
                textBox.BackColor = Color.Yellow;
            }
            else
            {
                textBox.BackColor = Color.SeaGreen;
            }
        }


        private bool EnteroValido(String valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }

        private bool EsEnteroValidoDe10Digitos(string valor)
        {
            long resultado;
            return long.TryParse(valor, out resultado) && valor.Length == 10;
        }

        private bool EsTextoValido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
        }

        private bool EsFlotanteValido(String valor)
        {
            float resultado;
            return float.TryParse(valor, out resultado);
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = tboxNombre.Text;
            string apellidos = tboxApellidos.Text;
            string edad = tboxEdad.Text;
            string estatura = tboxEstatura.Text;
            string telefono = tboxTelefono.Text;
            string genero = "";

            if (rbtnMasculino.Checked)
            {
                genero = "Masculino";
            }
            else if (rbtnFemenino.Checked)
            {
                genero = "Femenino";
            }

            string datos = $"Nombres: {nombre}\r\n " + $"Apellidos: {apellidos}\r\n" + $"Edad: {edad}\r\n" + $"Estatura: {estatura}\r\n" + $"Telefono: {telefono}\r\n" + $"Genero: {genero}\r\n";
            string rutaArchivo = "C:\\Users\\kv\\source\\repos\\3MLIDTS-IsaacSelvas-04-C#\\3MLIDTS-IsaacSelvas-04-C#\\3M_Datos_20261102.txt";
            bool archivoExiste = File.Exists(rutaArchivo);
            using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
            {
                if (archivoExiste)
                {
                    escritor.WriteLine();
                }
                escritor.WriteLine(datos);
            }
            MessageBox.Show("Datos Guardados Correctamente: \r\n" + datos, "Informacion - Actividad 04", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            tboxNombre.Clear();
            tboxApellidos.Clear();
            tboxEdad.Clear();
            tboxEstatura.Clear();
            tboxTelefono.Clear();
            rbtnMasculino.Checked = false;
            rbtnFemenino.Checked = false;
        }

    }

}