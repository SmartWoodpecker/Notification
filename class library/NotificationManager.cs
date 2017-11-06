using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            signalMatchingList.Add("1", new List<string>() {"andrey@mail.ru","cat@mail.ru"});
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
            }
            
        }

        public void AddDestinationForSignal(string mail, string signal)
        {
                signalMatchingList[signal].Add(mail);
        }

        public void EliminateDestinationFromSignal(string mail, string signal)
        {
            signalMatchingList[signal].Remove(mail);
        }

        public void AddSignal(string signal)
        {
            signalMatchingList.Add(signal, null);
        }

        public List<string> GetListOfSupportedSignals()
        {
            List<string> signalList =null;

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
