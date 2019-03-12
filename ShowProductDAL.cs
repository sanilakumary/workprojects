using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PCLBBO;
namespace PCLDAL
{
    public class ShowProductDAL
    {

        public List<Product> GetProducts()
        {
            List<Product> Products = new List<Product>();
           


            SqlConnection connection = new SqlConnection();
            //SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["PCLBConnection"]);
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "USP_GetProducts";
            cmd.Connection = connection;
            //new SqlConnection(ConfigurationManager.AppSettings["PCLBConnection"])
            connection.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Product product = new Product();
                product.ProductId = Convert.ToInt32(dataReader["ProductId"]);
                product.ProductName = dataReader["ProductName"].ToString();

                product.CategoryName = dataReader["CategoryName"].ToString();
                //product.CategoryId =int(dataReader["CategoryId"]);
               product.CategoryId =dataReader["CategoryId"].ToString();
                //category.CategoryId = Convert.ToInt32(dataReader["CategoryId"]);
                //category.CategoryName = dataReader["CategoryName"].ToString();
                Products.Add(product);
                

            }
            return Products;
        }
    }
}
