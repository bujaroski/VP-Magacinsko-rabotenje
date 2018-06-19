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
        public static Warehouse Magacin { get; set; }
        public static bool IzmeniMagacin { get; set; }
        public static bool IzmeniProizvod { get; set; }
        public static Product Proizvod { get; set; }
        SqlDataAdapter adapt;
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-0S9U6FP\MSSQLSERVER2014;initial Catalog=MarketEvidence;Integrated Security=True");
        int id = 0;
        public Form1()
        {
            InitializeComponent();
            listWarehouses();
            lbMagacini.SelectedItem = null;
            listProducts();
            lbProizvodVoMagacin.SelectedItem = null;
        } 
        

        void listWarehouses()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SearchText", "");
            List<Warehouse> list = sqlCon.Query<Warehouse>("WarehouseViewAllOrSearch", param,
                commandType: CommandType.StoredProcedure).ToList<Warehouse>();
            lbMagacini.DataSource = list;
            cbMagacini.DataSource = list;
        }

        void listProducts()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SearchText", "");
            List<Product> list = sqlCon.Query<Product>("ProductViewAllOrSearch", param,
                commandType: CommandType.StoredProcedure).ToList<Product>();
            lbProizvodVoMagacin.DataSource = list;
            cbProizvodi.DataSource = list;
        }

        private void lbMagacini_SelectedIndexChanged(object sender, EventArgs e)
        {
          if(lbMagacini.SelectedItem != null)
            {
                DynamicParameters param = new DynamicParameters();
                Warehouse w = (Warehouse)lbMagacini.SelectedItem;
                int index = w.ID;

                param.Add("@ID", index);

                List<Product> list = sqlCon.Query<Product>("ProductWarehouseList", param,
                    commandType: CommandType.StoredProcedure).ToList();
                lbProizvodVoMagacin.DataSource = list;
            }
           
            
        }

        private void btnDodadiMagacin_Click(object sender, EventArgs e)
        {
            AddWarehouseForm form2 = new AddWarehouseForm();
            form2.Text = "Додади нов магацин";
            if (form2.ShowDialog() == DialogResult.OK)
            {
                WarehouseAdapterSQL.SaveToDatabase(form2.magacin);
                listWarehouses();
            }
        }

        private void btnIzmeniMagacin_Click(object sender, EventArgs e)
        {
            AddWarehouseForm form2 = new AddWarehouseForm();
            
            form2.Text = "Измени магацин";
            if (lbMagacini.SelectedIndex != -1)
            {
                Magacin = (Warehouse)lbMagacini.SelectedItem;
                IzmeniMagacin = true;
                
                
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

        private void btnIzbrisiMagacin_Click(object sender, EventArgs e)
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

        private void btnDodadiProizvod_Click(object sender, EventArgs e)
        {
            if (lbMagacini.SelectedIndex == -1)
            {
                MessageBox.Show("Odberete magacin");
            }
            else
            {
                ProductAddForm form2 = new ProductAddForm();
                form2.Text = "Додади нов продукт";
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    Warehouse warehouse = (Warehouse)lbMagacini.SelectedItem;
                    ProductAdapterSQL.SaveToDatabase(form2.product, warehouse);
                    listProducts();
                }
            }
        }

        private void btnIzmeniProizvod_Click(object sender, EventArgs e)
        {
            ProductAddForm form2 = new ProductAddForm();
            form2.Text = "Измени продукт";
            if(lbMagacini.SelectedIndex == -1)
            {
                MessageBox.Show("Ве молиме изберете магацин од листата", "Одберете магацин");
            }
            else if (lbProizvodVoMagacin.SelectedIndex == -1)
            {
                MessageBox.Show("Ве молиме изберете производ од листата", "Одберете производ");
            }
            else 
            {
                Proizvod = (Product)lbProizvodVoMagacin.SelectedItem;
                IzmeniProizvod = true;
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    ProductAdapterSQL.EditToDatabase(form2.product, lbProizvodVoMagacin);
                    listProducts();
                }
                   
            }

        }

        private void btnIzbrisiProizvod_Click(object sender, EventArgs e)
        {
            if (lbProizvodVoMagacin.SelectedItem != null)
            {
                ProductAdapterSQL.DeleteFromDatabase(lbProizvodVoMagacin);
                listProducts();
            }
            else
            {
                MessageBox.Show("Ве молиме одберете магацин од листата", "Одберете магацин");
            }
        }

        private void cbMagacini_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbMagacini.SelectedItem != null)
            {
                cbProizvodi.Text = "";
                DynamicParameters param = new DynamicParameters();
                Warehouse w = (Warehouse)cbMagacini.SelectedItem;
                int index = w.ID;

                param.Add("@ID", index);
                
                List<Product> list = sqlCon.Query<Product>("ProductWarehouseList", param,
                    commandType: CommandType.StoredProcedure).ToList();
                cbProizvodi.DataSource = list;
            }
        }

        private void btnDodadi_Click(object sender, EventArgs e)
        {
            if(cbMagacini.SelectedIndex == -1)
            {
                MessageBox.Show("Ве молиме одберете магацин од листата", "Одберете магацин");
            }
            else if(cbProizvodi.SelectedIndex == -1)
            {
                MessageBox.Show("Ве молиме одберете производ од листата", "Одберете производ");
            }
            else
            {
                
                Product p = (Product)cbProizvodi.SelectedItem;
                lbFakturi.Items.Add(cbProizvodi.SelectedItem);
                tbIme.Text = p.Name;
                tbOpis.Text = p.Descriptionn;
                tbKolicina1.Text = p.quantity.ToString();
                tbCena.Text = p.Price.ToString();
            }
        }
    }
}
