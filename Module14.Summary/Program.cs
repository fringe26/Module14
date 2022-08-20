﻿using Module14.Summary;

var phoneBook = new List<Contact>();

// добавляем контакты
phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));


phoneBook = phoneBook.OrderBy(n => n.Name)
    .ThenBy(s => s.LastName) as List<Contact>;

while (true)
{
    // Читаем введенный с консоли символ
    var input = Console.ReadKey().KeyChar;

    // проверяем, число ли это
    var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

    // если не соответствует критериям - показываем ошибку
    if (!parsed || pageNumber < 1 || pageNumber > 3)
    {
        Console.WriteLine();
        Console.WriteLine("Страницы не существует");
    }
    // если соответствует - запускаем вывод
    else
    {
        // пропускаем нужное количество элементов и берем 2 для показа на странице
        var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);
        Console.WriteLine();

        // выводим результат
        foreach (var entry in pageContent)
            Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

        Console.WriteLine();
    }
}