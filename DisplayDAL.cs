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
    public class DisplayDAL
    {

        public int InsertDisplay(Display display)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                //connection.ConnectionString=ConfigurationSettings.
                //PCLBConnection

                SqlCommand cmdselect = new SqlCommand();
                cmdselect.CommandType = CommandType.StoredProcedure;
                cmdselect.CommandText = "CreateDisplay";
                //cmdselect.Parameters.Add("@SalesId", SqlDbType.Int, 4).Value = sellout.SalesId;
                //cmdselect.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = sellout.ProductId;
                cmdselect.Parameters.Add("@Date", SqlDbType.DateTime).Value = display.Date.Date.ToString();
                cmdselect.Parameters.Add("@ProdModId", SqlDbType.Int, 4).Value = display.ProdModId;
                //cmdselect.Parameters.Add("@ManufactureId", SqlDbType.Int, 4).Value = sellout.ManufactureId;
                //cmdselect.Parameters.Add("@ModelId", SqlDbType.Int, 4).Value = sellout.ModelId;

                cmdselect.Parameters.Add("@Quantity", SqlDbType.Int, 4).Value = display.Quantity;

                cmdselect.Parameters.Add("@ManufactureName", SqlDbType.VarChar, 50).Value = display.ManufacturerName;

                cmdselect.Connection = connection;
                connection.Open();
                int Results;
                Results = cmdselect.ExecuteNonQuery();

                return Results;
            }
        }
        public List<Display> GetDisplay()
        {
            List<Display> displaydet = new List<Display>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetDisplay";
                cmd.Connection = connection;
                //new SqlConnection(ConfigurationManager.AppSettings["PCLBConnection"])
                connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Display display = new Display();
                    display.ManufacturerName = dataReader["ManufactureName"].ToString();
                    display.ProdModId = Convert.ToInt32(dataReader["ProdModId"]);
                    display.Quantity = Convert.ToInt32(dataReader["Quantity"]);

                    display.Date = Convert.ToDateTime(dataReader["Date"]);
                    display.DisplayId = Convert.ToInt32(dataReader["Displayid"]);

                    displaydet.Add(display);


                }
                return displaydet;
            }
        }
        public int UpdateDisplay(Display display)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDisplay";

                SqlParameter p1 = new SqlParameter("@ProdModId", display.ProdModId);
                SqlParameter p2 = new SqlParameter("@Date", display.Date);
                SqlParameter p3 = new SqlParameter("@ManufactureName", display.ManufacturerName);
                SqlParameter p4 = new SqlParameter("@Quantity", display.Quantity);
                SqlParameter p5 = new SqlParameter("@Displayid", display.DisplayId);


                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);



                //cmd.Parameters.Add(p3);

                cmd.Connection = connection;
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows;

            }
        }
        public Display GetDisplayDetails(int displayid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetDisplayDetails";
                    cmd.Parameters.Add("@Displayid", SqlDbType.Int, 4).Value = displayid;
                    cmd.Connection = connection;
                    connection.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        Display display = new Display();
                        while (dataReader.Read())
                        {
                            display.DisplayId = (int)dataReader["Displayid"];
                            display.ManufacturerName = dataReader["ManufactureName"].ToString();
                            display.ProdModId = Convert.ToInt32(dataReader["ProdModId"]);
                            display.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                            display.Date = Convert.ToDateTime(dataReader["Date"]);
                        }
                        return display;
                    }

                }
            }
        }
        public int DeleteMultipleRecordsDisplay(List<string> idCollection)
        {
            //Create sql Connection and Sql Command
            StringBuilder sb = new StringBuilder();
            foreach (var item in idCollection)
            {
                sb.Append(item + ",");
            }

            string prodmodids = sb.ToString();
            if (prodmodids.Length > 0)
            {
                prodmodids = prodmodids.Substring(0, prodmodids.Length - 1);
            }
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteDisplay";
                    //cmd.Parameters.Add("@ProductId", , 4).Value = product.ProductId;
                    SqlParameter p1 = new SqlParameter("@DisplayId", prodmodids);


                    cmd.Parameters.Add(p1);
                    cmd.Connection = connection;
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }

            }
        }
        public List<Display> GetProdModId()
        {
            List<Display> displays = new List<Display>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmd = new SqlCommand("SELECT ProdModId FROM Display", connection);
                //new SqlConnection(ConfigurationManager.AppSettings["PCLBConnection"])
                cmd.Connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Display display = new Display();
                    display.ProdModId = Convert.ToInt32(dataReader["ProdModId"]);
                    displays.Add(display);
                }
                return displays;
            }


        }
    }
}
