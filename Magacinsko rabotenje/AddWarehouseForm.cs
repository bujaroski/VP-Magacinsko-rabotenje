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
    public partial class AddWarehouseForm : Form
    {
        public Warehouse magacin { get; set; }
        public AddWarehouseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            magacin = new Warehouse(textBox1.Text);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
