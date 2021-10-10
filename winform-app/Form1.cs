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
        public int numId { get; set;}
        public frmMenu()
        {
            InitializeComponent();
            //BANDERA PARA ATAJAR LA NO SELECCIÓN DE ALGUNA FILA DEL DGV
            numId = -2;
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
            ArticuloNegocio aux = new ArticuloNegocio();
            dgvArticulos.DataSource = aux.listar();
            dgvArticulos.Columns["urlImagen"].Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (numId == -2)
            {
                lblMensaje2.Text = "SELECCIONE UN ARTICULO";
            }
            else
            {
                lblMensaje2.Text = "";
                Form3 nue = new Form3(numId);
                nue.ShowDialog();
                // ACTUALIZACION DE LISTA EN DGV
                ArticuloNegocio aux = new ArticuloNegocio();
                dgvArticulos.DataSource = aux.listar();
                dgvArticulos.Columns["urlImagen"].Visible = false;
            }            
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            //lblMensaje=dgvArticulos.Columns["Id"].  ToString());
            lblMensaje2.Text = "";
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            numId=seleccionado.id;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numId == -2)
            {
                lblMensaje2.Text = "SELECIONE UN ARTICULO";
            }
            else
            {
                Form4 nuevo = new Form4(numId);
                nuevo.Show();
            }            
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (numId == -2)
            {
                lblMensaje2.Text = "SELECIONE UN ARTICULO";
            }
            else
            {
                Form5 extra = new Form5();
                extra.Show();
            }            
        }
    }
}
