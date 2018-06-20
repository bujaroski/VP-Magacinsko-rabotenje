using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magacinsko_rabotenje
{
    class InvoiceAdapterSQL
    {
        public static SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-0S9U6FP\MSSQLSERVER2014;initial Catalog=MarketEvidence;Integrated Security=True");
        public static void SaveToDatabase(Invoice invoice, Warehouse warehouse)
        {
            try
            {

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                DynamicParameters param = new DynamicParameters();
                DynamicParameters param1 = new DynamicParameters();




                param.Add("@DateMade", invoice.DateMade);
                param.Add("@WarehouseID", invoice.WarehouseID);
                param.Add("@DDV", invoice.DDV);
                

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertIntoInvoice";

                cmd.Parameters.Add("@DateMade", SqlDbType.DateTime).Value = invoice.DateMade;
                cmd.Parameters.Add("@WarehouseID", SqlDbType.Int).Value = invoice.WarehouseID;
                cmd.Parameters.Add("@DDV", SqlDbType.Int).Value = invoice.DDV;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection = sqlCon;
                cmd.ExecuteNonQuery();
                
                
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InsertIntoInvoiceProduct";
                int id = Convert.ToInt32(cmd.Parameters["@ID"].Value.ToString());
                cmd1.Parameters.Add("@WarehouseeId", SqlDbType.Int).Value = invoice;
                cmd1.Parameters.Add("@Code", SqlDbType.Int).Value = id;
                cmd1.Connection = sqlCon;
                cmd1.ExecuteNonQuery();

                MessageBox.Show("You did itt !!!");





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
