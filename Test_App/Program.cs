using System;
using class_library;

namespace Test_App
{
    class Program
    {
        static void Main(string[] args)
        {
            NotificationManager notification = new NotificationManager();

            // Добавляем почтовый адрес 
            notification.AddDestinationForSignal("levin@suncomteam.ru", "5");
            //Отправялем сообщение по коду
            notification.EditSignal("5");
            // Удаляем почтовый адрес
            notification.EliminateDestinationFromSignal("levin@suncomteam.ru", "5");
            //Пытаемся отправить сообщение по коду
            notification.EditSignal("5");
            //Добавление новго сигнала
            notification.AddSignal("10");
         
            Console.ReadKey();
        }
    }
}
