using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            btnIzbrisiStavka.Enabled = false;
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
            cbWarehouses.DataSource = list;
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
            lbFakturi.Items.Clear();
            listanjeMagacini();
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

                int kolicina = p.quantity;
                int kolNaracka;
                int.TryParse(tbKolicina.Text, out kolNaracka);
                p.Kolicina = kolNaracka;
                if(kolNaracka > kolicina)
                {
                    MessageBox.Show("Нема доволно продукти на залиха");
                }
                else if(kolNaracka <= 0)
                {
                    MessageBox.Show("Внесете валиден број за количина");
                    tbKolicina.Focus();
                }
                else 
                {
                    lbFakturi.Items.Add(cbProizvodi.SelectedItem);
                    tbIme.Text = p.Name;
                    tbOpis.Text = p.Descriptionn;
                    tbKolicina1.Text = kolicina.ToString();
                    tbCena.Text = p.Price.ToString();
                    btnIzbrisiStavka.Enabled = true;
                }
                
            }
        }

        private void btnIzbrisiStavka_Click(object sender, EventArgs e)
        {
            if(lbFakturi.SelectedIndex != -1)
            {
                lbFakturi.Items.RemoveAt(lbFakturi.SelectedIndex);
                if(lbFakturi.Items.Count == 0)
                {
                    btnIzbrisiStavka.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Избери ставка за бришење");
            }
        }

        private void btnGenerirajFaktura_Click(object sender, EventArgs e)
        {
            try
            {

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                DynamicParameters param = new DynamicParameters();
                DynamicParameters param1 = new DynamicParameters();



                
                DateTime datum = calendar.SelectionRange.Start;
                Warehouse warehouse = (Warehouse)cbMagacini.SelectedItem;
                int kolicina,DDV,FakturaBroj;
                int.TryParse(tbKolicina.Text,out kolicina);
                int.TryParse(tbDDV.Text, out DDV);
                int.TryParse(tbFakturaBroj.Text, out FakturaBroj);
                if (kolicina <= 0)
                {
                    MessageBox.Show("Внеси валиден број за количина");
                    return;
                }
                if (DDV <= 0)
                {
                    MessageBox.Show("Внеси валиден број за ДДВ");
                    return;
                }
               
                
                Invoice invoice = new Invoice(datum, warehouse.ID, DDV);

                
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


               
                
                int id = Convert.ToInt32(cmd.Parameters["@ID"].Value.ToString());
                int cenaSoDDV = 0;
                int cena = 0;

                for (int i = 0; i < lbFakturi.Items.Count; i++)
                {
                    Product p = (Product)lbFakturi.Items[i];
                    cena += p.Price * kolicina; 
                    SqlCommand cmd1 = new SqlCommand("insert into Invoice_Product(InvoiceId,ProducttId)" +
                        "values ('" + id + "'," + p.Code + ")", sqlCon);
                    cmd1.ExecuteNonQuery();
                }
                int DDVCena = Convert.ToInt32(cena * DDV / 100);
                cenaSoDDV = cena + DDVCena;
                invoice.Cena = cena;
                invoice.DDVCena = DDVCena;
                invoice.CenaSoDDV = cenaSoDDV;
                SqlCommand update = new SqlCommand("update Invoice set FakturaBroj=@FakturaBroj, Cena=@Cena,cenaSoDDV=@cenaSoDDV,DDVCena=@DDVCena where ID=@ID", sqlCon);
                update.Parameters.AddWithValue("@FakturaBroj", FakturaBroj);
                update.Parameters.AddWithValue("@Cena", cena);
                update.Parameters.AddWithValue("@cenaSoDDV", cenaSoDDV);
                update.Parameters.AddWithValue("@DDVCena", DDVCena);
                update.Parameters.AddWithValue("@ID", id);
                
                update.ExecuteNonQuery();
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

        public void listanjeMagacini()
        {
           
            btnIzbrisiStavka.Enabled = false;
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

        private void cbWarehouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbInvoice.DataSource = null;
            lbInvoice.Items.Clear();
            if (cbWarehouses.SelectedIndex != -1)
            {
                DynamicParameters param = new DynamicParameters();
                Warehouse w = (Warehouse)cbMagacini.SelectedItem;
                int index = w.ID;

                param.Add("@ID", index);

                List<Invoice> list = sqlCon.Query<Invoice>("InvoiceList", param,
                    commandType: CommandType.StoredProcedure).ToList();
                lbInvoice.DataSource = list;
            }
        }

        private void btnVcitaj_Click(object sender, EventArgs e)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                if(cbWarehouses.SelectedIndex != -1 && lbInvoice.SelectedIndex != -1)
                {
                    Invoice i = (Invoice)lbInvoice.SelectedItem;

                    string query = "Select pr.Name,i.FakturaBroj,i.Cena,i.DDVCena,i.CenaSoDDV " +
                        "From Invoice i, Product pr, Invoice_Product inv " +
                        "Where i.ID = inv.InvoiceId and pr.Code = inv.ProducttId";
                   fakturaBindingSource.DataSource = db.Query<Faktura>(query, commandType: CommandType.Text); 
                }
                else
                {
                    fakturaBindingSource.DataSource = null; 
                    
                }

                
            }
        }

        private void lbInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                if (cbWarehouses.SelectedIndex != -1 && lbInvoice.SelectedIndex != -1)
                {
                    Invoice i = (Invoice)lbInvoice.SelectedItem;
                   
                    string query = "Select pr.Name,i.FakturaBroj,i.Cena,i.DDVCena,i.CenaSoDDV " +
                        "From Invoice i, Product pr, Invoice_Product inv " +
                        $"Where {i.ID} = inv.InvoiceId and pr.Code = inv.ProducttId";
                    fakturaBindingSource.DataSource = db.Query<Faktura>(query, commandType: CommandType.Text);
                }


            }
        }
    }
}
