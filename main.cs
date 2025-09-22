calc.MemorySubtract();
                Console.WriteLine($"Вычтено из памяти: {calc.GetCurrentValue()}");
                break;
            case "MR":
                double memoryValue = calc.MemoryRecall();
                calc.SetCurrentValue(memoryValue);
                Console.WriteLine($"Восстановлено из памяти: {memoryValue}");
                break;
            case "MC":
                calc.ClearMemory();
                Console.WriteLine("Память очищена");
                break;
        
        Console.ReadKey();
    
    static void HandleBinaryOperation(string input, Calculator calc)
    {
        int operatorPos = -1;
        char[] operators = { '+', '-', '*', '/', '%' };
        foreach (char op in operators)
        {
            int pos = input.IndexOf(op);
            if (pos > 0)
            {
                operatorPos = pos;
                break;
            }
        }
        if (operatorPos == -1)
        {
            Console.WriteLine("Ошибка: Не найден оператор (+, -, *, /, %)");
            Console.ReadKey();
            return;
        }
        string num1Str = input.Substring(0, operatorPos).Trim();
        char operation = input[operatorPos];
        string num2Str = input.Substring(operatorPos + 1).Trim();
        if (string.IsNullOrEmpty(num1Str) || string.IsNullOrEmpty(num2Str))
        {
            Console.WriteLine("Ошибка: Неверный формат выражения");
            Console.ReadKey();
            return;
        }
        double num1 = string.IsNullOrEmpty(num1Str) ? calc.GetCurrentValue() : Convert.ToDouble(num1Str);
        double num2 = Convert.ToDouble(num2Str);
        double result = 0;
        switch (operation)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Ошибка: Деление на ноль!");
                    Console.ReadKey();
                    return;
                }
                result = num1 / num2;
                break;
            case '%':
                if (num2 == 0)
                {
                    Console.WriteLine("Ошибка: Деление на ноль!");
                    Console.ReadKey();
                    return;
                }
                result = num1 % num2;
                break;
        }
        calc.SetCurrentValue(result);
        Console.WriteLine($"{num1} {operation} {num2} = {result}");
        Console.ReadKey();
    }
