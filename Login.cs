using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PCLDAL;
using PCLBBO;

namespace PCLBBL
{
    public class Login
    {
        public string LoginUser(OutletUser ou)
        {
            LoginDAL lodal= new LoginDAL();
            return lodal.LoginUser(ou);            
        }

        public string GetUserRole(string userName)
        {
            LoginDAL lodal = new LoginDAL();
            return lodal.GetUserRole(userName);
        }
        public int InsertOutletUser(OutletUser outletuser)
        {
            LoginDAL lodal = new LoginDAL();
            return lodal.InsertOutletUser(outletuser);
        }
        public List<OutletUser> GetOutletUser()
        {
            LoginDAL lodal = new LoginDAL();
            return lodal.GetOutletUser();
        }
        public int UpdateOutletUser(OutletUser outletuser)
        {
            LoginDAL lodal = new LoginDAL();
            return lodal.UpdateOutletUser(outletuser);
        }

        public OutletUser GetOutletDetails(int outletId)
        {
            LoginDAL lodal = new LoginDAL();
            return lodal.GetOutletDetails(outletId);
        }
        public int DeleteMultipleRecords(List<string> idCollection)
        {
            LoginDAL lodal = new LoginDAL();
            return lodal.DeleteMultipleRecords(idCollection);
        }
        public  List<OutletUser> GetOutletDetailsByName(string ouname)
        {
            LoginDAL lodal = new LoginDAL();
            return lodal.GetOutletDetailsByName( ouname);
        }
        public List<OutletUser> GetOutletUserByName(string username)
        {
            LoginDAL lodal = new LoginDAL();
            return lodal.GetOutletUserByName(username);
    }
       
    }
}