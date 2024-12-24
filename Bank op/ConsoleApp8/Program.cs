using System;
using System.Collections.Generic;
using System.Linq;

class Abonent
{
    public string Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Address { get; set; }
    public string CardNumber { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public int CityCallDuration { get; set; }
    public int LongDistanceCallDuration { get; set; }

    public Abonent(string id, string lastName, string firstName, string middleName, string address,
                   string creditCardNumber, decimal debit, decimal credit, int cityCallDuration, int longDistanceCallDuration)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Address = address;
        CardNumber = creditCardNumber;
        Debit = debit;
        Credit = credit;
        CityCallDuration = cityCallDuration;
        LongDistanceCallDuration = longDistanceCallDuration;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, ФИО: {LastName} {FirstName} {MiddleName}, Адрес: {Address}, " +
                          $"Кредитная карта: {CardNumber}, Дебет: {Debit}, Кредит: {Credit}, " +
                          $"Время городских переговоров: {CityCallDuration}, " +
                          $"Время междугородних переговоров: {LongDistanceCallDuration}");
    }
}

class Program
{
    static void Main()
    {
        List<Abonent> abonents = new List<Abonent>
        {
            new Abonent("001", "Иванов", "Иван", "Иванович", "Москва, ул. Ленина, д. 1", "1111 2222 3333 4444", 1000, 5000, 20, 5),
            new Abonent("002", "Петров", "Петр", "Петрович", "Москва, ул. Пушкина, д. 2", "2222 3333 4444 5555", 1500, 3000, 10, 15),
            new Abonent("003", "Сидоров", "Сидор", "Сидорович", "Москва, ул. Горького, д. 3", "3333 4444 5555 6666", 2000, 4000, 25, 3),
            new Abonent("004", "Константинов", "Константин", "Константинович", "Москва, ул. Горького, д. 1", "4321 6544 8374 9263", 5000, 10000, 15, 0),
            new Abonent("005", "Владимиров", "Владимир", "Владимирович", "Москва, ул. Горького, д. 3", "6666 7777 8888 9999", 6000, 9000, 30, 13)

        };

        while (true)
        {
            Console.WriteLine("\nВыберите функцию:");
            Console.WriteLine("1: Показать абонентов с временем городских переговоров больше заданного");
            Console.WriteLine("2: Показать абонентов, использовавших междугороднюю связь");
            Console.WriteLine("3: Показать список абонентов в алфавитном порядке");
            Console.WriteLine("0: Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите время городских переговоров (в минутах): ");
                    int timeThreshold = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Абоненты, время городских переговоров превышает {timeThreshold} минут:");
                    foreach (var abonent in abonents.Where(a => a.CityCallDuration > timeThreshold))
                    {
                        abonent.DisplayInfo();
                    }
                    break;

                case 2:
                    Console.WriteLine("Абоненты, которые пользовались междугородней связью:");
                    foreach (var abonent in abonents.Where(a => a.LongDistanceCallDuration > 0))
                    {
                        abonent.DisplayInfo();
                    }
                    break;

                case 3:
                    Console.WriteLine("Список абонентов в алфавитном порядке:");
                    foreach (var abonent in abonents.OrderBy(a => a.LastName))
                    {
                        abonent.DisplayInfo();
                    }
                    break;

                case 0:
                    Console.WriteLine("Выход из программы.");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите вариант от 0 до 3.");
                    break;
            }
        }
    }
}
