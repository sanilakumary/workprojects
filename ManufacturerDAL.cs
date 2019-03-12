using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PCLBBO;
using System.Configuration;


namespace PCLDAL
{
   public class ManufacturerDAL
    {
        public int InsertManufacturer(Manufacturer manufacturer)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                SqlCommand cmdselect = new SqlCommand();
                cmdselect.CommandType = CommandType.StoredProcedure;
                cmdselect.CommandText = "CreateManufacturer";
                //cmdselect.Parameters.Add("@ManufactureId", SqlDbType.Int, 4).Value = manufacturer.ManufactureId;
                cmdselect.Parameters.Add("@ManufactureName", SqlDbType.VarChar, 50).Value = manufacturer.ManufactureName;

                cmdselect.Connection = connection;
                connection.Open();
                int Results;
                Results = cmdselect.ExecuteNonQuery();

                return Results;
            }
        }

        public List<Manufacturer> GetManufacturer()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();



            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetManufacturer";
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Manufacturer manufacturer = new Manufacturer();
                    manufacturer.ManufactureId = Convert.ToInt32(dataReader["ManufactureId"]);
                    manufacturer.ManufactureName = dataReader["ManufactureName"].ToString();
                    manufacturers.Add(manufacturer);


                }
                return manufacturers;
            }
        }

        public int UpdateManufacturer(Manufacturer manufacturer)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_UpdateManufacture";

                SqlParameter p1 = new SqlParameter("@ManufactureId", manufacturer.ManufactureId);
                SqlParameter p2 = new SqlParameter("@ManufactureName", manufacturer.ManufactureName);
                
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
               

                cmd.Connection = connection;
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            
              }
        public Manufacturer GetManufactureDetails(int manufactureId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_GetmanufactureDetails";
                    cmd.Parameters.Add("@ManufactureId", SqlDbType.Int, 4).Value = manufactureId;
                    cmd.Connection = connection;
                    connection.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        Manufacturer manufacturer = new Manufacturer();
                        while (dataReader.Read())
                        {

                            manufacturer.ManufactureId =Convert.ToInt32(dataReader["ManufactureId"]);
                            manufacturer.ManufactureName = dataReader["ManufactureName"].ToString();

                           
                        }
                        return manufacturer;
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

            string manufactureIds = sb.ToString();
            if (manufactureIds.Length > 0)
            {
                manufactureIds = manufactureIds.Substring(0, manufactureIds.Length - 1);
            }
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteManufacturer";
                    SqlParameter p1 = new SqlParameter("@ManufactureId", manufactureIds);
                    cmd.Parameters.Add(p1);
                    cmd.Connection = connection;
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }

            }
        }
      
       
        public List<Manufacturer> GetManufactDetailsByName(string manufactname)
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
               
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetManufactureName";
                cmd.Connection = connection;
                cmd.Parameters.Add("@ManufactureName", SqlDbType.VarChar, 50).Value = manufactname;
                connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                Manufacturer manufacturer = null;
                while (dataReader.Read())
                {
                    manufacturer = new Manufacturer();
                    manufacturer.ManufactureId = Convert.ToInt32(dataReader["ManufactureId"]);
                    manufacturer.ManufactureName = dataReader["ManufactureName"].ToString();
                    manufacturers.Add(manufacturer);
                }
                return manufacturers;
            }
        }

    }
}
