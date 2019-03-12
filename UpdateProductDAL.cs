using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PCLBBO;

namespace PCLDAL
{
  public  class UpdateProductDAL
    {
        public void UpdateProduct(Product product)
        {
            //errorCode = null;
            SqlConnection connection = new SqlConnection();
            //SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["PCLBConnection"]);
            connection.ConnectionString = @"Database=ChaseProject;Server=manoj-pc;uid=sa;pwd=password@123";

              // Create a Database object an instantiate it by calling the CreateDatabase method of
                // DatabaseFactory class. The method takes the connection string name as parameter.

                //Database db = DatabaseFactory.CreateDatabase(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING);

                // Create a DbCommand object and instantiate it by calling the GetStoredProcCommand method
                // of Database class. The method creates a Command Object from the Stored Procedure name 
                // and returns it.
                SqlCommand cmd=new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText="USP_UpdateProduct";

                //DbCommand dbCommand = db.GetStoredProcCommand(DBConstants.UPDATE_EXPENSE);

                // adding parameters into the command object
            /////////////////////////////////////////


             SqlParameter p1 = new SqlParameter("@ProductName",product.ProductName);
                  SqlParameter p2 = new SqlParameter("CategoryId",product.CategoryId);
                


                  cmd.Parameters.Add(p1);
                  cmd.Parameters.Add(p2);
       

         int rows =cmd.ExecuteNonQuery();
               connection.Close();
            ///////////////////////////////////////////



            //cmd.Parameters.Add(
            //    db.AddInParameter(dbCommand, DBConstants.EXPENSE_ID_PARAM, DbType.Int32, expData.Id);
            //    db.AddInParameter(dbCommand, DBConstants.EXPENSE_TYPE_ID_PARAM, DbType.Int32, expData.TypeId);
            //    db.AddInParameter(dbCommand, DBConstants.STORE_ID_PARAM, DbType.Int32, expData.StoreId);
            //    db.AddInParameter(dbCommand, DBConstants.EXPENSE_DATE_PARAM, DbType.DateTime, expData.Date);
            //    db.AddInParameter(dbCommand, DBConstants.AMOUNT_PARAM, DbType.Double, expData.Amount);

            //    db.ExecuteNonQuery(dbCommand);

            //}
            //catch (Exception exception)
            //{
            //    Utilities.HandleError(exception);
            //    errorCode = MessageConstants.UPDATE_EXPENSE_ERROR;
            }
        public List<Category> GetCategories()
        {
            List<Category> Categories = new List<Category>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Database=ChaseProject;Server=manoj-pc;uid=sa;pwd=password@123";
            SqlCommand cmd = new SqlCommand("SELECT * FROM Category", connection);
            //new SqlConnection(ConfigurationManager.AppSettings["PCLBConnection"])
            cmd.Connection.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Category category = new Category();
                category.CategoryId = Convert.ToInt32(dataReader["CategoryId"]);
                category.CategoryName = dataReader["CategoryName"].ToString();
                Categories.Add(category);
            }
            return Categories;


        }
        }
    }

