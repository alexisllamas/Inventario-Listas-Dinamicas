using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Listas_Enlazadas
{
    class Inventario
    {
        private Producto _inicio;

        internal Producto Inicio
        {
            get { return _inicio; }
            set { _inicio = value; }
        }

        public void agregar(Producto nuevo)
        {
            if (_inicio == null)
                _inicio = nuevo;
            else
                agregar(_inicio, nuevo);
        }

        private void agregar(Producto pUltimo, Producto nuevo)
        {
            if (pUltimo.Siguiente == null)
                pUltimo.Siguiente = nuevo;
            else
                agregar(pUltimo.Siguiente, nuevo);
        }

        public void eliminar(int clave)
        {
            Producto t = buscar(clave);
            if (t == null)
                return;
            else if (_inicio == t)
            {
                if (_inicio.Siguiente == null)
                    _inicio = null;
                else
                    _inicio = _inicio.Siguiente;
            }
            else
                eliminar(_inicio, t);
        }

        private void eliminar(Producto nuevo, Producto t)
        {
            if (nuevo.Siguiente == t)
            {
                if (nuevo.Siguiente.Siguiente == null)
                    nuevo.Siguiente = null;
                else
                    nuevo.Siguiente = nuevo.Siguiente.Siguiente;
            }
            else
                eliminar(nuevo.Siguiente, t);
 
        }

        public void modificar(Producto nuevo)
        {
            if (_inicio == null)
                return;
            else if (_inicio.Clave == nuevo.Clave)
            {
                nuevo.Siguiente = _inicio.Siguiente;
                _inicio = nuevo;
            }
            else
                modificar(_inicio, nuevo);
        }

        private void modificar(Producto viejo, Producto nuevo)
        {
            if (viejo.Siguiente == null)
                return;
            else if (viejo.Siguiente.Clave == nuevo.Clave)
            {
                nuevo.Siguiente = viejo.Siguiente.Siguiente;
                viejo.Siguiente = nuevo;
            }
            else
                modificar(viejo.Siguiente, nuevo);
        }

        public Producto buscar(int clave)
        {
            if (_inicio == null)
                return null;
            else if (_inicio.Clave == clave)
                return _inicio;
            else
                return buscar(_inicio.Siguiente, clave);
        }

        public Producto buscar(Producto pUltimo, int clave)
        {
            if (pUltimo == null)
                return null;
            else if (pUltimo.Clave == clave)
                return pUltimo;
            else
                return buscar(pUltimo.Siguiente, clave);
        }

        public string reporte()
        {
            if (_inicio == null)
                return "";
            else if (_inicio.Siguiente == null)
                return _inicio.ToString();
            else
                return _inicio.ToString() + Environment.NewLine + reporte(_inicio.Siguiente);
        }

        private string reporte(Producto hola)
        {
            if (hola.Siguiente == null)
                return hola.ToString();
            else
                return hola.ToString() + Environment.NewLine + reporte(hola.Siguiente);
        }
    }
}
