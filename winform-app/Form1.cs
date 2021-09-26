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
                    lblMensaje.Text = "INGRESE UN ID";
                    txtCriterio.Text = "ID";
                    break;
                case "CODIGO":
                    lblMensaje.Text = "INGRESE UN CODIGO";
                    txtCriterio.Text = "CODIGO";
                    break;
                case "NOMBRE":
                    lblMensaje.Text = "INGRESE UN NOMBRE";
                    txtCriterio.Text = "NOMBRE";
                    break;
                case "MARCA":
                    lblMensaje.Text = "INGRESE UNA MARCA";
                    txtCriterio.Text = "MARCA";
                    break;
                case "CATEGORIA":
                    lblMensaje.Text = "INGRESE UNA CATEGORIA";
                    txtCriterio.Text = "CATEGORIA";
                    break;
                case "PRECIO":
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
            ArticuloNegocio aux = new ArticuloNegocio();            
            dgvArticulos.DataSource = aux.buscar(cmbCriterio.Text, txtCriterio.Text);
            dgvArticulos.Columns["urlImagen"].Visible = false;
            if (aux.buscar(cmbCriterio.Text,txtCriterio.Text).Count() == 0)
            {
                lblMensaje.Text = "ELEMENTO NO ENCONTRADO";
            }
            else
            {
                lblMensaje.Text = "BUSQUEDA REALIZADA";
            }
        }
    }
}
