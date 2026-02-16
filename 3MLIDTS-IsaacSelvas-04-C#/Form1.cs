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

namespace _3MLIDTS_IsaacSelvas_04_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- 1. VALIDACIONES DE CAMPOS VACÍOS ---
            if (string.IsNullOrWhiteSpace(tboxNombre.Text) ||
                string.IsNullOrWhiteSpace(tboxApellidos.Text) ||
                string.IsNullOrWhiteSpace(tboxEdad.Text) ||
                string.IsNullOrWhiteSpace(tboxEstatura.Text) ||
                string.IsNullOrWhiteSpace(tboxTelefono.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos antes de guardar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución aquí
            }

            // --- 2. VALIDACIÓN DE TIPOS DE DATOS (EDAD Y ESTATURA) ---
            if (!int.TryParse(tboxEdad.Text, out int edad))
            {
                MessageBox.Show("La edad debe ser un número entero válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(tboxEstatura.Text, out decimal estatura))
            {
                MessageBox.Show("La estatura debe ser un número válido (ej. 1.75).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!long.TryParse(tboxTelefono.Text, out long telefono))
            {
                MessageBox.Show("El teléfono debe contener solo números.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 3. LÓGICA DE GÉNERO ---
            string genero = "";
            if (rbtnMasculino.Checked)
            {
                genero = "Masculino";
            }
            else if (rbtnFemenino.Checked)
            {
                genero = "Femenino";
            }
            else
            {
                MessageBox.Show("Por favor seleccione un género.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 4. PREPARACIÓN DE DATOS ---
            // Usamos interpolación ($) para un código más limpio
            string datos = $"Nombre: {tboxNombre.Text} {tboxApellidos.Text} | " +
                           $"Edad: {edad} | " +
                           $"Estatura: {estatura} | " +
                           $"Tel: {telefono} | " +
                           $"Género: {genero}";

            // --- 5. RUTA DEL ARCHIVO (DINÁMICA Y SEGURA) ---
            // Guardamos en la carpeta del proyecto (junto al .exe) para evitar problemas de rutas fijas
            string rutaArchivo = Path.Combine(Application.StartupPath, "Datos_Usuarios_2026.txt");

            // --- 6. ESCRITURA CON MANEJO DE ERRORES ---
            try
            {
                // El parámetro 'true' en StreamWriter indica que AGREGAMOS texto (Append), no lo sobrescribimos.
                using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
                {
                    escritor.WriteLine(datos);
                }

                MessageBox.Show($"Datos guardados correctamente en:\n{rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Si el archivo está abierto o hay error de permisos, mostramos esto:
                MessageBox.Show($"Ocurrió un error al guardar el archivo:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiamos todo
            tboxNombre.Clear();
            tboxApellidos.Clear();
            tboxEdad.Clear();
            tboxEstatura.Clear();
            tboxTelefono.Clear();
            rbtnMasculino.Checked = false;
            rbtnFemenino.Checked = false;

            // Ponemos el cursor en el primer campo para facilitar la escritura
            tboxNombre.Focus();
        }
    }
}
