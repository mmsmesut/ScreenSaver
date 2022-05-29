using JobConfigurationManagerScreenSaver;
using ScreenSaver.UI.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ScreenSaver.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JobInitilazeAndStart_SaveScreenshotToFile();

        }

        private static void JobInitilazeAndStart_SaveScreenshotToFile()
        {
            Timer tm = new Timer(JobScreenSaverToSendRabbit.JobIntervalSendRabbit);
            tm.AutoReset = JobScreenSaverToSendRabbit.AutoResetSendRabbit;
            tm.Elapsed += new ElapsedEventHandler(doWork_SaveScreenshotToFile);//İçerisinde İşlemlerin olacağı ana metod
            tm.Elapsed += new ElapsedEventHandler(doWork_SendScreenshotToRabbit);//İçerisinde İşlemlerin olacağı ana metod
            tm.Start(); //timer aktifleştirilir
            Console.ReadLine();
        }

        private static void doWork_SaveScreenshotToFile(object sender, ElapsedEventArgs e)
        {
            //ScreenManager.SaveScreenshotToFile(ScreenSaverConstant.ScreenShotDirectory);

        }

        private static void doWork_SendScreenshotToRabbit(object sender, ElapsedEventArgs e)
        {
            ScreenManagerRabitProducer.SendScreenshotToRabbit();
        }
    }
}
