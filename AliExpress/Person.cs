using System;
using System.Collections.Generic;

namespace AliExpress
{
    public class Person
    {
        public readonly List<Person> Persons = new List<Person>();
        public string Name;
        private string Password;

        public Person(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public List<Person> SavePerson(Person person)
        {
            Persons.Add(person);
            return Persons;
        }

        public void MenuAuthorization(Person person)
        {
            while (true)
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("*Hажмите 1 для регистраци         *");
                Console.WriteLine("*Hажмите 2 для входа в ваш аккаунт*");
                Console.WriteLine("*Hажмите 3 для выхода             *");
                Console.WriteLine("***********************************");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Повторите пароль!");
                    string userPassword = Console.ReadLine();
                    if (person.Password == userPassword)
                    {
                        person.SavePerson(person);
                        Console.WriteLine("Регистрация прошла успешно!");
                        Console.WriteLine(person.Name + " WELCOME TO AliExpress!");
                        var advertisement = new BoardAdvertisement(person);
                        advertisement.MenuBoard(person);
                    }

                    if (person.Password != userPassword)
                    {
                        Console.WriteLine(person.Name + " ПАРОЛИ НЕ СОВПАДАЮТ! Попробуйте ещё раз!");
                    }
                    break;
                }

                if (input == "3")
                {
                    Console.WriteLine(person.Name + ", До новых встреч!");
                    break;
                }

                if (input == "2")
                {
                    Person tempPerson = SearchPerson(person);
                    Console.WriteLine(tempPerson.Name + ", Добро Пожаловать!");
                    BoardAdvertisement advertisement = new BoardAdvertisement(person);
                    advertisement.MenuBoard(person);
                }

                if (input != "1" && input != "2" && input != "3")
                {
                    Console.WriteLine("Неверная команда! ПОВТОРИТЕ ЗАПРОС!");
                }
            }
        }


        public Person SearchPerson(Person person)
        {
            Person tempPerson = null;
            for (var i = 0; i < Persons.Count; i++)
            {
                if (person.Name == Persons[i].Name && person.Password == Persons[i].Password)
                {
                    tempPerson = new Person(Persons[i].Name, Persons[i].Password);
                }
            }

            return tempPerson;
        }
    }
}