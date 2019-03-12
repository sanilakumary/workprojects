using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CustomUpholstery.BusinessObject;
using System.Data.SqlClient;

namespace CustomUpholstery.DataAccessLayer
{
    public class AttributeDal
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["CustomUpholstery"].ToString();
                }

                return _connectionString;
            }
            private set { _connectionString = value; }
        }
        public List<AttributeDes> GetAllAttributes()
        {
            List<AttributeDes> attributes = new List<AttributeDes>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConnectionString;

                using (SqlCommand cmd = new SqlCommand("GetAttributes", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        AttributeDes attribute;
                        while (dataReader.Read())
                        {
                            attribute = new AttributeDes();

                            //iconicdealer.AuthenticomLastPollingDate = String.Format("{0:yyyy-MM-dd}", dataReader["AuthenticomLastPollingDate"]);
                            attribute.AttributeId = Convert.ToInt32(dataReader["AttributeId"]);
                            attribute.Description = dataReader["Description"].ToString();
                            attribute.Type = dataReader["Type"].ToString();
                            
                            attributes.Add(attribute);
                        }
                    }
                }
                return attributes;
            }
        }
    }
}
