using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Helper;
using Constant;
using Model;

namespace ScreenSaver.Consumer.Business
{
    public class ScreenManagerRabitConsumer
    {

        public static void ListenQueue()
        {
            //EmailOperation.EmailManager.Business.EmailManager emailManager = new EmailManager.Business.EmailManager();
            //GlobalResponseModel response = new GlobalResponseModel();

            //Dinleme kısmı 
            List<string> mailLogs = new List<string>();
            //mailLogs.Add(Logger.Add("Rabbit Message kuyruğu Dinleme başladı-----"));

            var factory = new ConnectionFactory() { HostName = RabbitMQConfigurationScreeenSaver.Host }; //ConnectionFactory Oluşturulur 
            //mailLogs.Add(Logger.Add("ConnectionFactory ayarları çalıştırıldı"));
            using (IConnection connection = factory.CreateConnection()) //Connection oluşturuldu
            {
                //mailLogs.Add(Logger.Add("Connection kuruldu"));
                using (IModel channel = connection.CreateModel()) // Kanal yani session oluşturuldu
                {
                    //mailLogs.Add(Logger.Add("Rabbit Host'u ile bağlantı sağlandı"));
                    try
                    {

                        //Kuyruk tanımlanır
                        channel.QueueDeclare(queue: RabbitMQConfigurationScreeenSaver.QueuName,
                                             durable: RabbitMQConfigurationScreeenSaver.Durable,
                                             exclusive: RabbitMQConfigurationScreeenSaver.Exclusive,
                                             autoDelete: RabbitMQConfigurationScreeenSaver.AutoDelete,
                                             arguments: null //Belirlenen excange ile alakalı özellikler
                                             );

                        //mailLogs.Add(Logger.Add($"{RabbitMQConfigurationScreeenSaver.QueuName} adlı kuruk için Rabbit Message kuyruğu hazırlandı"));

                        var consumer = new EventingBasicConsumer(channel);//Kanal'ı dinle Değişiklik olursa ".Received" eventını çalıştır
                        //mailLogs.Add(Logger.Add("Kuruk Consumer ayarlamarı yapıldı"));
                        consumer.Received += (model, ea) =>
                        {
                            //mailLogs.Add(Logger.Add("Kuruk CReceived eventi çalıştırıldı"));
                            var messageBody = ea.Body;

                            //mailLogs.Add(Logger.Add("Kuruk verisi'nin body'si alındı"));
                            var message = Encoding.UTF8.GetString(messageBody.ToArray()); //Byte veri string'e çevriliyor

                            //mailLogs.Add(Logger.Add($"Byte tipinde olan Kuruk verisi'nin string'e dönüştürüldü : {message}"));
                            ScreenShotModel screenShot = JsonConvert.DeserializeObject<ScreenShotModel>(message);  //string veri Model'e sönüştürülüyor
                            //mailLogs.Add(Logger.Add($"String türündeki veri model'e dönüştürüldü veri:{emailResponse}"));
                            //mailLogs.Add(Logger.Add($"Mail gönderim işlemi başlatıldı:{emailResponse}"));

                            var newBitMap = ConvertManager.ByteToImage(screenShot.ScreenShotImageByte);

                            ScreenManager.SaveScreenshotToFile(ScreenSaverConstant.ScreenShotDirectory, newBitMap);

                            //response = emailManager.SendEmail(emailResponse); //Email Gönderim İşlemi 
                            ////mailLogs.AddRange(response.OperationMessages);

                            //if (response.OperationResult)
                            //{
                            //    //Database Durumu 2 olarak güncellememiz gerekiyor
                            //    Service.EmailQueueManager.UpdateEmailQueue(new EmailQueueRequestModel
                            //    {
                            //        Status = (int)QueueStatusEnum.QueueProcessed,
                            //        Id = emailResponse.Id,
                            //    });
                            //}
                        };


                        channel.BasicConsume(queue: RabbitMQConfigurationScreeenSaver.QueuName,
                                             autoAck: true,
                                             consumer: consumer
                                             );

                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine($"{email.Id} idli email kuyruğa eklenirken bir hata oluştu");

                        //mailLogs.Add(Logger.Add($"Email Kuyruğa gönderilirken bir hata oluştu"));
                        //mailLogs.AddRange(response.OperationMessages);
                    }

                }
            }


        }
    }
}
