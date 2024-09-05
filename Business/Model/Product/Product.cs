using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model.Product
{
    public class Product
    {
        public int Product_Id { get; set; }
        public string? Product_Name { get; set; }
        public string? List_Price { get; set; }
        public string? Model_Year { get; set; }
    }
}
