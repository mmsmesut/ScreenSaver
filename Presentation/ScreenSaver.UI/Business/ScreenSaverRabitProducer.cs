using Helper;
using Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQConfigurations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver.UI.Business
{
    public class ScreenManagerRabitProducer
    {
        public static void ScreenshotProduce(ScreenShotModel screenShot)
        {
            var factory = new ConnectionFactory() { HostName = RabbitMQConfigurationScreeenSaver.Host }; //ConnectionFactory Oluşturulur 
            using (IConnection connection = factory.CreateConnection()) //Connection oluşturuldu
            {
                using (IModel channel = connection.CreateModel()) // Kanal yani session oluşturuldu
                {
                    //Kuyruk tanımlanır

                    channel.QueueDeclare(queue: RabbitMQConfigurationScreeenSaver.QueuName,
                                            durable: RabbitMQConfigurationScreeenSaver.Durable,
                                            exclusive: RabbitMQConfigurationScreeenSaver.Exclusive,
                                            autoDelete: RabbitMQConfigurationScreeenSaver.AutoDelete,
                                            arguments: null //Belirlenen excange ile alakalı özellikler
                                            );

                    string screenShotObject = JsonConvert.SerializeObject(screenShot); //Veriyi serilize edecez
                    Console.WriteLine($"screenShot : {screenShot.ToString()}");
                    var body = Encoding.UTF8.GetBytes(screenShotObject);//Serilize edilmiş veriyi Byt'a dönüştürecez


                    channel.BasicPublish(exchange: "", routingKey: "screenShot", basicProperties: null, body);//Puplish Edecez ,rabbit sunusuna gönderiyoruz, Yayınlama kısmı
                    Console.WriteLine($"{screenShot.ScreenShotImageName} adlı resim kuyruğa eklendi");
                    //Log Atılacak 

                }
            }
        }


        public static void SendScreenshotToRabbit() // Ekran görüntüsünü çeker ve rabbit'e gönderir
        {
            List<string> operationMessages = new List<string>();
            try
            {
                Bitmap bitmapImage = ScreenManager.GetScreenshot(); //Ekran Görüntüüsünü alır
                var bitmapImageByteResult = ConvertManager.ImageToByte(bitmapImage); //Bitmap Resmi Byte array dizisine çevirir

                ScreenShotModel sShot = new ScreenShotModel //Class şeklinde paketliyoruz
                {
                    ScreenShotImageName = Guid.NewGuid().ToString(),
                    ScreenShotImageByte = bitmapImageByteResult
                };
                ScreenManagerRabitProducer.ScreenshotProduce(sShot);
                operationMessages.Add("Ekran Kaydını Kuyruğa gönderme işlemi başarılı");
            }
            catch (Exception ex)
            {
                operationMessages.Add("Ekran Kaydını Kuyruğa gönderirken bir hata oluştu");
                operationMessages.Add($"Hata : {ex.Message}");
                //Hata oluştuğuda 
                throw;
            }
        }
    }
}
