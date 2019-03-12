using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCLDAL;
using PCLBBO;

namespace PCLBBL
{
   public class DisplayBLL
    {
        public int InsertDisplay(Display display)
        {
            int Results;
            DisplayDAL ddal = new DisplayDAL();
            Results = ddal.InsertDisplay(display);
            return Results;
        }
        public List<Display> GetDisplay()
        {
            DisplayDAL ddal = new DisplayDAL();
            return ddal.GetDisplay();
        }

        public int UpdateDisplay(Display display)
        {
            DisplayDAL ddal = new DisplayDAL(); 
            return ddal.UpdateDisplay(display);
        }
        public Display GetDisplayDetails(int displayid)
        {
            DisplayDAL ddal = new DisplayDAL(); 
            return ddal.GetDisplayDetails(displayid);
        }
        public int DeleteMultipleRecordsDisplay(List<string> idCollection)
        {
            DisplayDAL ddal = new DisplayDAL(); 
            return ddal.DeleteMultipleRecordsDisplay(idCollection);
        }
        public List<Display> GetProdModId()
        {
            DisplayDAL ddal = new DisplayDAL(); 
            return ddal.GetProdModId();
        }
    }
}
