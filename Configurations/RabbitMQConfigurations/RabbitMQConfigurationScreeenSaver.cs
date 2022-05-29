using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConfigurations
{
    public class RabbitMQConfigurationScreeenSaver
    {
            public static string Host
            {
                get
                {
                    return ConfigurationManager.AppSettings["host"].ToString();
                }
            }

            public static string Port
            {
                get
                {
                    return ConfigurationManager.AppSettings["port"].ToString();
                }
            }

            public static string User
            {
                get
                {
                    return ConfigurationManager.AppSettings["user"].ToString();
                }
            }


            //Kuyruk Adları 

            public static string QueuName
            {
                get
                {
                    return ConfigurationManager.AppSettings["queuName"].ToString();
                }
            }

            public static bool Durable
            {
                get
                {
                    return bool.Parse(ConfigurationManager.AppSettings["durable"]);
                }
            }

            public static bool Exclusive
            {
                get
                {
                    return bool.Parse(ConfigurationManager.AppSettings["exclusive"]);
                }
            }

            public static bool AutoDelete
            {
                get
                {
                    return bool.Parse(ConfigurationManager.AppSettings["autoDelete"]);
                }
            }

            public static string RoutingKey
            {
                get
                {
                    return ConfigurationManager.AppSettings["routinkKey"].ToString();
                }
            }


            //public static string QueuNameEmailWillBeDeleted
            //{
            //    get
            //    {
            //        return ConfigurationManager.AppSettings["QueuNameEmailWillBeDeleted"].ToString();
            //    }
            //}

            //public static string RoutingKeyEmailWillBeDeleted
            //{
            //    get
            //    {
            //        return ConfigurationManager.AppSettings["RoutingKeyEmailWillBeDeleted"].ToString();
            //    }
            //}

    }
}
