using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace winform_app
{
    public partial class Form4 : Form
    {
        public int numId { get; set; }
        public Form4(int num)
        {
            InitializeComponent();
            numId = num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArticuloNegocio extra = new ArticuloNegocio();
            extra.eliminar(numId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
