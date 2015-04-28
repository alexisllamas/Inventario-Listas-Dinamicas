using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Listas_Enlazadas
{
    class Producto
    {
        private int _clave;
        
        public int Clave
        {
            get { return _clave; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
        }
        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        private int _costo;

        public int Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        private Producto _siguiente;

        internal Producto Siguiente
        {
            get { return _siguiente; }
            set { _siguiente = value; }
        }

        private Producto _anterior;

        internal Producto Anterior
        {
            get { return _anterior; }
            set { _anterior = value; }
        }

        public Producto(int clave, string nombre)
        {
            _nombre = nombre;
            _clave = clave;
        }

        public override string ToString()
        {
            return "Hola bebé, mi clave es " + _clave + ", soy " + Nombre + ", tengo " + Cantidad + " en cantidad y cuesto " + Costo;
        }
    }
}
