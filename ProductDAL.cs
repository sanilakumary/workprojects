using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PCLBBO;
using System.Collections;
using System.Configuration;

namespace PCLDAL
{
    public class ProductDAL
    {
        public int InsertProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmdselect = new SqlCommand();
                cmdselect.CommandType = CommandType.StoredProcedure;
                cmdselect.CommandText = "InsertProd";
                //cmdselect.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = product.ProductId;
                cmdselect.Parameters.Add("@CategoryId", SqlDbType.VarChar, 50).Value = product.CategoryId;
                cmdselect.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = product.ProductName;
                cmdselect.Connection = connection;
                connection.Open();
                int Results;
                Results = cmdselect.ExecuteNonQuery();

                return Results;
            }
        }

        public List<Category> GetCategories()
        {
            List<Category> Categories = new List<Category>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Category", connection);
                
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

        public List<Product> GetProducts()
        {
            List<Product> Products = new List<Product>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
               
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_GetProducts";
                cmd.Connection = connection;
               
                connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.ProductId = Convert.ToInt32(dataReader["ProductId"]);
                    product.ProductName = dataReader["ProductName"].ToString();
                    product.CategoryName = dataReader["CategoryName"].ToString();                    
                    product.CategoryId = dataReader["CategoryId"].ToString();                   
                    Products.Add(product);

                }
                return Products;
            }
        }

        public int UpdateProduct(Product product)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_UpdateProduct";

                SqlParameter p1 = new SqlParameter("@ProductId", product.ProductId);
                SqlParameter p2 = new SqlParameter("@ProductName", product.ProductName);
                SqlParameter p3 = new SqlParameter("CategoryId", product.CategoryId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                cmd.Connection = connection;
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
        }


        public Product GetProductDetails(int productId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
               
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_GetProductDetails";
                    cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = productId;
                    cmd.Connection = connection;
                    connection.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        Product product = new Product();
                        while (dataReader.Read())
                        {

                            product.ProductId = Convert.ToInt32(dataReader["ProductId"]);
                            product.ProductName = dataReader["ProductName"].ToString();
                            product.CategoryId = dataReader["CategoryId"].ToString();

                        }
                        return product;
                    }

                }
            }

        }


        public int DeleteMultipleRecords(List<string> idCollection)
        {
           
            StringBuilder sb = new StringBuilder();
            foreach (var item in idCollection)
            {
                sb.Append(item + ",");
            }

            string productIds = sb.ToString();
            if (productIds.Length > 0)
            {
                productIds = productIds.Substring(0, productIds.Length - 1);
            }
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                            
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_DeleteProduct";                    
                    SqlParameter p1 = new SqlParameter("@ProductId", productIds);
                    cmd.Parameters.Add(p1);
                    cmd.Connection = connection;
                    connection.Open();                           
                    int rows=cmd.ExecuteNonQuery();
                    return rows;
                }

            }

        }

        public List<Product> SelectProducts(int productid)
        {
            List<Product> Products = new List<Product>();



            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                //connection.ConnectionString = @"Database=ChaseProject;Server=manoj-pc;uid=sa;pwd=password@123";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectProducts";
                cmd.Connection = connection;
                cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = productid;
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
                    product.CategoryId = dataReader["CategoryId"].ToString();
                    //category.CategoryId = Convert.ToInt32(dataReader["CategoryId"]);
                    //category.CategoryName = dataReader["CategoryName"].ToString();
                    Products.Add(product);


                }
                return Products;
            }
        }

        
        
        public List<Product> GetProductDetailsByName(string productName)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                //connection.ConnectionString = @"Database=ChaseProject;Server=manoj-pc;uid=sa;pwd=password@123";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetProductDetailsByName";
                cmd.Connection = connection;
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = productName;
                connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                Product product = null;
                while (dataReader.Read())
                {
                    product = new Product();
                    product.ProductId = Convert.ToInt32(dataReader["ProductId"]);
                    product.ProductName = dataReader["ProductName"].ToString();
                    product.CategoryName = dataReader["CategoryName"].ToString();
                    product.CategoryId = dataReader["CategoryId"].ToString();
                    products.Add(product);
                }
                return products;
            }
        }
    }
}