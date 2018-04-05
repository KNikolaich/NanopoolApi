using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestAsygnConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FaviconForm ff = new FaviconForm();
            ff.ShowDialog();

            //Console.WriteLine("Начало метода");
            //DumpWebPageAsync();
            //Console.WriteLine("Конец метода");
            //Console.ReadLine();
        }

        private static void DumpWebPageAsync()
        {
            WebClient webclient = new WebClient();
            string page = webclient.DownloadStringTaskAsync("https://yandex.ru/");
            Console.WriteLine(page);
        }
    }
}                         
