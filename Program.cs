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
    }
}