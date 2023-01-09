namespace Hillel_Calculator_on_Git
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
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