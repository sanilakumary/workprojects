using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCLBBO;
using PCLDAL;

namespace PCLBBL
{
   public class ShowProductBLL
    {
        public List<Product> GetProducts()
        {
            ShowProductDAL sdal = new ShowProductDAL();
            return sdal.GetProducts();
        }   
    }
}
