using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario_Listas_Enlazadas
{
    public partial class Form1 : Form
    {
        private Inventario inven;
        public Form1()
        {
            InitializeComponent();
            inven = new Inventario();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            int clave = Convert.ToInt32(txtClave.Text);
            Producto producto = new Producto(clave, txtNombre.Text);
            producto.Costo = Convert.ToInt32(txtPrecio.Text);
            producto.Cantidad = Convert.ToInt32(txtCantidad.Text);

            inven.agregar(producto);
            lblEstado.Text = "Se agregó uno, guapo";
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            int clave = Convert.ToInt32(txtBuscar.Text);
            Producto producto = inven.buscar(clave);
            if (producto != null)
            {
                txtCantidad.Text = producto.Cantidad.ToString();
                txtClave.Text = producto.Clave.ToString();
                txtNombre.Text = producto.Nombre.ToString();
                txtPrecio.Text = producto.Costo.ToString();
            }
            else
                MessageBox.Show("No se encontró", "Perdón");
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            inven.eliminar(Convert.ToInt32(txtEliminar.Text));
        }

        private void cmdReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = inven.reporte();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            int clave = Convert.ToInt32(txtClave.Text);
            Producto producto = new Producto(clave, txtNombre.Text);
            producto.Costo = Convert.ToInt32(txtPrecio.Text);
            producto.Cantidad = Convert.ToInt32(txtCantidad.Text);

            inven.modificar(producto);
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblEstado.Text = "Holi bebé";
        }
    }
}
