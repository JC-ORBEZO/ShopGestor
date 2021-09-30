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
        public Form3(int num)
        {
            InitializeComponent();
            txtId.Text = num.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ArticuloNegocio aux = new ArticuloNegocio();
            Articulo reg = new Articulo();
            reg=aux.buscarPorId(int.Parse(txtId.Text));
            txtCodigo.Text = reg.codigo;
            txtNombre.Text = reg.nombre;
            txtDescripcion.Text = reg.descripcion;
            txtMarca.Text = reg.marca.descripcionMarca;
            txtCategoria.Text = reg.categoria.descripcionCat;
            txtUrl.Text = reg.urlImagen;
            txtPrecio.Text = reg.precio.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio nuevo = new ArticuloNegocio();
            Articulo extra = new Articulo();
            extra.codigo = txtCodigo.Text;
            extra.nombre = txtNombre.Text;
            extra.descripcion = txtDescripcion.Text;
            extra.marca = new Marca();
            extra.marca.idMarca = 1;
            extra.categoria = new Categoria();
            extra.categoria.idCat = 1;
            extra.urlImagen = txtUrl.Text;
            extra.precio = decimal.Parse(txtPrecio.Text);
            nuevo.Modificar(extra,int.Parse(txtId.Text));
        }
    }
}
