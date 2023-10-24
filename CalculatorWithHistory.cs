using System;
using System.IO;

class Calculator
{
    static void Main(string[] args)
    {
        string historyFilePath = "history.txt";

        while (true)
        {
            Console.WriteLine("Calculator");
            Console.WriteLine("Available operations:");
            Console.WriteLine("1. Addition (+)");
            Console.WriteLine("2. Subtraction (-)");
            Console.WriteLine("3. Multiplication (*)");
            Console.WriteLine("4. Division (/)");
            Console.WriteLine("5. Calculation History");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an operation (1-6): ");
            string choice = Console.ReadLine();

            if (choice == "6")
            {
                Console.WriteLine("Thank you for using the calculator!");
                break;
            }

            double result = 0;
            bool validOperation = true;
            string operation = "";

            switch (choice)
            {
                case "1":
                    operation = "+";
                    result = PerformOperation("+");
                    break;
                case "2":
                    operation = "-";
                    result = PerformOperation("-");
                    break;
                case "3":
                    operation = "*";
                    result = PerformOperation("*");
                    break;
                case "4":
                    operation = "/";
                    result = PerformOperation("/");
                    break;
                case "5":
                    DisplayHistory(historyFilePath);
                    break;
                default:
                    validOperation = false;
                    Console.WriteLine("Invalid operation choice. Please choose again.");
                    break;
            }

            if (validOperation)
            {
                Console.WriteLine($"Result: {result}");
                SaveOperationToHistory(historyFilePath, operation, result);
            }
        }
    }

    static double PerformOperation(string operation)
    {
        Console.Write("Enter the first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 != 0)
                    result = num1 / num2;
                else
                    Console.WriteLine("Cannot divide by zero.");
                break;
        }

        return result;
    }

    static void SaveOperationToHistory(string filePath, string operation, double result)
    {
        string historyEntry = $"{DateTime.Now}: {operation} => {result}";
        File.AppendAllText(filePath, historyEntry + Environment.NewLine);
    }

    static void DisplayHistory(string filePath)
    {
        if (File.Exists(filePath))
        {
            Console.WriteLine("Calculation History:");
            string[] history = File.ReadAllLines(filePath);

            foreach (string entry in history)
            {
                Console.WriteLine(entry);
            }
        }
        else
        {
            Console.WriteLine("No calculation history available.");
        }
    }
}