using System;
using System.Collections.Generic;
using System.Net;

namespace AliExpress
{
    public class BoardAdvertisement
    {
        private List<BoardAdvertisement> Advertisements = new List<BoardAdvertisement>();
        private Person _person;
        private string _description;
        private string _count;
        private string _price;

        public BoardAdvertisement(Person person)
        {
            _person = person;
        }

        public BoardAdvertisement(Person person, string description, string count, string price)
        {
            _person = person;
            this._description = description;
            this._count = count;
            this._price = price;
        }

        public void MenuBoard(Person person)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("* Нажмите 1 для просмотра объявлений        *");
            Console.WriteLine("* Нажмите 2, чтобы добавить новое объявление*");
            Console.WriteLine("* Нажмите 3, чтобы удалить свое объявление  *");
            Console.WriteLine("* Нажмите 4 для выхода                      *");
            Console.WriteLine("*********************************************");

            while (true)
            {
                var key = Console.ReadLine();
                if (key == "1")
                {
                    Print(person);
                }

                if (key == "2")
                {
                    AddAdvertisement(person);
                }

                if (key == "3")
                {
                    DeliteAdvertisement(person);
                }

                if (key == "4")
                {
                    break;
                }
            }
        }

        public void AddAdvertisement(Person person)
        {
            Console.WriteLine("Введите название объвления");
            string description = Console.ReadLine();
            Console.WriteLine("Введите количество товара");
            string count = Console.ReadLine();
            Console.WriteLine("Введите цену");
            string price = Console.ReadLine();


            BoardAdvertisement advertisement = new BoardAdvertisement(person, description, count, price);

            Advertisements.Add(advertisement);
            Console.WriteLine("Ваше объявление успешно добавлено!");
            MenuBoard(person);
        }

        public void DeliteAdvertisement(Person person)
        {
            Console.WriteLine("Введите название объвления, которое надо удалить.");
            var title = Console.ReadLine();
            bool isTheRightAd = false;

            for (var i = 0; i < Advertisements.Count; i++)
            {
                if (title == Advertisements[i]._description)
                {
                    isTheRightAd = true;

                    Advertisements.RemoveAt(i);
                    Console.WriteLine($"Ваше объвление успешно удалено!");
                    MenuBoard(person);
                }
            }

            if (isTheRightAd == false)
            {
                Console.WriteLine(
                    $"{_person.Name} Ваше объвление не найдено, повторите запрос!");
                MenuBoard(_person);
            }
        }

        public void Print(Person person)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("* Нажмите 1 для просмотра своих объявлений  *");
            Console.WriteLine("* Нажмите 2 для просмотра всех объявлений   *");
            Console.WriteLine("*********************************************");
            string key = Console.ReadLine();
            if (key == "1")
            {
                if (Advertisements.Count == 0 && _description == null)
                {
                    Console.WriteLine("Список объявлений пуст. Будьте первым, кто добавит свое объвление!");
                    Console.WriteLine("*********************************************");
                    MenuBoard(person);
                }
                for (var i = 0; i < Advertisements.Count; i++)
                {
                    if (Advertisements[i]._person.Name == person.Name)
                    {
                        Console.WriteLine("ПРОДАВЕЦ: " + person.Name);
                        Console.WriteLine("ТОВАР: " + Advertisements[i]._description);
                        Console.WriteLine("КОЛИЧЕСТВО: " + Advertisements[i]._count);
                        Console.WriteLine("ЦЕНА: " + Advertisements[i]._price);
                    }
                }

                MenuBoard(person);
            }

            if (key == "2")
            {
                if (Advertisements.Count == 0 && _description == null)
                {
                    Console.WriteLine("Список объявлений пуст. Будьте первым, кто добавит свое объвление!");
                    Console.WriteLine("*********************************************");
                    MenuBoard(person);
                }
                else
                {
                    for (var i = 0; i < Advertisements.Count; i++)
                    {
                        Console.WriteLine("ПРОДАВЕЦ: " + Advertisements[i]._person.Name);
                        Console.WriteLine("ТОВАР: " + Advertisements[i]._description);
                        Console.WriteLine("КОЛИЧЕСТВО: " + Advertisements[i]._count);
                        Console.WriteLine("ЦЕНА: " + Advertisements[i]._price);
                        Console.WriteLine("*********************************************");
                    }

                    MenuBoard(person);
                }
            }
        }
    }
}