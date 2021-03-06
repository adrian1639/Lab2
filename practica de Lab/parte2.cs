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
    public partial class parte2 : Form
    {
        
        List<Factura> pago = new List<Factura>();
        List<Persona> Cliente = new List<Persona>();
        List<Vehiculos> Carros = new List<Vehiculos>();


        public static Form1 f1 = new Form1();
        public static parte2 f3 = new parte2();

        internal List<Factura> Pago { get => pago; set => pago = value; }

        public parte2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        void Guardar3()
        {
            FileStream stream = new FileStream("Factura.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);


            foreach (var p in Pago)
            {
                writer.WriteLine(p.Nombrecliente);
                writer.WriteLine(p.Falquiler);
                writer.WriteLine(p.Fdev);
                writer.WriteLine(p.Pagar);


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

        void Leer3()
        {
            FileStream stream = new FileStream("Factura.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Factura datos = new Factura();
                datos.Nombrecliente = reader.ReadLine();
                datos.Falquiler = reader.ReadLine();
                datos.Fdev = reader.ReadLine();
                datos.Pagar = float.Parse(reader.ReadLine());
                Pago.Add(datos);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int c = 0;

            Factura fac = new Factura();

            for (int i = 0; i < Cliente.Count; i++)
              if (Cliente[i].Nit == textBox6.Text) c = i;
            fac.Nombrecliente = Cliente[c].Nombre;
            

            for (int i = 0; i < Carros.Count; i++)
                if (Carros[i].Placa == textBox5.Text) c = i;
            fac.Pagar = Carros[c].Precio * float.Parse(textBox8.Text);
            fac.Placa = Carros[c].Placa;
            fac.Marca = Carros[c].Marca;
            fac.Modelo = Carros[c].Modelo;
            fac.Color = Carros[c].Color;
            fac.Precio = Carros[c].Precio;

            fac.Falquiler = textBox4.Text;
            fac.Fdev = textBox9.Text;

            Pago.Add(fac);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Pago;
            dataGridView1.Refresh();

            Guardar3();
        }

        private void parte2_Load(object sender, EventArgs e)
        {
            Leer();
            Leer2();
            Leer3();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Pago;
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }
    }
}
