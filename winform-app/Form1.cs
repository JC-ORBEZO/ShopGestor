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
                    txtCriterio.Text = "ID";
                    break;
                case "CODIGO":
                    txtCriterio.Text = "CODIGO";
                    break;
                case "NOMBRE":
                    txtCriterio.Text = "NOMBRE";
                    break;
                case "MARCA":
                    txtCriterio.Text = "MARCA";
                    break;
                case "CATEGORIA":
                    txtCriterio.Text = "CATEGORIA";
                    break;
                case "PRECIO":
                    txtCriterio.Text = "PRECIO";
                    break;
                    //default: txtCriterio.Text = "RATA";
            }
        }
    }
}
