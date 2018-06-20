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
    public class ProductAdapterSQL
    {
        public static SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-AGB019C\SQLEXPRESS;initial Catalog=MarketEvidence;Integrated Security=True");
        public static int id = 0;

        public static void SaveToDatabase(Product product,Warehouse warehouse)
        {
            try
            {
                
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                DynamicParameters param = new DynamicParameters();
                DynamicParameters param1 = new DynamicParameters();
               
                

               
                param.Add("@Name", product.Name);
                param.Add("@Description", product.Descriptionn);
                param.Add("@Price", product.Price);
                param.Add("@quantity", product.quantity);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertIntoProducts";
                
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = product.Descriptionn;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = product.Price;
                cmd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = product.quantity;
                cmd.Parameters.Add("@Code", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection = sqlCon;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InsertIntoWarehouseProduct";
                int id = Convert.ToInt32(cmd.Parameters["@Code"].Value.ToString());
                cmd1.Parameters.Add("@WarehouseeId", SqlDbType.Int).Value = warehouse.ID;
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

        public static void EditToDatabase(Product product, ListBox lbProizvodi)
        {
            SqlCommand cmd;
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                DynamicParameters param = new DynamicParameters();
                //param.Add("@ID", id);
                //param.Add("@Name", form2.wh);
                cmd = new SqlCommand("update Product set Name=@Name, Descriptionn=@Descriptionn, Price=@Price, quantity=@quantity where Code=@Code", sqlCon);
                //sqlCon.Execute("WarehouseAddorEdit", param, commandType: CommandType.StoredProcedure);
                Product nov = (Product)lbProizvodi.SelectedItem;
                cmd.Parameters.AddWithValue("@Code", nov.Code);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Descriptionn", product.Descriptionn);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@quantity", product.quantity);
                cmd.ExecuteNonQuery();
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

        public static void DeleteFromDatabase(ListBox lbProizvodi)
        {
            SqlCommand cmd;
            sqlCon.Open();
            cmd = new SqlCommand("delete Product where Code=@Code", sqlCon);
            Product product = (Product)lbProizvodi.SelectedItem;
            cmd.Parameters.AddWithValue("@Code", product.Code);
            cmd.ExecuteNonQuery();
            sqlCon.Close();

        }
    }
}
