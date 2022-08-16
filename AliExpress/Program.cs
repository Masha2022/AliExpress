using System;
using System.Net;

namespace AliExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*Welcome to the site of the online store AliExpress!*");
            Console.WriteLine("Добро Пожаловать в магазин АлиЕкспресс!             *");
            Console.WriteLine("*****************************************************");

            Console.WriteLine("Введите ваше имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите ваш пароль");
            string password = Console.ReadLine();
            Person person = new Person(name, password);
            person.MenuAuthorization(person);
        }
    }
}