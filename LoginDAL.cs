using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PCLBBO;
using System.Configuration;

namespace PCLDAL
{
    public class LoginDAL
    {        
        public string LoginUser(OutletUser ou)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                SqlCommand cmdselect = new SqlCommand();
                cmdselect.CommandType = CommandType.StoredProcedure;
                cmdselect.CommandText = "UserLogin";
                cmdselect.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = ou.UserName;
                cmdselect.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = ou.Password;
                cmdselect.Connection = connection;
                connection.Open();

                object userName = cmdselect.ExecuteScalar();

                if (userName is DBNull)
                {
                    return string.Empty;
                }
                else
                {
                    return (string)userName;
                }
            }
        }

        public string GetUserRole(string userName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmdselect = new SqlCommand();
                cmdselect.CommandType = CommandType.StoredProcedure;
                cmdselect.CommandText = "GetUserRole";
                cmdselect.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = userName;

                cmdselect.Connection = connection;

                connection.Open();
                return (string)cmdselect.ExecuteScalar();
            }
        }
        public int InsertOutletUser(OutletUser outletuser)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                SqlCommand cmdselect = new SqlCommand();
                cmdselect.CommandType = CommandType.StoredProcedure;
                cmdselect.CommandText = "CreateOutletUser";
                cmdselect.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = outletuser.UserName;
                cmdselect.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = outletuser.Password;
                cmdselect.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = outletuser.FirstName;
                cmdselect.Parameters.Add("@MiddleName", SqlDbType.VarChar, 50).Value = outletuser.MiddleName;
                cmdselect.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = outletuser.LastName;
                cmdselect.Parameters.Add("@Designation", SqlDbType.VarChar, 50).Value = outletuser.Designation;
                //cmdselect.Parameters.Add("@OutletId", SqlDbType.Int, 4).Value = Convert.ToInt32(outletuser.OutletId);
                cmdselect.Parameters.Add("@RoleId", SqlDbType.Int, 4).Value = Convert.ToInt32(outletuser.RoleId);
                cmdselect.Parameters.Add("@OutletName", SqlDbType.VarChar, 50).Value = outletuser.OutletName;
                cmdselect.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = outletuser.Address1;
                cmdselect.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = outletuser.Address2;
                cmdselect.Parameters.Add("@Telephone1", SqlDbType.VarChar, 50).Value = outletuser.Telephone1;
                cmdselect.Parameters.Add("@Telephone2", SqlDbType.VarChar, 50).Value = outletuser.Telephone2;
                cmdselect.Parameters.Add("@Branch", SqlDbType.VarChar, 50).Value = outletuser.Branch;
                cmdselect.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = outletuser.Email;
                cmdselect.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = outletuser.City;
                cmdselect.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = outletuser.State;
                cmdselect.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = outletuser.Country;
                cmdselect.Parameters.Add("@PostCode", SqlDbType.VarChar, 50).Value = outletuser.PostCode;
                cmdselect.Connection = connection;
                connection.Open();
                int Results;
                Results = cmdselect.ExecuteNonQuery();
                return Results;
            }
        }
        public List<OutletUser> GetOutletUser()
        {
            List<OutletUser> ous = new List<OutletUser>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetOutletUser";
                cmd.Connection = connection;
               
                connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    OutletUser ou = new OutletUser();
                    //ou.OutletId = Convert.ToInt32(dataReader["OutletId"]);
                    ou.FirstName = dataReader["FirstName"].ToString();
                    ou.MiddleName = dataReader["MiddleName"].ToString();
                    ou.LastName = dataReader["LastName"].ToString();
                    ou.Designation = dataReader["Designation"].ToString();
                    ou.OutletId = (int)dataReader["OutletId"];
                    ou.OutletName = dataReader["OutletName"].ToString();
                    ou.Address1 = dataReader["Address1"].ToString();
                    ou.Address2 = dataReader["Address2"].ToString();
                    ou.Telephone1 = dataReader["Telephone1"].ToString();
                    ou.Telephone2 = dataReader["Telephone2"].ToString();
                    ou.Branch = dataReader["Branch"].ToString();
                    ou.Email = dataReader["Email"].ToString();
                    ou.City = dataReader["City"].ToString();
                    ou.State = dataReader["State"].ToString();
                    ou.PostCode = dataReader["PostCode"].ToString();
                    ous.Add(ou);


                }
                return ous;
            }
        }


        public int UpdateOutletUser(OutletUser outletuser)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateOutletUser";

                
                SqlParameter p2 = new SqlParameter("@UserName", outletuser.UserName);
                SqlParameter p3 = new SqlParameter("@Password", outletuser.Password);
                SqlParameter p4 = new SqlParameter("@FirstName", outletuser.FirstName);
                SqlParameter p5 = new SqlParameter("@MiddleName", outletuser.MiddleName);
                SqlParameter p6 = new SqlParameter("@LastName", outletuser.LastName);
                SqlParameter p7 = new SqlParameter("@Designation", outletuser.Designation);
                SqlParameter p8 = new SqlParameter("@OutletId", outletuser.OutletId);
                SqlParameter p9 = new SqlParameter("@RoleId", outletuser.RoleId);
                SqlParameter p10 = new SqlParameter("@OutletName", outletuser.OutletName);
                SqlParameter p11 = new SqlParameter("@Address1", outletuser.Address1);
                SqlParameter p12 = new SqlParameter("@Address2", outletuser.Address2);
                SqlParameter p13 = new SqlParameter("@Telephone1", outletuser.Telephone1);
                SqlParameter p14 = new SqlParameter("@Telephone2", outletuser.Telephone2);
                SqlParameter p15 = new SqlParameter("@Branch", outletuser.Branch);
                SqlParameter p16 = new SqlParameter("@Email", outletuser.Email);
                SqlParameter p17 = new SqlParameter("@City", outletuser.City);
                SqlParameter p18 = new SqlParameter("@State", outletuser.State);
                SqlParameter p19 = new SqlParameter("@Country", outletuser.Country);
                SqlParameter p20 = new SqlParameter("@PostCode", outletuser.PostCode);

                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);
                cmd.Parameters.Add(p10);
                cmd.Parameters.Add(p11);
                cmd.Parameters.Add(p12);
                cmd.Parameters.Add(p13);
                cmd.Parameters.Add(p14);
                cmd.Parameters.Add(p15);
                cmd.Parameters.Add(p16);
                cmd.Parameters.Add(p17);
                cmd.Parameters.Add(p18);
                cmd.Parameters.Add(p19);
                cmd.Parameters.Add(p20);

                //cmd.Parameters.Add(p3);

                cmd.Connection = connection;
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
           
        }
        public OutletUser GetOutletDetails(int outletId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                OutletUser ou = new OutletUser();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetOutletDetails";
                    cmd.Parameters.Add("@OutletId", SqlDbType.Int, 4).Value = outletId;
                    cmd.Connection = connection;
                    connection.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        //OutletUser ou = new OutletUser();
                        while (dataReader.Read())
                        
                        {
                            ou.UserName = dataReader["UserName"].ToString();
                            ou.Password = dataReader["Password"].ToString();

                            ou.FirstName = dataReader["FirstName"].ToString();
                            ou.MiddleName = dataReader["MiddleName"].ToString();
                            ou.LastName = dataReader["LastName"].ToString();
                            ou.Designation = dataReader["Designation"].ToString();
                            ou.OutletId = (int)dataReader["OutletId"];
                            ou.OutletName = dataReader["OutletName"].ToString();
                            ou.Address1 = dataReader["Address1"].ToString();
                            ou.Address2 = dataReader["Address2"].ToString();
                            ou.Telephone1 = dataReader["Telephone1"].ToString();
                            ou.Telephone2 = dataReader["Telephone2"].ToString();
                            ou.Branch = dataReader["Branch"].ToString();
                            ou.Email = dataReader["Email"].ToString();
                            ou.City = dataReader["City"].ToString();
                            ou.State = dataReader["State"].ToString();
                            ou.Country = dataReader["Country"].ToString();
                            ou.PostCode = dataReader["PostCode"].ToString();
                           

                        }
                        return ou;
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

            string outletIds = sb.ToString();
            if (outletIds.Length > 0)
            {
                outletIds = outletIds.Substring(0, outletIds.Length - 1);
            }
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
               
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteoutletUser";
                    
                    SqlParameter p1 = new SqlParameter("@OutletId", outletIds);
                    cmd.Parameters.Add(p1);
                    cmd.Connection = connection;
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }

            }
        }
        public List<OutletUser> GetOutletDetailsByName(string ouname)
        {
            List<OutletUser> outlets = new List<OutletUser>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
               
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetOutletByName";
                cmd.Connection = connection;
                cmd.Parameters.Add("@OutletName", SqlDbType.VarChar, 50).Value = ouname;
                connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                
                OutletUser ou = null;
                while (dataReader.Read())
                {
                    ou = new OutletUser();
                    
                    ou.OutletId = Convert.ToInt32(dataReader["OutletId"]);
                    ou.OutletName = dataReader["OutletName"].ToString();
                    ou.Address1 = dataReader["Address1"].ToString();
                    ou.Address2 = dataReader["Address2"].ToString();
                    ou.Branch = dataReader["Branch"].ToString();
                    ou.City = dataReader["City"].ToString();
                    ou.Country = dataReader["Country"].ToString();
                    ou.PostCode = dataReader["PostCode"].ToString();
                    ou.State = dataReader["State"].ToString();
                    ou.FirstName = dataReader["FirstName"].ToString();
                    ou.MiddleName = dataReader["MiddleName"].ToString();
                    ou.LastName = dataReader["LastName"].ToString();
                    ou.Designation = dataReader["Designation"].ToString();
                    ou.Email = dataReader["Email"].ToString();
                    ou.UserName = dataReader["UserName"].ToString();
                    outlets.Add(ou);
                }
                return outlets;
            }
        }
        public List<OutletUser> GetOutletUserByName(string username)
        {
            List <OutletUser> outletuser= new List<OutletUser>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ToString();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUserByName";
                cmd.Connection = connection;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = username;
                connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
               
                OutletUser ou = new OutletUser();
                while (dataReader.Read())
                {
                    
                    ou.FirstName = dataReader["FirstName"].ToString();
                    ou.MiddleName = dataReader["MiddleName"].ToString();
                    ou.LastName = dataReader["LastName"].ToString();
                    ou.Designation = dataReader["Designation"].ToString();
                    ou.Email = dataReader["Email"].ToString();
                    ou.OutletId = Convert.ToInt32(dataReader["OutletId"]);
                    ou.OutletName = dataReader["OutletName"].ToString();
                    ou.UserName = dataReader["UserName"].ToString();
                    ou.Country = dataReader["Country"].ToString();
                    ou.City = dataReader["City"].ToString();
                    ou.Address1 = dataReader["Address1"].ToString();
                    ou.Address2 = dataReader["Address2"].ToString();
                    ou.Branch = dataReader["Branch"].ToString();
                    ou.Telephone1 = dataReader["Telephone1"].ToString();
                    ou.Telephone2 = dataReader["Telephone2"].ToString();
                    outletuser.Add(ou);
                   
                }
                return outletuser;
            }
        }
    }
}