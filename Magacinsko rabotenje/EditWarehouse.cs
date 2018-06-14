using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace Magacinsko_rabotenje
{
    public partial class EditWarehouse : Form
    {
        public Warehouse wh { get; set; }
        public EditWarehouse()
        {
           
            InitializeComponent();
            

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            wh.Name = textBox1.Text;
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-AGB019C\SQLEXPRESS;initial Catalog=MarketEvidence;Integrated Security=True");
            DynamicParameters param = new DynamicParameters();
            param.Add("@SearchText", "");
            List<Warehouse> list = sqlCon.Query<Warehouse>("WarehouseViewAllOrSearch", param,
                commandType: CommandType.StoredProcedure).ToList<Warehouse>();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
