using System;

class Program
{
    static void Main()
    {
        // Запрос у пользователя количества элементов в массиве
        Console.Write("Введите количество элементов в массиве: ");
        int numElements = int.Parse(Console.ReadLine());

        // Создание массива и заполнение его случайными натуральными числами
        int[] array = new int[numElements];
        Random rand = new Random();
        for (int i = 0; i < numElements; i++)
        {
            array[i] = rand.Next(1, 101); // Генерация случайного числа от 1 до 100
        }

        // Вывод исходного массива на экран
        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        // Обработка массива: удвоение четных элементов на нечетных позициях и поиск максимального значения на четных позициях
        int[] resultArray = ProcessArray(array, out int maxOddOnEvenPosition, out bool hasEvenOnOdd);

        // Вывод измененного массива на экран
        Console.WriteLine("Получившийся массив:");
        PrintArray(resultArray);

        // Вывод максимального нечетного значения на четной позиции или сообщения, если такого значения нет
        if (hasEvenOnOdd)
        {
            Console.WriteLine("Максимальное нечетное значение на четной позиции: " + maxOddOnEvenPosition);
        }
        else
        {
            Console.WriteLine("В массиве не оказалось ни одного четного элемента на нечетной позиции.");
        }
    }

    // Метод для обработки массива: удвоение четных элементов на нечетных позициях и поиск максимального значения на четных позициях
    static int[] ProcessArray(int[] arr, out int maxOddOnEvenPosition, out bool hasEvenOnOdd)
    {
        int[] newArray = new int[arr.Length];
        maxOddOnEvenPosition = int.MinValue; // Инициализация переменной для максимального нечетного значения на четной позиции
        hasEvenOnOdd = false; // Переменная для отслеживания наличия четных элементов на нечетных позициях

        for (int i = 0; i < arr.Length; i++)
        {
            newArray[i] = arr[i]; // Заполнение нового массива значениями из исходного массива

            // Условие для удвоения четных элементов на нечетных позициях
            if ((i + 1) % 2 != 0 && arr[i] % 2 == 0)
            {
                newArray[i] *= 2;
                hasEvenOnOdd = true; // Указываем, что есть четный элемент на нечетной позиции
            }
            // Условие для поиска максимального нечетного значения на четных позициях
            else if ((i + 1) % 2 == 0 && arr[i] % 2 != 0 && arr[i] > maxOddOnEvenPosition)
            {
                maxOddOnEvenPosition = arr[i];
            }
        }

        return newArray;
    }

    // Метод для вывода массива на экран
    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
