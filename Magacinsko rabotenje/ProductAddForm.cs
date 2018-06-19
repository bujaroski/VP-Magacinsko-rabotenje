using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magacinsko_rabotenje
{
    public partial class ProductAddForm : Form
    {
        public Product product { get; set; }
        public ProductAddForm()
        {
            InitializeComponent();
        }

       

        private void ProductAddForm_Shown(object sender, EventArgs e)
        {
            if (Form1.IzmeniProizvod)
            {
                tbIme.Text = Form1.Proizvod.Name;
                tbOpis.Text = Form1.Proizvod.Descriptionn;
                nudCena.Value = Form1.Proizvod.Price;
                nudKolicina.Value = Form1.Proizvod.quantity;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            product = new Product(tbIme.Text, tbOpis.Text, Convert.ToInt32(nudCena.Value), Convert.ToInt32(nudKolicina.Value));
            Form1.IzmeniProizvod = false;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
