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
    public class WarehouseAdapterSQL
    {
        public static SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-AGB019C\SQLEXPRESS;initial Catalog=MarketEvidence;Integrated Security=True");
        public static int id = 0;

        public static void SaveToDatabase(Warehouse warehouse)
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

        public static void EditToDatabase(Warehouse warehouse,ListBox lbMagacini)
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
                cmd.Parameters.AddWithValue("@Name", warehouse.Name);
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

        public static void DeleteFromDatabase(ListBox lbMagacini)
        {
            SqlCommand cmdIzbrisiWarehouse,cmdIdProizvodi,cmdIzbrisiProizvodi,cmdIzbrisiWarehouse_Product,cmd;
            sqlCon.Open();
            // cmd = new SqlCommand("delete Warehouse where ID=@ID", sqlCon);
            cmdIdProizvodi = new SqlCommand("select Code from Product where Code IN(select ProductId from Warehouse_Product " +
                "where WarehouseeId = @ID) ",sqlCon);

            cmdIzbrisiWarehouse_Product = new SqlCommand("delete Warehouse_Product where WarehouseeId=@ID", sqlCon);
           // cmdIzbrisiProizvodi = new SqlCommand("delete Product where Code IN @niza",sqlCon);
            
            cmdIzbrisiWarehouse = new SqlCommand("delete Warehouse where ID=@ID", sqlCon);
            cmd = new SqlCommand("delete Invoice where WarehouseId=@ID", sqlCon);
            Warehouse warehouse = (Warehouse)lbMagacini.SelectedItem;
            cmdIdProizvodi.Parameters.AddWithValue("@ID", warehouse.ID);
            SqlDataReader reader = cmdIdProizvodi.ExecuteReader();
            List<Int32> idProizvodi = new List<int>();
            while (reader.Read())
            {
                idProizvodi.Add(Convert.ToInt32(reader[0]));
            }
            reader.Close();
            cmdIzbrisiProizvodi = new SqlCommand(String.Format("delete Product where Code IN({0})", String.Join(",", idProizvodi)),sqlCon);

            cmdIzbrisiWarehouse_Product.Parameters.AddWithValue("@ID", warehouse.ID);
           // cmdIzbrisiProizvodi.Parameters.AddWithValue("@idProizvodi", idProizvodi);
            cmdIzbrisiWarehouse.Parameters.AddWithValue("@ID",warehouse.ID);

            cmd.Parameters.AddWithValue("@ID", warehouse.ID);
            cmd.ExecuteNonQuery();

            cmdIzbrisiWarehouse_Product.ExecuteNonQuery();
           // cmdIzbrisiProizvodi.ExecuteNonQuery();
            cmdIzbrisiWarehouse.ExecuteNonQuery();


            //  cmd = new SqlCommand("delete Warehouse_Product where WarehouseeId=@ID",sqlCon);
            // Warehouse warehouse = (Warehouse)lbMagacini.SelectedItem;
            //cmd.Parameters.AddWithValue("@ID", warehouse.ID);
            // cmd.ExecuteNonQuery();
            sqlCon.Close();
            
        }
    }
}
