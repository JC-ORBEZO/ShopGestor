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

namespace winform_app
{
    public partial class Form5 : Form
    {
        public Form5(Articulo proba)
        {
            InitializeComponent();
            txtID.Text = proba.id.ToString();
            txtCodigo.Text = proba.codigo;
            txtNombre.Text = proba.nombre;
            txtDescripcion.Text = proba.descripcion;
            txtMarca.Text = proba.marca.descripcionMarca;
            txtCategoria.Text = proba.categoria.descripcionCat;
            txtUrl.Text = proba.urlImagen;
            txtPrecio.Text = proba.precio.ToString();
            try
            {
                pbImage.Load(proba.urlImagen);
            }
            catch (Exception ex)
            {
                pbImage.Load("https://media.istockphoto.com/vectors/camera-summer-icon-thin-line-style-vector-id1251131605?k=20&m=1251131605&s=612x612&w=0&h=grkBUj2MRh-7uBfTc76CdzPbdj-_7ksZ0pWji2JkKaE=");
            }            
            txtID.Enabled = false;
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtMarca.Enabled = false;
            txtCategoria.Enabled = false;
            txtUrl.Enabled = false;
            txtPrecio.Enabled = false;
        }
    }
}
