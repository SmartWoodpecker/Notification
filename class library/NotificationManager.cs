using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace class_library
{

    /// <summary>
    /// интерфейс INotificationManager 
    /// </summary>
    public interface INotificationManager
    {
        /// <summary>
        /// метод Обработать сигнал
        /// </summary>
        void EditSignal(string signal);
        /// <summary>
        /// метод Добавить адресата для сигнала
        /// </summary>
        void AddDestinationForSignal(string mail, string signal);
        /// <summary>
        /// Исключить адресата из сигнала
        /// </summary>
        void EliminateDestinationFromSignal(string mail, string signal);

        /// <summary>
        /// Добавить сигнал
        /// </summary>
        void AddSignal(string signal);

        /// <summary>
        /// Получить список поддерживаемых сигналов
        /// </summary>
        /// <returns></returns>
        List<string> GetListOfSupportedSignals();

        /// <summary>
        /// Проверить будет ли адресат получать уведомление для сигнала
        /// </summary>
        /// <returns></returns>
        bool IsRecipientReceiveSignal(string mail, string signal);

    }

    /// <summary>
    /// класс NotificationManager, реализующий интерфейс INotificationManager
    /// </summary>
    public class NotificationManager : INotificationManager
    {
        private Dictionary <string, List<string>> signalMatchingList;
       
        public NotificationManager()
        {
            signalMatchingList = new Dictionary<string, List<string>>();
            signalMatchingList.Add("1", new List<string>() {"rudenkoulkus@gmail.com", "smartrandle@gmail.com"});
            signalMatchingList.Add("2", new List<string>() {"andrey@gmail.com","cat@gmail.com"});
            signalMatchingList.Add("3", new List<string>() {"dog@gmail.com","pat@gmail.com"});
            signalMatchingList.Add("4", new List<string>() { "dog1@gmail.com", "pat1@gmail.com" });
            signalMatchingList.Add("5", new List<string>() { "dog2@gmail.com", "pat2@gmail.com" });
            signalMatchingList.Add("6", new List<string>() { "dog3@gmail.com", "pat3@gmail.com" });
            signalMatchingList.Add("7", new List<string>() { "dog4@gmail.com", "pat4@gmail.com" });
            signalMatchingList.Add("8", new List<string>() { "dog5@gmail.com", "pat5@gmail.com" });

        }
        public void EditSignal(string signal)
        {
            List<string> emailList=null;

            if (signalMatchingList.ContainsKey(signal))
            {
                emailList = signalMatchingList[signal];

                SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 587);
                Smtp.Credentials = new NetworkCredential("rudenko_andrey@mail.ru", "ТУТ ПАРОЛЬ");
                MailMessage Message = new MailMessage();
                Message.From = new MailAddress("rudenko_andrey@mail.ru");

                foreach (var email in emailList)
                {
                    Message.To.Add(new MailAddress(email)); // Куда отправлять
                }

                Message.Subject = "Проверка"; // свой заголовок
                Message.Body = "Код сигнала " + signal;
                Smtp.EnableSsl = true;
                Smtp.Send(Message);
            }

        }

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

        public void EliminateDestinationFromSignal(string mail, string signal)
        {
            if (!signalMatchingList.ContainsKey(signal))
            {
                signalMatchingList[signal].Remove(mail);

            }
        }

        public void AddSignal(string signal)
        {
            if (!signalMatchingList.ContainsKey(signal))
            {
                signalMatchingList.Add(signal, new List<string>());
            }
        }

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
        }

        public bool IsRecipientReceiveSignal(string mail, string signal)
        {
            foreach (var element in signalMatchingList)
            {
                if (element.Key == signal)
                {
                    element.Value.Contains(mail);
                    return true;
                }
            }
            return false;
        }

    }
}
