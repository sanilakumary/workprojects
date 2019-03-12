using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCLBBO;
using PCLDAL;

namespace PCLBBL
{
   public class SelloutBLL
    {
       public int InsertSellout(Sellout sellout)
       {
           int Results;
           SelloutDAL sdal = new SelloutDAL();
           Results = sdal.InsertSellout(sellout);
           return Results;
       }
       public List<Sellout> GetSellout()
       {
           SelloutDAL sdal = new SelloutDAL();
           return sdal.GetSellout();
       }

       public int UpdateSellout(Sellout sellout)
       {
           SelloutDAL sdal = new SelloutDAL();
           return sdal.UpdateSellout(sellout);
       }

       public Sellout GetSelloutDetails(int salesid)
       {
           SelloutDAL sdal = new SelloutDAL();
           return sdal.GetSelloutDetails(salesid);
       }
       public List< Sellout> GetManufactDetailsName(string manufactName)
       {
           SelloutDAL sdal = new SelloutDAL();
           return sdal.GetManufactDetailsName(manufactName);
       }
       //public List<Sellout> GetProdModId()
       //{
       //    SelloutDAL sdal = new SelloutDAL();
       //    return sdal.GetProdModId();
       //}
       public int DeleteMultipleRecords(List<string> idCollection)
       {
           SelloutDAL sdal = new SelloutDAL(); 
           return sdal.DeleteMultipleRecords(idCollection);
       }
       //public int InsertDisplay(Sellout sellout)
       //{
       //    int Results;
       //    SelloutDAL sdal = new SelloutDAL();
       //    Results = sdal.InsertDisplay(sellout);
       //    return Results;
       //}
       //public List<Sellout> GetDisplay()
       //{
       //    SelloutDAL sdal = new SelloutDAL();
       //    return sdal.GetDisplay();
       //}

       //public int UpdateDisplay(Sellout sellout)
       //{
       //    SelloutDAL sdal = new SelloutDAL();
       //    return sdal.UpdateDisplay(sellout);
       //}
       //public Sellout GetDisplayDetails(int displayid)
       //{
       //    SelloutDAL sdal = new SelloutDAL();
       //    return sdal.GetDisplayDetails(displayid);
       //}
       //public int DeleteMultipleRecordsDisplay(List<string> idCollection)
       //{
       //    SelloutDAL sdal = new SelloutDAL();
       //    return sdal.DeleteMultipleRecordsDisplay(idCollection);
       //}
       public List<Sellout> GetManufactureId()
       {
           SelloutDAL sdal = new SelloutDAL();
           return sdal.GetManufactureId();
       }
       public List<Manufacturer> GetManufactureName()
       {
           SelloutDAL sdal = new SelloutDAL();
           return sdal.GetManufactureName();

       }
         public List<Model>GetModelName()
         {
             SelloutDAL sdal = new SelloutDAL();
             return sdal.GetModelName();
         }
             
         public List<Product> GetProductName()
         {
             SelloutDAL sdal = new SelloutDAL();
             return sdal.GetProductName();
         }

    }
}
