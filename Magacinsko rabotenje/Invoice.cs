using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magacinsko_rabotenje
{
    public class Invoice
    {
        public int ID { get; set; }
        public int FakturaBroj { get; set; }
        public DateTime DateMade { get; set; }
        public int WarehouseID { get; set; }
        public int DDV { get; set; }
        public int Cena { get; set; }
        public int CenaSoDDV { get; set; }
        public int DDVCena { get; set; }
       
        public Invoice()
        {

        }
        public Invoice(DateTime dateMade, int warehouseID, int dDV)
        {
            
            DateMade = dateMade;
            WarehouseID = warehouseID;
            DDV = dDV;
        }
        public override string ToString()
        {
            return String.Format("Фактура број {0} Цена без ДДВ {1}, ДДВ {2}, Вкупно: {3}",FakturaBroj, Cena, DDVCena, CenaSoDDV);
        }


    }
}
