using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCLBBO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PCLDAL
{
  public class SelloutDAL
    {
      public int InsertSellout(Sellout sellout)
      {
          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                          
              SqlCommand cmdselect = new SqlCommand();
              cmdselect.CommandType = CommandType.StoredProcedure;
              cmdselect.CommandText = "CreateSellout";
              cmdselect.Parameters.Add("@Date", SqlDbType.DateTime).Value = sellout.Date.Date.ToString();
              cmdselect.Parameters.Add("@ManufactureId", SqlDbType.VarChar, 50).Value = sellout.ManufactureId;
              cmdselect.Parameters.Add("@ModelId", SqlDbType.VarChar,50).Value = sellout.ModelId;
              cmdselect.Parameters.Add("@ProductId", SqlDbType.VarChar,50).Value = sellout.ProductId;
              if (sellout.IsActive)
              {
                  cmdselect.Parameters.Add("@IsActive", SqlDbType.Bit).Value = 1;
              }
              else
              {
                  cmdselect.Parameters.Add("@IsActive", SqlDbType.Bit).Value = 0;
              }
              cmdselect.Parameters.Add("@Quantity", SqlDbType.Int, 4).Value = sellout.Quantity;

              cmdselect.Connection = connection;
              connection.Open();
              int Results;
              Results = cmdselect.ExecuteNonQuery();

              return Results;
          }
      }
      public List<Sellout> GetSellout()
      {
          List<Sellout> sellouts = new List<Sellout>();
          
          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              
              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "GetSellout";
              cmd.Connection = connection;
              
              connection.Open();
              SqlDataReader dataReader = cmd.ExecuteReader();
              while (dataReader.Read())
              {
                  Sellout sellout = new Sellout();
                 
                      sellout.SalesId=Convert.ToInt32(dataReader["SalesId"]);
                      
                      sellout.Date = Convert.ToDateTime(dataReader["Date"]);
                      sellout.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                      if (Convert.ToBoolean(dataReader["IsActive"]))
                      {
                          sellout.IsActive = true;
                      }
                      else
                      {
                          sellout.IsActive = false;
                      }
                     
                      sellout.ManufacturerName = dataReader["ManufactureName"].ToString();
                      sellout.ProductName = dataReader["ProductName"].ToString();
                      sellout.ModelName = dataReader["ModelName"].ToString();                     

                      
                  
                 sellouts.Add(sellout);


              }
              return sellouts;
          }
      }
      public int UpdateSellout(Sellout sellout)
      {

          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              
              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = System.Data.CommandType.StoredProcedure;
              cmd.CommandText = "Updatesellout";

             
              SqlParameter p2 = new SqlParameter("@SalesId", sellout.SalesId);
             SqlParameter p3 = new SqlParameter("@Quantity", sellout.Quantity);
              SqlParameter p4 = new SqlParameter("@Date", sellout.Date);
              SqlParameter p5 = new SqlParameter("@IsActive", sellout.IsActive);
              
              SqlParameter p9 = new SqlParameter("@ManufactureId", sellout.ManufactureId);
              SqlParameter p10 = new SqlParameter("@ModelId", sellout.ModelId);
              SqlParameter p11 = new SqlParameter("@ProductId", sellout.ProductId);
             
              cmd.Parameters.Add(p2);
              cmd.Parameters.Add(p3);
              cmd.Parameters.Add(p4);
              cmd.Parameters.Add(p5);
              
              cmd.Parameters.Add(p9);
              cmd.Parameters.Add(p10);
              cmd.Parameters.Add(p11);             

              cmd.Connection = connection;
              connection.Open();
              int rows = cmd.ExecuteNonQuery();
              return rows;
              
          }
      }

      public Sellout GetSelloutDetails(int salesid)
      {
          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
             
              using (SqlCommand cmd = new SqlCommand())
              {
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandText = "GetSelloutDetails";
                  cmd.Parameters.Add("@SalesId", SqlDbType.Int, 4).Value = salesid;
                  cmd.Connection = connection;
                  connection.Open();
                  using (SqlDataReader dataReader = cmd.ExecuteReader())
                  {
                      Sellout sellout = new Sellout();
                      while (dataReader.Read())
                      {
                          
                          sellout.ManufactureId = Convert.ToInt32(dataReader["ManufactureId"]);
                          sellout.ProductName = dataReader["ProductName"].ToString();
                          sellout.ModelName = dataReader["ModelName"].ToString();

                          sellout.ProductId = Convert.ToInt32(dataReader["ProductId"]);

                          sellout.ModelId = Convert.ToInt32(dataReader["ModelId"]);
                          sellout.ManufactureId = Convert.ToInt32(dataReader["ManufactureId"]);

                         if ((bool) dataReader["IsActive"] == true)
                         {
                             sellout.IsActive = true;
                         }
                         else
                         {
                             sellout.IsActive = false;
                         }
                         sellout.SalesId = Convert.ToInt32(dataReader["SalesId"]);
                         sellout.Date = Convert.ToDateTime(dataReader["Date"]);
                         sellout.Quantity = Convert.ToInt32(dataReader["Quantity"]);                         


                      }
                      return sellout;
                  }

              }
          }
      }
      public int DeleteMultipleRecords(List<string> idCollection)
      {
          //Create sql Connection and Sql Command
          StringBuilder sb = new StringBuilder();
          foreach (var item in idCollection)
          {
              sb.Append(item + ",");
          }

          string saleIds = sb.ToString();
          if (saleIds.Length > 0)
          {
              saleIds = saleIds.Substring(0, saleIds.Length - 1);
          }
          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              
              using (SqlCommand cmd = new SqlCommand())
              {
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandText = "Deletesellout";
                  
                  SqlParameter p1 = new SqlParameter("@SalesId",saleIds);
                  cmd.Parameters.Add(p1);
                  cmd.Connection = connection;
                  connection.Open();
                  int rows = cmd.ExecuteNonQuery();
                  return rows;
              }

          }
      }
       
 
    
      public List<Sellout> GetManufactureId()
      {
          List<Sellout> sellouts = new List<Sellout>();

          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              
              SqlCommand cmd = new SqlCommand("SELECT * FROM Manufacturer", connection);
              
              cmd.Connection.Open();
              SqlDataReader dataReader = cmd.ExecuteReader();
              while (dataReader.Read())
              {
                  Sellout sellout = new Sellout();
                  sellout.ManufactureId = Convert.ToInt32(dataReader["ManufactureId"]);
                  sellouts.Add(sellout);
              }
              return sellouts;
          }

      }
      public List<Manufacturer> GetManufactureName()
      {
          List<Manufacturer> manufacts = new List<Manufacturer>();

          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              
              SqlCommand cmd = new SqlCommand("SELECT * FROM Manufacturer", connection);
             
              cmd.Connection.Open();
              SqlDataReader dataReader = cmd.ExecuteReader();
              while (dataReader.Read())
              {
                  Manufacturer manufact = new Manufacturer();
                  manufact.ManufactureId = Convert.ToInt32(dataReader["ManufactureId"]);
                  manufact.ManufactureName = dataReader["ManufactureName"].ToString();
                  manufacts.Add(manufact);
              }
              return manufacts;
          }


      }
      public List<Model> GetModelName()
      {
          List<Model> modellist = new List<Model>();

          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              
              SqlCommand cmd = new SqlCommand("SELECT * FROM M_Model", connection);
              
              cmd.Connection.Open();
              SqlDataReader dataReader = cmd.ExecuteReader();
              while (dataReader.Read())
              {
                  Model model = new Model();
                  model.ModelName = dataReader["ModelName"].ToString();
                  model.ModelId = Convert.ToInt32(dataReader["ModelId"]);

                  modellist.Add(model);
              }
              return modellist;
          }


      }
      public List<Product> GetProductName()
      {
          List<Product> products = new List<Product>();

          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
             
              SqlCommand cmd = new SqlCommand("SELECT * FROM M_Product", connection);
              
              cmd.Connection.Open();
              SqlDataReader dataReader = cmd.ExecuteReader();
              while (dataReader.Read())
              {
                  Product product = new Product();
                  product.ProductId = Convert.ToInt32(dataReader["ProductId"]);
                  product.ProductName = dataReader["ProductName"].ToString();
                  products.Add(product);
              }
              return products;
          }


      }
     
      public List<Sellout >GetManufactDetailsName(string manufactName)
      {
          List<Sellout> selloutlist = new List<Sellout>();
          using (SqlConnection connection = new SqlConnection())
          {
              connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              connection.ConnectionString = @"Database=ChaseProject;Server=manoj-pc;uid=sa;pwd=password@123";
              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "GetManufactureByName";
              cmd.Connection = connection;
              cmd.Parameters.Add("@ManufactureName", SqlDbType.VarChar, 50).Value = manufactName;
              connection.Open();
              SqlDataReader dataReader = cmd.ExecuteReader();
              Sellout sellout = null;
              while (dataReader.Read())
              {
                  sellout = new Sellout();
                  sellout.ManufacturerName = dataReader["ManufactureName"].ToString();
                  sellout.ProductName = dataReader["ProductName"].ToString();
                  sellout.ModelName = dataReader["ModelName"].ToString();
                  sellout.SalesId = Convert.ToInt32(dataReader["SalesId"]);
                  sellout.Date = Convert.ToDateTime(dataReader["Date"]);
                  sellout.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                  sellout.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                  selloutlist.Add(sellout);

              }
              return selloutlist;
          }
      }

    }
}
