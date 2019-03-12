using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCLDAL;
using PCLBBO;

namespace PCLBBL
{
    public class UpdateProductBLL
    {


        public void UpdateProduct(Product product)
        {
            UpdateProductDAL UDAL = new UpdateProductDAL();
            UDAL.UpdateProduct(product);
        }
    }

}
