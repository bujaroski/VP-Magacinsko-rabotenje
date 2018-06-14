using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magacinsko_rabotenje
{
    [Serializable]
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Descriptionn { get; set; }
        public int Price { get; set; }
        public int quantity { get; set; }

        public Product() { }
        public Product(string Name,string Description, int Price, int quantity)
        {
            this.Name = Name;
            this.Descriptionn = Description;
            this.Price = Price;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2}ден. залиха:{3}", Code, Name, Price, quantity);
        }


    }
}
