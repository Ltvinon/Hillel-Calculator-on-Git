using System.Text;

namespace Hillel_Calculator_on_Git
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            while (true)
            {
                Program program = new Program();
                Console.WriteLine($"Введіть приклад : ");

                string str = Console.ReadLine();
                str = str.Replace(".", ",");
                string temp = program.ToPoland(str);
                double result = program.Count(temp);

                Console.WriteLine("Результат : " + result);

            }
        }
         public string ToPoland(string input)
        {
            string output = string.Empty;
            Stack<char> opers = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (IsDelim(input[i]))
                {
                    continue;
                }
                else if (Char.IsDigit(input[i]))
                {
                    while (!IsDelim(input[i]) && !IsOper(input[i]))
                    {
                        output += input[i];
                        i++;

                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                    output += " ";
                    i--;
                }
                else if (IsOper(input[i]))
                {
                    if (input[i] == '(')
                    {
                        opers.Push(input[i]);
                    }
                    else if (input[i] == ')')
                    {
                        char c = opers.Pop();

                        while (c != '(')
                        {
                            output += c.ToString() + ' ';
                            c = opers.Pop();
                        }
                    }
                    else
                    {
                        if (opers.Count > 0)
                        {
                            if (GetPriurity(input[i]) <= GetPriurity(opers.Peek()))
                            {
                                output += opers.Pop().ToString() + " ";
                            }
                        }
                        opers.Push(char.Parse(input[i].ToString()));
                    }
                }
            }
            while (opers.Count > 0)
            {
                output += opers.Pop() + " ";
            }
            return output;
        }
        public double Count(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string first = string.Empty;
                    while (!IsDelim(input[i]) && !IsOper(input[i]))
                    {
                        first += input[i];
                        i++;
                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                    temp.Push(double.Parse(first));
                    i--;
                }
                else if (IsOper(input[i]))
                {
                    double second = temp.Pop();
                    double first = temp.Pop();

                    switch (input[i])
                    {
                        case '+':
                            result = first + second;
                            break;
                        case '-':
                            result = first - second;
                            break;
                        case '*':
                            result = first * second;
                            break;
                        case '/':
                            result = first / second;
                            break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();

        }
         public bool IsDelim(char c)
        {
            if (" =".IndexOf(c) != -1)
            {
                return true;
            }
            return false;
        }
         public bool IsOper(char c)
        {
            if ("+-/*()".IndexOf(c) != -1)
            {
                return true;
            }
            return false;
        }
         public int GetPriurity(char c)
        {
            switch (c)
            {
                case '(':
                    return 0;
                case ')':
                    return 1;
                case '+':
                    return 2;
                case '-':
                    return 3;
                case '*':
                    return 4;
                case '/':
                    return 4;
                default:
                    return 5;
            }
        }

    }
}