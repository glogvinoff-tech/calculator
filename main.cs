using System;

class Calculator
{
    private double currentValue;
    private double memoryValue;
    private string lastOperation;
    private bool newInput;

    public Calculator()
    {
        currentValue = 0;
        memoryValue = 0;
        lastOperation = "";
        newInput = true;
    }

    public void ProcessDigit(int digit)
    {
        if (newInput)
        {
            currentValue = digit;
            newInput = false;
        }
        else
        {
            currentValue = currentValue * 10 + digit;
        }
    }

    public void ProcessOperation(string operation)
    {
        switch (operation)
        {
            case "+":
            case "-":
            case "*":
            case "/":
                lastOperation = operation;
                newInput = true;
                break;
                
            case "=":
                CalculateResult();
                lastOperation = "";
                newInput = true;
                break;
                
            case "C":
                currentValue = 0;
                lastOperation = "";
                newInput = true;
                break;
                
            case "CE":
                currentValue = 0;
                newInput = true;
                break;
                
            case "%":
                currentValue /= 100;
                break;
                
            case "1/x":
                if (currentValue != 0)
                    currentValue = 1 / currentValue;
                newInput = true;
                break;
                
            case "x^2":
                currentValue *= currentValue;
                newInput = true;
                break;
                
            case "sqrt":
                if (currentValue >= 0)
                    currentValue = Math.Sqrt(currentValue);
                newInput = true;
                break;
                
            case "M+":
                memoryValue += currentValue;
                newInput = true;
                break;
                
            case "M-":
                memoryValue -= currentValue;
                newInput = true;
                break;
                
            case "MR":
                currentValue = memoryValue;
                newInput = true;
                break;
                
            case "MC":
                memoryValue = 0;
                break;
        }
    }

    private void CalculateResult()
    {
        Console.WriteLine($"Выполнена операция: {lastOperation}");
    }

    public void DisplayCurrentState()
    {
        Console.WriteLine($"Текущее значение: {currentValue}");
        Console.WriteLine($"Значение в памяти: {memoryValue}");
        Console.WriteLine($"Последняя операция: {lastOperation}");
        Console.WriteLine("---");
    }

    public double GetCurrentValue() => currentValue;
    public double GetMemoryValue() => memoryValue;
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        bool running = true;

        Console.WriteLine("Классический калькулятор");
        Console.WriteLine("Доступные операции: +, -, *, /, %, 1/x, x^2, sqrt, M+, M-, MR, MC, C, CE, =");
        Console.WriteLine("Для выхода введите 'exit'");

        while (running)
        {
            Console.Write("Введите команду: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                running = false;
                continue;
            }
            if (int.TryParse(input, out int digit) && digit >= 0 && digit <= 9)
            {
                calc.ProcessDigit(digit);
            }
            else
            {
                // Обрабатываем операцию
                calc.ProcessOperation(input);
            }

            calc.DisplayCurrentState();
        }
    }
}
