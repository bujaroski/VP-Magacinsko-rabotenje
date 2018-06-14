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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddWarehouseForm form2 = new AddWarehouseForm();
            
            if (form2.ShowDialog() == DialogResult.OK)
            {
                
            

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", id);
                param.Add("@Name", form2.magacin.Name);
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


        }
    }
}
