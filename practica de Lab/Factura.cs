using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_de_Lab
{
    class Factura: Vehiculos
    {
        string nombrecliente;
        string falquiler;
        string fdev;
        float pagar;

        public string Nombrecliente { get => nombrecliente; set => nombrecliente = value; }
        public string Falquiler { get => falquiler; set => falquiler = value; }
        public string Fdev { get => fdev; set => fdev = value; }
        public float Pagar { get => pagar; set => pagar = value; }
    }
}
