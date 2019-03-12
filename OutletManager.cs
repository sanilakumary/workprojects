using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCLBBO;
using System.Data;
using System.Data.SqlClient;
namespace PCLBBL
{
    public class OutletManager
    {
        public static OutletUser SelectOutletUser(string UserName)
        {
            //bool StudentFound = false;
            SqlConnection sqlConn = new SqlConnection(AppConstants.ConnString);
            SqlCommand sqlComm = new SqlCommand("Usp_ShowAOutletUser", sqlConn);
            sqlComm.CommandType=CommandType.StoredProcedure;
            sqlComm.Parameters.Add(new SqlParameter("@UserName",UserName));
            sqlComm.Connection.Open();
            SqlDataReader dr= sqlComm.ExecuteReader();
            OutletUser ou = new OutletUser(); ;
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    ou.OutletId=Convert.ToInt32( dr["OutletId"]);
                    ou.UserName=dr["UserName"].ToString();
                    ou.Password=dr["Password"].ToString();
                    ou.FirstName=dr["FirstName"].ToString();
                    ou.MiddleName=dr["MiddleName"].ToString();
                    ou.LastName=dr["LastName"].ToString();
                    ou.Designation=dr["Designation"].ToString();
                }
            }

            return ou;
        }
    }
}
