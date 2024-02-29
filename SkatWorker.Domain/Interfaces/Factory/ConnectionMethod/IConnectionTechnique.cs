﻿namespace SkatWorker.Application.Interfaces.Factory.ConnectionMethod
{
    /// <summary>
    /// Способ подключения.
    /// </summary>
    public interface IConnectionTechnique
    {
        /// <summary>
        /// Подключиться.
        /// </summary>
        /// <param name="url">Адрес подключения.</param>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        bool Connect(string url, string login, string password);

        /// <summary>
        /// Отключиться.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Скачать файл с ресурса.
        /// </summary>
        /// <param name="path">Путь до файла.</param>
        /// <returns>Скачанный файл в виде массива байт.</returns>
        byte[] Download();
    }
}