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
        private Producto _ultimo;

        public void agregar(Producto nuevo)
        {
            if (_inicio == null)
            {
                _inicio = nuevo;
                _ultimo = nuevo;
            }
            else
                agregar(_inicio, nuevo);
        }

        private void agregar(Producto viejo, Producto nuevo)
        {
            if (nuevo.Clave < viejo.Clave)
            {
                nuevo.Siguiente = viejo;
                nuevo.Anterior = viejo.Anterior;

                if (viejo.Anterior == null)
                    _inicio = nuevo;
                else
                    viejo.Anterior.Siguiente = nuevo;

                viejo.Anterior = nuevo;
            }
            else if (viejo.Siguiente == null)
            {
                nuevo.Anterior = viejo;
                _ultimo = nuevo;
                viejo.Siguiente = nuevo;
            }
            else
                agregar(viejo.Siguiente, nuevo);
        }

        public void eliminar(int clave)
        {
            Producto t = buscar(clave);
            if (t == null)
                return;

            if (t == _inicio)
                _inicio = t.Siguiente;
            else
                t.Anterior.Siguiente = t.Siguiente;

            if (t == _ultimo)
                _ultimo = t.Anterior;
            else
                t.Siguiente.Anterior = t.Anterior;
        }

        public void modificar(Producto nuevo)
        {
            Producto tem = buscar(nuevo.Clave);
            if (tem != null)
            {
                if (tem.Anterior != null)
                {
                    tem.Anterior.Siguiente = nuevo;
                    nuevo.Anterior = tem.Anterior;
                }
                else
                    _inicio = nuevo;

                if (tem.Siguiente != null)
                {
                    tem.Siguiente.Anterior = nuevo;
                    nuevo.Siguiente = tem.Siguiente;
                }
                else
                    _ultimo = nuevo;
            }
        }

        public Producto buscar(int clave)
        {
            Producto tem = _inicio;
            while(tem != null)
            {
                if (tem.Clave == clave)
                    return tem;
                tem = tem.Siguiente;
            }
            return null;
        }

        public string reporte()
        {
            Producto tem = _ultimo;
            string cadenita = "";
            while(tem != null)
            {
                cadenita += tem.ToString() + Environment.NewLine;
                tem = tem.Anterior;
            }
            return cadenita;
        }
    }
}