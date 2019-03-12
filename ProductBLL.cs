using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PCLBBO;
using PCLDAL;

namespace PCLBBL
{
   public class ProductBLL
    {

        public int InsertProduct(Product P)
        {
            int Results;
            ProductDAL dal = new  ProductDAL();
            Results = dal.InsertProduct(P);
            return Results;
        }
        
        public List<Category> GetCategories()
        {       
            ProductDAL dal = new ProductDAL();
            return dal.GetCategories();            
        }
        public List<Product> GetProducts()
        {
            ProductDAL dal = new ProductDAL();
            return dal.GetProducts();
        }
        public int UpdateProduct(Product product)
        {
           ProductDAL dal= new ProductDAL();
           return dal.UpdateProduct(product);
        }

        public Product GetProductDetails(int productId)
        {
            ProductDAL dal = new ProductDAL();
            return dal.GetProductDetails(productId);
        }
        public int DeleteMultipleRecords(List<string> idCollection)
        {
            ProductDAL dal = new ProductDAL();
            return dal.DeleteMultipleRecords(idCollection);
        }

        public List<Product> SelectProducts(int productid)
        {
            ProductDAL dal = new ProductDAL();
            return dal.SelectProducts(productid);
        }
       //public List<Product> GetProductDetails()
       // {
       //     ProductDAL dal = new ProductDAL();
       //     return dal.GetProductDetails();
       // }
        public List<Product >GetProductDetailsByName(string productname)
        {
            ProductDAL dal = new ProductDAL();
            return dal.GetProductDetailsByName(productname);
        }
       

    }

}
