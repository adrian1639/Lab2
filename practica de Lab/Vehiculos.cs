using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_de_Lab
{
    class Vehiculos
    {
        string placa;
        string marca;
        string modelo;  
        string color;
        float precio;

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public float Precio { get => precio; set => precio = value; }
    }
}
