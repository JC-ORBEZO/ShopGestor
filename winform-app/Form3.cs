using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace winform_app
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ArticuloNegocio aux = new ArticuloNegocio();
            Articulo reg = new Articulo();
            reg=aux.buscarPorId(1);
            txtCodigo.Text = reg.codigo;
            txtNombre.Text = reg.nombre;
            txtDescripcion.Text = reg.descripcion;
            txtMarca.Text = reg.marca.descripcionMarca;
            txtCategoria.Text = reg.categoria.descripcionCat;
            txtUrl.Text = reg.urlImagen;
            txtPrecio.Text = reg.precio.ToString();
        }
    }
}
