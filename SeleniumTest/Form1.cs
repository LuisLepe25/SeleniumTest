using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Alumno> lstAlumnos = CargarListas();
            if(lstAlumnos != null)
            {

            }
        }

        private List<Alumno> CargarListas()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Selecciona el archivo con la información";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream file = openFileDialog1.OpenFile();
                List<Alumno> lstAlumnos = new List<Alumno>();
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {
                    try
                    {
                        while (!sr.EndOfStream)
                        {
                            try
                            {
                                String line = sr.ReadLine();
                                String[] lineSplit = line.Split('\t');
                                Regex rMatricula = new Regex("^[0-9]*$");
                                if (rMatricula.IsMatch(lineSplit[0]))
                                {
                                    UInt32.TryParse(lineSplit[0], out uint matricula);
                                    String nombre = lineSplit[1];
                                    Alumno a = new Alumno(matricula, nombre);
                                    System.Diagnostics.Debug.WriteLine("Se agrego alumno. Matricula =" + matricula + ", Nombre=" + nombre);
                                    lstAlumnos.Add(a);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("FALLO AGREGAR LINEA. Matricula =" + lineSplit[0]);
                                }
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                        }
                        return lstAlumnos;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        MessageBox.Show("Error al leer archivo. Ex:" + ex.Message, "Error fatal", MessageBoxButtons.OK);
                    }
                }
            }
            return null;
        }
    }
}

