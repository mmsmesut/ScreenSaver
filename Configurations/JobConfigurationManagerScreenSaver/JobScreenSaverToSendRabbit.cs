using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JobConfigurationManagerScreenSaver
{
    public class JobScreenSaverToSendRabbit
    {
        public static int JobIntervalSendRabbit
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["JobIntervalSendRabbit"]);
            }
        }

        public static bool AutoResetSendRabbit
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["AutoResetSendRabbit"]);
            }
        }

    }
}
