using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<char> openingBeackets = new Stack<char>(expression);
            

            bool flag = false;

            foreach (var item in expression)
            {
                if (item == '(' || item == '[' || item == '{')
                {
                    openingBeackets.Push(item);
                }
                else
                {
                    char currentOpeningBracket = openingBeackets.Peek();

                    if (currentOpeningBracket == '(' && item == ')')
                    {
                        openingBeackets.Pop();
                    }
                    else if (currentOpeningBracket == '[' && item == ']')
                    {
                        openingBeackets.Pop();
                    }
                    else if (currentOpeningBracket == '{' && item == '}')
                    {
                        openingBeackets.Pop();
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
            }
            
            
            if (expression.Length % 2 != 0 || expression.Length == 0)
            {
                flag = true;
            }

            if (flag)
            {
                Console.WriteLine("NO");
            }
            else 
            {
                Console.WriteLine("YES");
            }
        }
    }
}
