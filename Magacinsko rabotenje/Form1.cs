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
                SqlCommand cmd;
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", id);
                param.Add("@Name", warehouse.Name);
                cmd = new SqlCommand("insert into Warehouse(Name) values(@Name)", sqlCon);
                sqlCon.Execute("WarehouseAddorEdit", param, commandType: CommandType.StoredProcedure);
                listWarehouses();

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
            AddWarehouseForm form2 = new AddWarehouseForm();
            form2.Text = "Измени магацин";
            
            if (lbMagacini.SelectedIndex != -1)
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        DynamicParameters param = new DynamicParameters();
                        //param.Add("@ID", id);
                        //param.Add("@Name", form2.wh);
                        cmd = new SqlCommand("update Warehouse set Name=@Name where ID=@ID", sqlCon);
                        //sqlCon.Execute("WarehouseAddorEdit", param, commandType: CommandType.StoredProcedure);
                        Warehouse nov = (Warehouse)lbMagacini.SelectedItem;
                        
                        cmd.Parameters.AddWithValue("@ID", nov.ID);
                        cmd.Parameters.AddWithValue("@Name", form2.magacin.Name);
                        
                        cmd.ExecuteNonQuery();
                        listWarehouses();

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
            }
            else
            {
                MessageBox.Show("Ве молиме одберете магацин од листата", "Одберете магацин");
            }

           


        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-AGB019C\SQLEXPRESS;initial Catalog=MarketEvidence;Integrated Security=True");
            if (lbMagacini.SelectedItem != null)
            {
                sqlCon.Open();
                cmd = new SqlCommand("delete Warehouse where ID=@ID", sqlCon);
                Warehouse warehouse = (Warehouse)lbMagacini.SelectedItem;
                cmd.Parameters.AddWithValue("@ID", warehouse.ID);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                listWarehouses();
            }
            else
            {
                MessageBox.Show("Ве молиме одберете магацин од листата", "Одберете магацин");
            }
        }
    }
}
