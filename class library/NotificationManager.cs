using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace class_library
{
    /// <summary>
    /// класс NotificationManager, реализующий интерфейс INotificationManager
    /// </summary>
    public class NotificationManager : INotificationManager
    {
        private Dictionary<string, List<string>> signalMatchingList;

        /// <summary>
        /// Конструктор, инициализируем тестовый список соотвтествия сигнала и почтовых адресов
        /// </summary>
        public NotificationManager()
        {
            signalMatchingList = new Dictionary<string, List<string>>();
            signalMatchingList.Add("1", new List<string>() { "rudenkoulkus@gmail.com"});
            signalMatchingList.Add("2", new List<string>() { "andrey@gmail.com", "cat@gmail.com" });
            signalMatchingList.Add("3", new List<string>() { "dog@gmail.com", "pat@gmail.com" });
            signalMatchingList.Add("4", new List<string>() { "dog1@gmail.com", "pat1@gmail.com" });
            signalMatchingList.Add("5", new List<string>() { "dog2@gmail.com", "pat2@gmail.com" });
            signalMatchingList.Add("6", new List<string>() { "dog3@gmail.com", "pat3@gmail.com" });
            signalMatchingList.Add("7", new List<string>() { "dog4@gmail.com", "pat4@gmail.com" });
            signalMatchingList.Add("8", new List<string>() { "dog5@gmail.com", "pat5@gmail.com" });
        }

        /// <summary>
        /// метод Обработать сигнал 
        /// </summary>
        /// <param name="signal"></param>
        public void EditSignal(string signal)
        {
            List<string> emailList = null;

            if (signalMatchingList.ContainsKey(signal))
            {
                emailList = signalMatchingList[signal];

                SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 587);
                Smtp.Credentials = new NetworkCredential("testsancom@mail.ru", "wolfeandga1");
                MailMessage Message = new MailMessage();
                Message.From = new MailAddress("testsancom@mail.ru");

                foreach (var email in emailList)
                {
                    Message.To.Add(new MailAddress(email)); 
                }

                Message.Subject = "Проверка"; 
                Message.Body = "Код сигнала " + signal;
                Smtp.EnableSsl = true;
                Smtp.Send(Message);
            }

        }

        /// <summary>
        /// метод Добавить адресата для сигнала
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="signal"></param>
        public void AddDestinationForSignal(string mail, string signal)
        {
            if (signalMatchingList.ContainsKey(signal))
            {
                signalMatchingList[signal].Add(mail);
            }
            else
            {
                signalMatchingList.Add(signal, new List<string>() { mail });
            }
        }

        /// <summary>
        /// Исключить адресата из сигнала
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="signal"></param>
        public void EliminateDestinationFromSignal(string mail, string signal)
        {
            if (signalMatchingList.ContainsKey(signal))
                signalMatchingList[signal].Remove(mail);
        }

        /// <summary>
        /// Добавить сигнал
        /// </summary>
        /// <param name="signal"></param>
        public void AddSignal(string signal)
        {
            if (!signalMatchingList.ContainsKey(signal))
                signalMatchingList.Add(signal, new List<string>());
        }

        /// <summary>
        /// Получить список поддерживаемых сигналов
        /// </summary>
        /// <returns></returns>
        public List<string> GetListOfSupportedSignals()
        {
             List<string> signalList = new List<string>();

             foreach (var element in signalMatchingList)
             {
                 if (element.Value != null || element.Value.Count != 0)
                 {
                     signalList.Add(element.Key);
                 }
             }

             return signalList;
             
            #region с использованием LINQ
            //return signalMatchingList.Where(p => p.Value.Count > 0).Select(p => p.Key).ToList();
            #endregion
        }

        /// <summary>
        /// Проверить будет ли адресат получать уведомление для сигнала
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="signal"></param>
        /// <returns></returns>
        public bool IsRecipientReceiveSignal(string mail, string signal)
        {
            if (signalMatchingList.ContainsKey(signal))
            {
                foreach (var element in signalMatchingList)
                {
                    if (element.Key == signal)
                    {
                        element.Value.Contains(mail);
                        return true;
                    }
                }

            }

            return false;

            #region с использованием LINQ
            //return signalMatchingList.ContainsKey(signal) && signalMatchingList[signal].Where(p=>p.Equals(mail)).Count() > 0;
            #endregion
        }

    }
}
