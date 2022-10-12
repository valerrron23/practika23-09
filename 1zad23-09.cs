using System;
namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op) //объявление двух переменных
        {
            double result = double.NaN; // Значение по умолчанию — «не число», используем, если операция(деление) может привести к ошибке.
            //оператор множественного выбора свитч (переключатель) для выполнения математических операций.
            switch (op)
            {
                case "a"://условный оператор, если значение вводимых данных равно "а"
                    result = num1 + num2; //выполнение операции сложения и конкатенации строк
                    break; //завершение выполнение блока команд
                case "s"://условный оператор, если значение вводимых данных равно "s"
                    result = num1 - num2; //выполнение операции вычитания и конкатенации строк
                    break; //завершение выполнение блока команд
                case "m"://условный оператор, если значение вводимых данных равно "m"
                    result = num1 * num2; //выполнение операции умножения и конкатенации строк
                    break; //завершение выполнение блока команд
                case "d"://условный оператор, если значение вводимых данных равно "d"
                    //просим пользователя ввести ненулевой делитель
                    if (num2 != 0) //условие num2 не равен 0
                    {
                        result = num1 / num2; //выполнение операции деления и конкатенации строк
                    }
                    break; //завершение выполнение блока команд
                // возврат текста при неверном вводе параметра
                default:
                    break; //завершение выполнение блока команд
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // отображать заголовок: приложение калькулятора консоль C#
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");
            while (!endApp) //условие пока процесс приложения не завершен
            {
                // объявление переменных и задание их пустыми
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;
                //информируем пользователя о требуемом действии - ввод первого числа
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1)) //если num1 задано в неверном формате, то информируем об этом пользователя
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }
                //информируем пользователя о требуемом действии
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2)) //если num2 задано в неверном формате, то информируем об этом пользователя
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }
                // информируем пользователя о действии - выборе опретора, несколько вариантов действий
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");
                string op = Console.ReadLine(); //задание текстового объекта
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result)) //если были введены некорректные данные, то информируем об этом пользователя
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result); //вывод результата
                }
                catch (Exception e) //корректирование при ошибке
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
                Console.WriteLine("------------------------\n");
                // перед закрытием ждем решения пользователя
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true; //при вводе n приложение закрывается 
                Console.WriteLine("\n"); 
            }
            return; //возвращение к началу, новая операция
        }
    }
}