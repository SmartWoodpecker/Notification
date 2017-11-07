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
}
