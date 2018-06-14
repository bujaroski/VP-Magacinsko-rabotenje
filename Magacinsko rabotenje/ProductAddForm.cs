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

        private void button1_Click(object sender, EventArgs e)
        {
            product = new Product(textBox1.Text, textBox2.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
