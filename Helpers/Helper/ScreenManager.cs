using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Helper
{
  public class ScreenManager
    {
        //public string OperationMessage { get; set; }

        public static Bitmap GetScreenshot() // Bitmap türünde olşuturuyoruz  fonksiyonumuzu. 
        {
            Rectangle screenInfo = Screen.PrimaryScreen.Bounds;//Screen.PrimaryScreen.Bounds özelliği seçili ekranın bilgilerini getirir
            int screenWidth = screenInfo.Width;   //Genişlik 
            int screenHeight = screenInfo.Height; //Yükseklik

            //Primary screenn bilgilerine göre , önce ekranımızın boyutunda boş bir Bitmap nesnesi yaratıyoruz:
            Bitmap createdScreenshot = new Bitmap(screenWidth, screenHeight);//GetScreenShot

            //Şimdi Bitmap nesnemizden bir Graphics nesnesi üretelim:
            Graphics GFX = Graphics.FromImage(createdScreenshot);


            //Ekrandaki görüntüyü Graphics nesnemize kopyalayalım:
            GFX.CopyFromScreen(screenInfo.X, screenInfo.Y, 0, 0, screenInfo.Size);
            //GFX.CopyFromScreen(0,0, 0, 0, rectange.Size);
            return createdScreenshot;
        }

        public static List<string> SaveScreenshotToFile(string directory) // Ekran görüntüsünün belirtilen klasöre kaydeder
        {
         
            List<string> operationMessages = new List<string>();
            try
            {
                Bitmap bitmapImage = ScreenManager.GetScreenshot();

                #region CreateDirectory
                    if (!DirectoryManager.CheckDirectory(directory))
                        DirectoryManager.CreateDirectory(directory);
                #endregion

                bitmapImage.Save(DirectoryManager.GetFileName(directory), ImageFormat.Jpeg);
                operationMessages.Add("Ekran Kaydı dizinekaydetme işlemi başarılı");
            }
            catch (Exception ex)
            {
                operationMessages.Add("Ekran Kaydı dizine kaydedilirken hata oluştu");
                operationMessages.Add($"Hata : {ex.Message}");
                //Hata oluştuğuda 
                throw;
            }
            return operationMessages; 

        }

        public static void SaveScreenshotToFile(string directory,Bitmap bitmapImage) // Ekran görüntüsünü belirtilen klasöre kaydeder
        {
            List<string> operationMessages = new List<string>();
            try
            {
                DirectoryManager.CheckDirectoryAndCreate(directory);//Dizin yoksa oluşturur
                bitmapImage.Save(DirectoryManager.GetFileName(directory), ImageFormat.Jpeg);
                operationMessages.Add("Ekran Kaydı dizine kaydetme işlemi başarılı");
            }
            catch (Exception ex)
            {
                operationMessages.Add("Ekran Kaydı dizine kaydedilirken hata oluştu");
                operationMessages.Add($"Hata : {ex.Message}");
                //Hata oluştuğuda 
                throw;
            }
        }

     
    }
}
