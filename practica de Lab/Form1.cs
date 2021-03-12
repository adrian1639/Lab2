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

namespace practica_de_Lab
{
    public partial class Form1 : Form
    {
        public static Form1 f1 = new Form1();
        public static parte2 f3 = new parte2();
        List<Persona> cliente = new List<Persona>();
        List<Vehiculos> carros = new List<Vehiculos>();

        internal List<Persona> Cliente { get => cliente; set => cliente = value; }
        internal List<Vehiculos> Carros { get => carros; set => carros = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Leer();
            Leer2();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Cliente;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = Carros;
            dataGridView2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            f3.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        void Guardar()
        {
            FileStream stream = new FileStream("Cliente.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);


            foreach (var p in Cliente)
            {
                writer.WriteLine(p.Nit);
                writer.WriteLine(p.Nombre);
                writer.WriteLine(p.Direccion);
            }
            writer.Close();
        }

        void Guardar2()
        {
            FileStream stream = new FileStream("Vehiculo.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);


            foreach (var p in Carros)
            {
                writer.WriteLine(p.Placa);
                writer.WriteLine(p.Marca);
                writer.WriteLine(p.Modelo);
                writer.WriteLine(p.Color);
                writer.WriteLine(p.Precio);
            }
            writer.Close();
        }

        void Leer()
        {
            FileStream stream = new FileStream("Cliente.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Persona datos = new Persona();
                datos.Nit = reader.ReadLine();
                datos.Nombre = reader.ReadLine();
                datos.Direccion = reader.ReadLine();
                Cliente.Add(datos);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }

        void Leer2()
        {
            FileStream stream = new FileStream("Vehiculo.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Vehiculos datos = new Vehiculos();
                datos.Placa = reader.ReadLine();
                datos.Marca = reader.ReadLine();
                datos.Modelo = reader.ReadLine();
                datos.Color = reader.ReadLine();
                datos.Precio = float.Parse(reader.ReadLine());
                Carros.Add(datos);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Persona per = new Persona();
            per.Nit = textBox1.Text;
            per.Nombre = textBox2.Text;
            per.Direccion = textBox3.Text;

            Cliente.Add(per);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Cliente;
            dataGridView1.Refresh();

            Guardar();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vehiculos veh = new Vehiculos();
            veh.Placa = textBox6.Text;
            veh.Marca = textBox5.Text;
            veh.Modelo = textBox4.Text;
            veh.Color = textBox9.Text;
            veh.Precio = float.Parse(textBox8.Text);

            Carros.Add(veh);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = Carros;
            dataGridView2.Refresh();

            Guardar2();
            
        }
    }
}
