﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AccesoADatos;
using Microsoft.Win32;
using Entidades;

namespace Trabajo_Final_Taller2.vistas
{
    /// <summary>
    /// Lógica de interacción para HacerPregunta.xaml
    /// </summary>
    public partial class HacerPregunta : Window
    {
        Usuario user;
        string imagenFinal = null;
        public HacerPregunta(Usuario user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void btnPreguntar_Click(object sender, RoutedEventArgs e)
        {
            string titulo;
            string descripcion;

            //aun no se 100% como se va a manejar la imagen asi que por el momento lo dejo como un string...
            string imagen = imagenFinal;

            // Validacion de campos
            if (string.IsNullOrWhiteSpace(txbTitulo.Text) 
               || string.IsNullOrWhiteSpace(txbDescripcion.Text))
            {
                MessageBox.Show("Campos invalidos");
                return;
            }
            else
            {
                titulo = txbTitulo.Text;
                descripcion = txbDescripcion.Text;
            }

            if (imagen != null)
            {
                ControladorABM.HacerPregunta(user, titulo, descripcion, imagen);
            }
            else
            {
                ControladorABM.HacerPregunta(user, titulo, descripcion);
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Lo que hace este metodo es, al hacer click se abre un cuadro para seleccionar imagen; se usan unos parametros para especificar 
        /// que tipo de imagenes se pueden subir
        /// despues se obtiene el nombre del archivo, la ruta + el nombre, a donde se quiere copiar el archivo y destFile que va a ser la nueva ruta + el nombre dek archivo
        /// luego se copia la imagen en la carpeta de imagenes del proyecto.
        /// </summary>
        private void btnExaminar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Seleccionar imagen";
            op.Filter = "Tipos de archivo|*.jpg;*png|" + "JPEG (*.jpg)|*.jpg;|" + "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                string fileName = op.SafeFileName;
                string source = op.FileName;
                string target = @"..\..\..\img";
                int strLength = fileName.Length;
                //La idea era usar dateTime, pero como lo que devuelve tiene caracteres no aptos para nombres de archivos, 
                //simplemente le doy un numero random

                var fecha = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss:ms zzz");
                Console.WriteLine(fecha);
                var fechaMod = fecha.Replace("-", "").Replace(" ", "").Replace("/", "").Replace(":", "").Replace("+", "");
                Console.WriteLine(fechaMod);

                string newName = fileName.Insert(strLength - 4, fechaMod); 

                //MessageBox.Show(newName);
                string destFile = System.IO.Path.Combine(target, newName);

                System.IO.File.Copy(source, destFile, true);
                //destFile es lo que hay que guardar en la DB
                imagenFinal = destFile;
               //MessageBox.Show(destFile);
            }
        }
    }
}
