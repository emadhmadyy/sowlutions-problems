using System;

class Program
{
    public static bool ValidateEmail(string email)
    {
        if (email.Length == 0 || email.Length > 256) return false;

        int start = 0, end = email.Length - 1;
        while (start <= end && email[start] == ' ') start++;
        while (end >= start && email[end] == ' ') end--;
        if (start > end) return false;

        int atIndex = -1;
        bool dotAfterAt = false;
        int dotIndex = -1;

        for (int i = start; i <= end; i++)
        {
            char c = email[i];

            if (c == '@')
            {
                if (i == start || i == end || atIndex != -1) return false;
                if (email[i - 1] == '.' || email[i + 1] == '.') return false;
                atIndex = i;
            }
            else if (c == '.')
            {
                if (atIndex != -1)
                {
                    dotAfterAt = true;
                    dotIndex = i;
                }
            }
            else if (char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        if (!dotAfterAt || end - dotIndex <= 1) return false;

        return true;
    }

    static void Main(string[] args)
    {
        // Test cases
        Console.WriteLine(ValidateEmail("john.doe@gmail.com"));    // True
        Console.WriteLine(ValidateEmail("john@doe@gmail.com"));    // False
        Console.WriteLine(ValidateEmail("john@gmail.c"));          // False
        Console.WriteLine(ValidateEmail("john@gmail.co"));         // True
        Console.WriteLine(ValidateEmail(" john.doe@gmail.com"));  // True (with spaces around)
        Console.WriteLine(ValidateEmail(" "));                     // False (empty string with space)
        Console.WriteLine(ValidateEmail("john@.com"));             // False
    }
}
