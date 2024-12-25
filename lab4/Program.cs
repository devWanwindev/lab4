using System.Xml.Serialization;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Задание 1");
        задание_1<object>();

        Console.WriteLine("Задание 2");
        двусвязные_списки<object>();

        Console.WriteLine("Задание 3");
        кооперативы<object>();

        Console.WriteLine("Задание 4");
        string filename = "input.txt";
        задание_4<object>(filename);

        Console.WriteLine("Задание 5");
        задание_5();
    }

    //Задание 1
    public static void задание_1<T>()
    {
        List<T> list = new List<T>();
        Console.WriteLine("Вводите данные, символы '-1' для остановки");

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "-1")
                break;

            T value = (T)Convert.ChangeType(input, typeof(T));
            list.Add(value);
        }

        Console.WriteLine("Ваш список:");
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Подсчет уникальных элементов
        int uniqueCount = CountDistinctElements(list);
        Console.WriteLine($"Количество уникальных элементов: {uniqueCount}");
    }
    public static int CountDistinctElements<T>(List<T> list)
    {
        HashSet<T> uniqueElements = new HashSet<T>(list);
        return uniqueElements.Count;
    }
    //задание 2
    public static void двусвязные_списки<T>()
    {
        LinkedList<T> d = new LinkedList<T>(); //считываем все данные
        string n = "";
        Console.WriteLine("Вводите данные, символы '-1' для остановки");
        int size = 0;
        while (true)
        {
            n = Console.ReadLine();
            if (n == "-1")
                break;
            T i = (T)Convert.ChangeType(n, typeof(T));
            d.AddLast(i);
            size++;
        }
        Console.WriteLine("Введите элемент E");
        string q = Console.ReadLine();
        T E = (T)Convert.ChangeType(q, typeof(T));
        Console.WriteLine("Введите элемент F");
        string w = Console.ReadLine();
        T F = (T)Convert.ChangeType(w, typeof(T));

        LinkedListNode<T> current = d.First; // проходим по списку, ищем необходимое значение, редактируем значение
        while (current != null)
        {
            if (current.Value.Equals(E))
            {
                if (current.Next != null && current.Previous != null && !current.Next.Value.Equals(current.Previous.Value))
                {
                    current.Next.Value = F;
                    current.Previous.Value = F;
                }
            }
            current = current.Next;
        }
        LinkedListNode<T> head = d.First;
        while (head != null)
        {
            Console.Write(head.Value + " ");
            head = head.Next;
        }
    }
    //задание 3
    public static void кооперативы<T>() // 
    {
        HashSet<T> coop1 = new HashSet<T> { (T)Convert.ChangeType("Кукуруза", typeof(T)), (T)Convert.ChangeType("Огурцы", typeof(T)) };
        HashSet<T> coop2 = new HashSet<T> { (T)Convert.ChangeType("Огурцы", typeof(T)), (T)Convert.ChangeType("Кукуруза", typeof(T)) };
        HashSet<T> coop3 = new HashSet<T> { (T)Convert.ChangeType("Редис", typeof(T)), (T)Convert.ChangeType("Кукуруза", typeof(T)) };
        Console.WriteLine("Кооп1 - имеет: " + string.Join(", ", coop1));
        Console.WriteLine("Кооп2 - имеет: " + string.Join(", ", coop2));
        Console.WriteLine("Кооп3 - имеет: " + string.Join(", ", coop3));
        var allcoop = new List<HashSet<T>> { coop1, coop2, coop3 }; // список со всеми кооперативами

        HashSet<T> all = new HashSet<T>(coop1); // посевы которые есть во всех кооперативах
        foreach (HashSet<T> i in allcoop)
        {
            all.IntersectWith(i);
        }
        Console.Write("Возделываемые во всех кооперативах: ");
        foreach (var i in all)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        HashSet<T> some = new HashSet<T>(coop1); // в некоторых кооперативах
        for (int i = 1; i < allcoop.Count; i++)
        {
            HashSet<T> temp = new HashSet<T>(allcoop[i]);
            some.SymmetricExceptWith(temp);
        }
        Console.Write("Возделываемые в некоторых кооперативах: ");
        foreach (var i in some)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        HashSet<T> uniq = new HashSet<T>(); // в одном кооперативе
        HashSet<T> nouniq = new HashSet<T>();
        foreach (var coop in allcoop)
        {
            foreach (var crop in coop)
            {
                if (!uniq.Add(crop))
                {
                    nouniq.Add(crop);
                }
            }
        }
        uniq.ExceptWith(nouniq);
        Console.Write("Возделываемые только в одном кооперативе: ");
        foreach (var i in uniq)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
    // задание 4
    public static void задание_4<T>(string input)
    {
        string text = File.ReadAllText(input); //считываем весь текст из файла
        string[] words = text.Split(' '); // заносим в массив по пробелу
        Dictionary<string, HashSet<T>> wordCharacters = new Dictionary<string, HashSet<T>>(); // словарь слово - уникальный символ(хешсет)
        foreach (var word in words)
        {
            HashSet<T> characters = uniq<T>(word); // по каждому слову определяем уникальные символы
            wordCharacters[word] = characters;
        }
        foreach (var entry in wordCharacters) //вывод
        {
            Console.WriteLine($"Слово: '{entry.Key}' - Символы: {string.Join(", ", entry.Value)}");
        }
    }
    private static HashSet<T> uniq<T>(string word) // вспомогательный метод для определения уникальных символов
    {
        HashSet<T> uniqueChars = new HashSet<T>();
        foreach (var ch in word)
        {
            uniqueChars.Add((T)(object)ch);
        }
        return uniqueChars;
    }

    public static void задание_5()
    {
        Console.WriteLine("Введите количество учеников:"); // ввод данных
        int n = int.Parse(Console.ReadLine());

        List<Students> students = new List<Students>();

        Console.WriteLine("Введите данные учеников в формате <Фамилия> <Имя> <Школа> <Балл>:");

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' '); // ввод данных
            students.Add(new Students
            {
                LastName = input[0],
                FirstName = input[1],
                School = int.Parse(input[2]),
                Score = int.Parse(input[3])
            }); // ввод данных
        }
        XmlSerializer serializer = new XmlSerializer(typeof(List<Students>)); //запись в xml
        using (FileStream fs = new FileStream("students.xml", FileMode.Create))
        {
            serializer.Serialize(fs, students);
        }
        process(); // выполнение задания
    }
    private static void process()
    {
        List<Students> students = new List<Students>();
        using (FileStream fs = new FileStream("students.xml", FileMode.Open))
        { // считывание из xml
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Students>));
            students = (List<Students>)xmlSerializer.Deserialize(fs);
        }
        // счетчик среднего балла в районе
        double totalScore = 0;
        foreach (var student in students)
        {
            totalScore += student.Score;
        }
        double districtAverage = totalScore / students.Count; // определяем средний балл во всем районе(каждого студенка)
        // словарь (школа - средний балл) (средний балл по школам)
        Dictionary<int, List<int>> schoolScores = new Dictionary<int, List<int>>();
        foreach (var student in students)
        {
            //если школы нет в словаре
            if (!schoolScores.ContainsKey(student.School))
            {
                schoolScores[student.School] = new List<int>(); // добавляем баллы студентов школы
            }
            schoolScores[student.School].Add(student.Score); // балл студента в необходимый список школы
        }
        //храним средний балл крутых школ
        List<int> qualifyingSchools = new List<int>();
        double schoolAverage = 0;
        //по каждой школе в словаре
        foreach (var school in schoolScores)
        {
            double averageScore = 0; // средний балл
            foreach (var score in school.Value)
            {
                averageScore += score;
            }
            averageScore /= school.Value.Count; // вычисляем средний балл в школе
            //школа крутая добавляем в крутые школы
            if (averageScore > districtAverage)
            {
                qualifyingSchools.Add(school.Key);
                // если школа самая крутая то сохраняем ее средний балл
                if (qualifyingSchools.Count == 1)
                {
                    schoolAverage = averageScore; // самая крутая школа
                }
            }
        }
        if (qualifyingSchools.Count > 0) // вывод данных
        {
            foreach (var school in qualifyingSchools)
            {
                Console.Write("Школа номер " + school + " ");
            }
            Console.WriteLine();

            if (qualifyingSchools.Count == 1)
            {
                Console.WriteLine($"Средний балл = {schoolAverage:F2}");
            }
        }
    }
}