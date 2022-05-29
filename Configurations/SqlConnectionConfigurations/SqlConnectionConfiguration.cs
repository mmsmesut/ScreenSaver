using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectionConfigurations
{
    public class SqlConnectionConfiguration
    {
        public static string ConnectionStringScreenSaver
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionStringScreenSaver"].ToString();
            }
        }

        public static string ConnectionStringEmailOperation
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionStringEmailOperation"].ToString();
            }
        }

    }


}
