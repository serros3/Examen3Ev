using System.Collections;
using System.Windows.Forms;

namespace _3aEvExamenSergioRosa
{
    public partial class Form1 : Form
    {

        String path;
        String pathTemp = @"C:\Temp\";//@ es para directorios fuera del proyecto
        String fileNameTemp = "Temp.ext";

        public ArrayList listaLibros = new ArrayList();
        public ArrayList inListaLibros = new ArrayList();
        public string textDoc="";

        public Form1()
        {
            InitializeComponent();
            CrearTemporalFile();
            AvisoArchivo();
        }

        public void AgregarLibro(LIBRO libro)
        {
            listaLibros.Add(libro);
            MessageBox.Show("El libro se ha añadido correctamente.");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        public void EliminarLibro(string cadena1, string cadena2, string cadena3)
        {
            bool encontrado = false;
            foreach (LIBRO libro in listaLibros)
            {
                if (cadena1.Equals(libro.Titulo))
                {
                    listaLibros.Remove(libro);
                    MessageBox.Show("El libro ha sido eliminado correctamente.");
                    encontrado = true;
                    break;
                }
                else if (cadena2.Equals(libro.Autor))
                {
                    listaLibros.Remove(libro);
                    MessageBox.Show("El libro ha sido eliminado correctamente.");
                    encontrado = true;
                    break;
                }
                else if (cadena3.Equals(libro.AnyoPublicacion))
                {
                    listaLibros.Remove(libro);
                    MessageBox.Show("El libro ha sido eliminado correctamente.");
                    encontrado = true;
                    break;
                }
                else
                {
                    //MessageBox.Show("No se encontro ningun libro con esas propiedades para eliminar.");
                }


            }
            if (!encontrado)
            {
                MessageBox.Show("No se encontro ningun libro con esas propiedades para ser eliminado");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        public LIBRO BuscarLibro(string cadena1, string cadena2, string cadena3)
        {
            LIBRO outLibro = new LIBRO();
            bool encontrado = false;

            foreach (LIBRO libro in listaLibros)
            {
                if (cadena1.Equals(libro.Titulo))
                {
                    outLibro.Titulo = libro.Titulo;
                    outLibro.Autor = libro.Autor;
                    outLibro.AnyoPublicacion = libro.AnyoPublicacion;
                    encontrado = true;
                    break;
                }
                else if (cadena2.Equals(libro.Autor))
                {
                    outLibro.Titulo = libro.Titulo;
                    outLibro.Autor = libro.Autor;
                    outLibro.AnyoPublicacion = libro.AnyoPublicacion;
                    encontrado = true;
                    break;
                }
                else if (cadena3.Equals(libro.AnyoPublicacion))
                {
                    outLibro.Titulo = libro.Titulo;
                    outLibro.Autor = libro.Autor;
                    outLibro.AnyoPublicacion = libro.AnyoPublicacion;
                    encontrado = true;
                    break;
                }

                // MessageBox.Show("No se encontro ningun libro con esas propiedades")
            }
            if (!encontrado)
            {
                MessageBox.Show("No se encontro ningun libro con esas propiedades");
            }

            return outLibro;
        }

        private void CrearTemporalFile()
        {
            try
            {
                if (!Directory.Exists(pathTemp))
                {
                    Directory.CreateDirectory(pathTemp);
                }
                else
                {
                    //MessageBox.Show("La carpeta temporal existe:" +  pathTemp);
                }

                using (StreamWriter sw = new StreamWriter(pathTemp + fileNameTemp))
                {
                    sw.Write("");
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show("Error ar crear la carpeta temporal" + ex.Message);
            }
        }

        private void AvisoArchivo()
        {
            MessageBox.Show("Debe abrir el archivo de libros, si no tiene uno Inserte los libros y guarde al finalizar!");
        }

        private void button1_Click(object sender, EventArgs e)//Añadiir
        {
            LIBRO auxLibro = new LIBRO(textBox1.Text, textBox2.Text, textBox3.Text);

            AgregarLibro(auxLibro);

        }

        private void button2_Click(object sender, EventArgs e)//Eliminar
        {
            EliminarLibro(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)//Buscar
        {
            LIBRO auxLibro2 = BuscarLibro(textBox1.Text, textBox2.Text, textBox3.Text);
            textBox1.Text = auxLibro2.Titulo;
            textBox2.Text = auxLibro2.Autor;
            textBox3.Text = auxLibro2.AnyoPublicacion;
        }

        private void button4_Click(object sender, EventArgs e)//Abrir
        {
            //abrir
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    path = openFileDialog.FileName;
                    using (StreamReader sr = new StreamReader(path))
                    {
                        textDoc = sr.ReadToEnd();
                    }

                    LIBRO auxLib = new LIBRO();

                    string[] campos = textDoc.Split(new char[] { ',' });
                    int i = 0;
                    foreach (string campo in campos)
                    {
                        if (i == 0)
                        {
                            auxLib.Titulo = campo;
                          
                        }else if (i == 1)
                        {
                            auxLib.Autor = campo;
                        }else if (i == 2)
                        {
                            auxLib.AnyoPublicacion = campo;
                        }

                        i++;
                        if (i == 3)
                        {
                            listaLibros.Add(auxLib);                     
                            i=0;   
                        }    
                    }


                    textDoc=string.Empty;

                }
                catch (IOException ex)
                {
                    MessageBox.Show("No se pudo abrir el documento" + ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)//Guardar
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    textDoc = string.Empty;

                    foreach (LIBRO libro in listaLibros){
                        textDoc = textDoc + (libro.Titulo + "," + libro.Autor + "," + libro.AnyoPublicacion+",");
                    }
  
                    path = saveFileDialog.FileName;
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.Write(textDoc);
                    }

                    textDoc = string.Empty;
                }
                catch (IOException ex)
                {
                    MessageBox.Show("No se pudo guardar el documento" + ex.Message);
                }
            }
        }
    }
}
