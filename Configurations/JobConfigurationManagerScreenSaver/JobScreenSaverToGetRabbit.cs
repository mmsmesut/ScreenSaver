using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobConfigurationManagerScreenSaver
{
    //Consumer işleminde kullanılır
    public class JobScreenSaverToGetRabbit
    {
        public static int JobIntervalGetRabbit
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["JobIntervalGetRabbit"]);
            }
        }

        public static bool AutoResetGetRabbit
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["AutoResetGetRabbit"]);
            }
        }

    }
}
