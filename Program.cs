﻿namespace Hillel_Calculator_on_Git
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        static private string ToPoland(string input)
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
            }
            while (opers.Count > 0)
            {
                output += opers.Pop() + " ";
            }
            return output;
        }
        static private bool IsDelim(char c)
        {
            if (" =".IndexOf(c) != -1)
            {
                return true;
            }
            return false;
        }
        static private bool IsOper(char c)
        {
            if ("+-/*()".IndexOf(c) != -1)
            {
                return true;
            }
            return false;
        }
        static private int GetPriurity(char c)
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