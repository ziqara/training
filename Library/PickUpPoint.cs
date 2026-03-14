using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PickUpPoint
    {
        public int id { get; set; }
        public int postal_index { get; set; }
        public string address { get; set; }

        public override string ToString()
        {
            return $"{address} (индекс: {postal_index})";
        }
    }
}