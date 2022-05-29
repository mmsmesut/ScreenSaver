using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helper
{
    public class DirectoryManager
    {
        /// <summary>
        /// Belirtilen dizinin varolup olmadığını kontrol eder
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static bool CheckDirectory(string directory)
        {
            return Directory.Exists(directory);
        }

        public static DirectoryInfo CreateDirectory(string directory)
        {
            return Directory.CreateDirectory(directory);
        }

        public static void CheckDirectoryAndCreate(string directory)
        {
            if (!CheckDirectory(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }


        //bitmapImage.Save($@"ScreenSaverConstant.ScreenShotDirectory\{Guid.NewGuid()}.jpg", ImageFormat.Jpeg);
        public static string GetFileName(string directory)
        {
            string fileName = $@"{directory}\{Guid.NewGuid()}.jpg";
            return fileName;
        }

    }
}
