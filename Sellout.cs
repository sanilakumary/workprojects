using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCLBBO
{
   public class Sellout
    {
        public int SalesId { get; set; }
        public DateTime Date { get; set; }
        public int ProdModId { get; set; }
        public int ManufactureId { get; set; }
        public string ModelName{ get; set; }
        public string ProductName { get; set; }
         public int ProductId { get; set; }
        public int ModelId { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public string ManufacturerName { get; set; }
        public int DisplayId { get; set; }
    }
}
