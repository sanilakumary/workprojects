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
   public  class ModelDAL
    {
       public int InsertModel(Model model)
       {
           using (SqlConnection connection = new SqlConnection())
           {
               connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
               SqlCommand cmdselect = new SqlCommand();
               cmdselect.CommandType = CommandType.StoredProcedure;
               cmdselect.CommandText = "InsertModel";
               //cmdselect.Parameters.Add("@ModelId", SqlDbType.Int, 4).Value = model.ModelId;
               cmdselect.Parameters.Add("@ModelName", SqlDbType.VarChar, 50).Value = model.ModelName;
               cmdselect.Parameters.Add("@ModelCode", SqlDbType.VarChar, 50).Value = model.ModelCode;

               cmdselect.Connection = connection;
               connection.Open();
               int Results;
               Results = cmdselect.ExecuteNonQuery();

               return Results;
           }
       }
       public List<Model> GetModel()
       {
           List<Model> models= new List<Model>();



           using (SqlConnection connection = new SqlConnection())
           {
               connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              
               SqlCommand cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "GetModel";
               cmd.Connection = connection;
              // new SqlConnection(ConfigurationManager.AppSettings["PCLBConnection"])
               connection.Open();
               SqlDataReader dataReader = cmd.ExecuteReader();
               while (dataReader.Read())
               {
                   Model model = new Model();
                   model.ModelId = Convert.ToInt32(dataReader["ModelId"]);
                   model.ModelName = dataReader["ModelName"].ToString();
                   model.ModelCode = dataReader["ModelCode"].ToString();
                   models.Add(model);


               }
               return models;
           }
       }
       public int UpdateModel(Model model)
       {

           using (SqlConnection connection = new SqlConnection())
           {
               connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
              
               SqlCommand cmd = new SqlCommand();
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "UpdateModel";

               SqlParameter p1 = new SqlParameter("@ModelId", model.ModelId);
               SqlParameter p2 = new SqlParameter("@ModelName", model.ModelName);
               SqlParameter p3 = new SqlParameter("@ModelCode", model.ModelCode);
               
               cmd.Parameters.Add(p1);
               cmd.Parameters.Add(p2);
               cmd.Parameters.Add(p3);

               cmd.Connection = connection;
               connection.Open();
               int rows = cmd.ExecuteNonQuery();
               return rows;
           }
           
       }
       public Model GetModelDetails(int modelId)
       {
           using (SqlConnection connection = new SqlConnection())
           {
               connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
               
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "GetmodelDetails";
                   cmd.Parameters.Add("@ModelId", SqlDbType.Int, 4).Value = modelId;
                   cmd.Connection = connection;
                   connection.Open();
                   using (SqlDataReader dataReader = cmd.ExecuteReader())
                   {
                       Model model = new Model();
                       while (dataReader.Read())
                       {

                           model.ModelId = Convert.ToInt32(dataReader["ModelId"]);
                           model.ModelName = dataReader["ModelName"].ToString();
                           model.ModelCode = dataReader["ModelCode"].ToString();                           

                       }
                       return model;
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

           string modelIds = sb.ToString();
           if (modelIds.Length > 0)
           {
               modelIds = modelIds.Substring(0, modelIds.Length - 1);
           }
           using (SqlConnection connection = new SqlConnection())
           {
               connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
               
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "DeleteModel";                   
                   SqlParameter p1 = new SqlParameter("@ModelId", modelIds);
                   cmd.Parameters.Add(p1);
                   cmd.Connection = connection;
                   connection.Open();
                   int rows = cmd.ExecuteNonQuery();
                   return rows;
               }

           }
       }
   
           public List<Model> GetModelDetailsByName(string modelname)
        {
            List<Model> models = new List<Model>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
               
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetModelByName";
                cmd.Connection = connection;
                cmd.Parameters.Add("@ModelName", SqlDbType.VarChar, 50).Value = modelname;
                connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                 Model model = new Model();
                while (dataReader.Read())
                {
                    
                    model.ModelId = Convert.ToInt32(dataReader["ModelId"]);
                    model.ModelName = dataReader["ModelName"].ToString();
                    model.ModelCode = dataReader["ModelCode"].ToString();
                    models.Add(model);
                   
                }
                return models;
            }
        }

    }
}
