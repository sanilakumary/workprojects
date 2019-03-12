using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace PCLBBL
{
    class AppConstants
    {
        public static readonly string ConnString;

        static AppConstants()
        {
            ConnString = ConfigurationManager.ConnectionStrings["PCLBConnection"].ConnectionString;
        }
    }
}
