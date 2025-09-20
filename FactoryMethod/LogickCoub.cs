using FactoryMethod.Factories;
using FactoryMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;

namespace FactoryMethod
{
    public class LogickCoub
    {
        private readonly Instance instance;
        private readonly IZennoPosterProjectModel project;

        public LogickCoub(Instance instance, IZennoPosterProjectModel project)
        {
            this.instance = instance;
            this.project = project;
        }

        public void Run()
        {
            // Работа с Фабрикой
            var parserName = project.Variables["parserName"].Value;

            var factories = new Dictionary<string, Func<IParser>>()
            {
                { "WB", () => new FactoryWB().Create() },
                { "Ozon", () => new FactoryOzon().Create() },
            };

            if (!factories.TryGetValue(parserName, out var factory))
                throw new ArgumentException("Неизвестный Маркетплейс для парсинга: " + parserName);

            var parser = factory();

            // Логика парсинга

            // Открываем главную сайта Маркетплейса
            var tab = instance.ActiveTab;
            project.SendInfoToLog("Начинаем парсить: " + parser.Name);
            Thread.Sleep(500);
            project.SendInfoToLog("Заходим на сайт: " + parser.BaseUrl);
            tab.Navigate(parser.BaseUrl);
            tab.WaitDownloading();

            // Собираем список текстов и цен на странице
            project.SendInfoToLog("Собираем данные!");

            var titels = tab.FindElementsByXPath(parser.TitelXpath).ToArray();
            var prices = tab.FindElementsByXPath(parser.PriceXpath).ToArray();

            project.SendInfoToLog("Собрали данных: " + titels.Length);
            project.SendInfoToLog("Выводим данные:");

            // Выводим в лог
            for (var i = 0; i < titels.Length; i++)
            {
                var titel = titels[i].InnerText;
                var price = prices[i].InnerText;
                project.SendInfoToLog($"{i + 1} | {titel}. Цена: {price}");
            }

            project.SendInfoToLog("Закончили парсинг!");
        }
    }
}
