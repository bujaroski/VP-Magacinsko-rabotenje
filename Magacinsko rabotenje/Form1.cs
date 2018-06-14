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
    public partial class Form1 : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-AGB019C\SQLEXPRESS;initial Catalog=MarketEvidence;Integrated Security=True");
        int id = 0;
        public Form1()
        {
            InitializeComponent();
            listWarehouses();
            lbMagacini.SelectedItem = null;
        } 

        void listWarehouses()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SearchText", "");
            List<Warehouse> list = sqlCon.Query<Warehouse>("WarehouseViewAllOrSearch", param,
                commandType: CommandType.StoredProcedure).ToList<Warehouse>();
            lbMagacini.DataSource = list;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            AddWarehouseForm form2 = new AddWarehouseForm();
            form2.Text = "Додади нов магацин";
            if (form2.ShowDialog() == DialogResult.OK)
            {
                WarehouseAdapterSQL.SaveToDatabase(form2.magacin);
                listWarehouses();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            AddWarehouseForm form2 = new AddWarehouseForm();
            form2.Text = "Измени магацин";
            
            if (lbMagacini.SelectedIndex != -1)
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    WarehouseAdapterSQL.EditToDatabase(form2.magacin, lbMagacini);
                    listWarehouses();
                }
            }
            else
            {
                MessageBox.Show("Ве молиме одберете магацин од листата", "Одберете магацин");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lbMagacini.SelectedItem != null)
            {
                WarehouseAdapterSQL.DeleteFromDatabase(lbMagacini);
                listWarehouses();
            }
            else
            {
                MessageBox.Show("Ве молиме одберете магацин од листата", "Одберете магацин");
            }
        }
    }
}
