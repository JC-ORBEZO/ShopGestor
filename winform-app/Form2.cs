using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Dominio;
using Negocio;

namespace winform_app
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text.Trim() != "" && txtNombre.Text.Trim() != "" && txtDescripcion.Text.Trim() != "" && txtMarca.Text.Trim() != "" && txtCategoria.Text.Trim() != "" && txtUrl.Text.Trim() != "" && txtPrecio.Text.Trim() != "")
            {
                //txtCodigo.Text.Trim();
                ArticuloNegocio extra = new ArticuloNegocio();
                Articulo nuevo = new Articulo();

                nuevo.codigo = txtCodigo.Text;
                nuevo.nombre = txtNombre.Text;
                nuevo.descripcion = txtDescripcion.Text;
                //nuevo.marca.idMarca=int.Parse(txtMarca.Text);
                nuevo.marca = new Marca();
                nuevo.marca.idMarca = int.Parse(txtMarca.Text);
                nuevo.categoria = new Categoria();
                nuevo.categoria.idCat = int.Parse(txtCategoria.Text);
                //nuevo.categoria.idCat = int.Parse(txtCategoria.Text);
                nuevo.urlImagen = txtUrl.Text;
                try
                {
                    nuevo.precio = decimal.Parse(txtPrecio.Text);
                    extra.agregar(nuevo);
                    //MessageBox.Show("Agregado");                
                    lblMensaje.Text = "CORRECTAMENTE AGREGADO";
                    this.Close();
                }
                catch (Exception)
                {
                    lblMensaje.Text = "PRECIO INCORRECTO";
                }
                
            }
            else
            {
                lblMensaje.Text = "CAMPOS SIN RELLENAR";
            }            
        }
    }
}
