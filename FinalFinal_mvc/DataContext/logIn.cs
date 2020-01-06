using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalFinal_mvc.DataContext
{
    public class LogIn 
    {
        private static string logInfo = "Server=localhost;Database=CustomerDb;User Id = sa; Password=1q2w3e4r;";

        public static string LogInfo
        {
            get { return logInfo; }
            set { logInfo = value; }
        }
    }
}
