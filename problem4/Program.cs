using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        static bool areBracketsMatched(string str)
        {
            if (str.Length == 0)
            {
                return true;
            }
            //Last In First Out
            Stack<char> stack = new Stack<char>();

            foreach (char c in str)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) return false;
                    char openBracket = stack.Pop();

                    if (c == ')' && openBracket != '(') return false;
                    if (c == ']' && openBracket != '[') return false;
                    if (c == '}' && openBracket != '{') return false;
                }
            }

            // If the stack is empty, all brackets are properly closed
            return stack.Count == 0;
        }
        Console.WriteLine(areBracketsMatched("(){}[]"));
        Console.WriteLine(areBracketsMatched("{[}]"));
    }
}