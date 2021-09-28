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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio aux = new ArticuloNegocio();
            dgvArticulos.DataSource = aux.listar();
            dgvArticulos.Columns["urlImagen"].Visible = false;
            //dgvArticulos.Columns[0].Visible = false;
        }

        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbCriterio.Text)
            {
                case "ID":
                    txtCriterio.Enabled = true;
                    lblMensaje.Text = "INGRESE UN ID";
                    txtCriterio.Text = "ID";
                    break;
                case "CODIGO":
                    txtCriterio.Enabled = true;
                    lblMensaje.Text = "INGRESE UN CODIGO";
                    txtCriterio.Text = "CODIGO";
                    break;
                case "NOMBRE":
                    txtCriterio.Enabled = true;
                    lblMensaje.Text = "INGRESE UN NOMBRE";
                    txtCriterio.Text = "NOMBRE";
                    break;
                case "MARCA":
                    txtCriterio.Enabled = true;
                    lblMensaje.Text = "INGRESE UNA MARCA";
                    txtCriterio.Text = "MARCA";
                    break;
                case "CATEGORIA":
                    txtCriterio.Enabled = true;
                    lblMensaje.Text = "INGRESE UNA CATEGORIA";
                    txtCriterio.Text = "CATEGORIA";
                    break;
                case "PRECIO":
                    txtCriterio.Enabled = true;
                    lblMensaje.Text = "INGRESE UN PRECIO";
                    txtCriterio.Text = "PRECIO";
                    break;
                default:
                    lblMensaje.Text = "ELEGIR CRITERIO";
                    break;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbCriterio.Text == "CRITERIO DE BUSQUEDA")
            {
                lblMensaje.Text = "ELIJA CRITERIO DE BÚSQUEDA";
            }
            else
            {
                ArticuloNegocio aux = new ArticuloNegocio();
                dgvArticulos.DataSource = aux.buscar(cmbCriterio.Text, txtCriterio.Text);
                dgvArticulos.Columns["urlImagen"].Visible = false;
                if (aux.buscar(cmbCriterio.Text, txtCriterio.Text).Count() == 0)
                {
                    lblMensaje.Text = "ARTICULO NO ENCONTRADO";
                }
                else
                {
                    lblMensaje.Text = "BUSQUEDA REALIZADA";
                }
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Opacity = .80;
            Form2 nuevo = new Form2();
            nuevo.ShowDialog();
            this.Opacity = 100;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Form3 nue = new Form3();
            nue.ShowDialog();
        }
    }
}
