using JobConfigurationManagerScreenSaver;
using ScreenSaver.Consumer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ScreenSaver.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JobInitilazeAndStart_SaveScreenshotToFile();
        }

        private static void JobInitilazeAndStart_SaveScreenshotToFile()
        {
            Timer tm = new Timer(JobScreenSaverToGetRabbit.JobIntervalGetRabbit);
            tm.AutoReset = JobScreenSaverToGetRabbit.AutoResetGetRabbit; 
            tm.Elapsed += new ElapsedEventHandler(doWork_SaveScreenshotToRabbit);//İçerisinde İşlemlerin olacağı ana metod
            tm.Start(); //timer aktifleştirilir
            Console.ReadLine();
        }

        private static void doWork_SaveScreenshotToRabbit(object sender, ElapsedEventArgs e)
        {
            ScreenManagerRabitConsumer.ListenQueue();
        }

    }
}
