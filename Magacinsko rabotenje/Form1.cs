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

        void SaveToDatabase(Warehouse warehouse)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", id);
                param.Add("@Name", warehouse.Name);
                sqlCon.Execute("WarehouseAddorEdit", param, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
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
            if (form2.ShowDialog() == DialogResult.OK)
            {
                SaveToDatabase(form2.magacin);            
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            EditWarehouse form2 = new EditWarehouse();
            
            if(lbMagacini.SelectedIndex != -1)
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    SaveToDatabase(form2.wh);
                }
            }
            else
            {
                MessageBox.Show("Ве молиме одберете магацин од листата", "Одберете магацин");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", id);
                sqlCon.Execute("WarehouseDeleteByID",param,commandType:CommandType.StoredProcedure);
                listWarehouses();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
