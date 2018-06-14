using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magacinsko_rabotenje
{
    [Serializable]
    public class Warehouse
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Warehouse() { }
        public Warehouse( string Name)
        {
            
            this.Name = Name;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", ID, Name);
        }
    }
}
