using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace laba_1_2
{
    class Program
    {
        // Порахувати кількість записів у словнику, значення яких є списком.Записати словник у JSON

        static void Main()
        {
            // Создаем словарь 
            var dictionary = new Dictionary<string, object>
            {
                ["Первый"] = new List<int> { 1, 2, 3 },
                ["Второй"] = "Просто строка",
                ["Третий"] = new List<string> { "один", "два", "три" }
            }
            ;

            int listCount = 0;
            foreach (var value in dictionary.Values)
            {
                if (value is IList)
                {
                    listCount++;
                }
            }


            Console.WriteLine($"Количество записей в словаре, значения которых являются списком: {listCount}");


            string json = System.Text.Json.JsonSerializer.Serialize(dictionary, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });


            Console.WriteLine("Словарь в формате JSON:\n" + json);


            File.WriteAllText("dictionary.json", json);

            Console.ReadKey();
        }
    }
}
