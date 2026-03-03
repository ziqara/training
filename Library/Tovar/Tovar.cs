using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tovar
{
    public class Tovar
    {
       public string articul {  get; set; }
       public string name { get; set; }
       public string unit { get; set; }
       public int price { get; set; }
       public string supplier { get; set; }
       public string manufacturer { get; set; }
       public string category { get; set; }
       public int discount { get; set; }
       public int stockquantity { get; set; }
       public string description { get; set; }
       public string picture { get; set; }

        public Tovar(string articul_)
        {
            articul = articul_;
        }
    }
}
