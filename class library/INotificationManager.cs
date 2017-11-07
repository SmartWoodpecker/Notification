using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace class_library
{
    /// <summary>
    /// интерфейс INotificationManager 
    /// </summary>
    interface INotificationManager
    {
        /// <summary>
        /// метод Обработать сигнал
        /// </summary>
        /// <param name="signal"></param>
        void EditSignal(string signal);

        /// <summary>
        /// метод Добавить адресата для сигнала
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="signal"></param>
        void AddDestinationForSignal(string mail, string signal);

        /// <summary>
        /// Исключить адресата из сигнала
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="signal"></param>
        void EliminateDestinationFromSignal(string mail, string signal);

        /// <summary>
        /// Добавить сигнал
        /// </summary>
        /// <param name="signal"></param>
        void AddSignal(string signal);

        /// <summary>
        ///  Получить список поддерживаемых сигналов
        /// </summary>
        /// <returns></returns>
        List<string> GetListOfSupportedSignals();

        /// <summary>
        /// Проверить будет ли адресат получать уведомление для сигнала
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="signal"></param>
        /// <returns></returns>
        bool IsRecipientReceiveSignal(string mail, string signal);
    }
}
