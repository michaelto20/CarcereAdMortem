using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class GameTools
{
    /// <summary>
    /// Prompts the user to type one of a set of possible valid text values.
    /// User is prompted repeatedly until she enters one of the valid choices.
    /// Choices are not case sensitive.
    /// </summary>
    /// <param name="validChoices">a comma separated list of valid choices</param>
    /// <returns></returns>
    public static string GetChoice(params string[] validChoices)
    {
        string choice = "";
        bool isValid = false;
        while (isValid == false)
        {
            string choiceString = String.Join(" | ", validChoices);
            Console.Write("Enter Choice ({0}): ", choiceString);
            choice = Console.ReadLine();
            choice = choice.ToLower();
            foreach (string validChoice in validChoices)
            {
                if (choice == validChoice.ToLower())
                {
                    isValid = true;
                    break;
                }
            }
            if (isValid == false)
            {
                WriteColoredParagraph("Invalid Choice. Try Again.", ConsoleColor.White, ConsoleColor.DarkRed);
            }
        }
        return choice;
    }

    public static int GetChoiceNumber(params int[] validChoices)
    {
        int choice = 0;
        bool isValid = false;
        while (isValid == false)
        {
            string userChoices = "";
            userChoices = string.Join(" | ", validChoices);
            Console.Write("Enter Choice ({0}): ", userChoices);
            string choiceString = Console.ReadLine();
            //Breaks right here with string inputs, why doesn't the above method
            //break with integer inputs?
            if (int.TryParse(choiceString, out choice))
            {
               foreach (int validChoice in validChoices)
                {
                    if (choice == validChoice)
                    {
                        isValid = true;
                        choice = Convert.ToInt32(choiceString);
                        break;
                    }
                }
                if (isValid == false)
                {
                    WriteColoredParagraph("Invalid Choice! Try Again.", ConsoleColor.White, ConsoleColor.DarkRed);
                }
            }
            else
            {
                Console.WriteLine("Invalid Choice! Try Again.");
                Console.WriteLine();
            }
        }
        return choice;
    }
    /// <summary>
    /// Write text to the screen, inserting new lines at appropriate places
    /// in order to properly wrap the text only at spaces.
    /// </summary>
    /// <param name="text">the text to write to the screen</param>
    public static void WriteParagraph(string text)
    {
        WriteParagraph(text, new { });
    }

    /// <summary>
    /// Write text to the screen, inserting new lines at appropriate places
    /// in order to properly wrap the text only at spaces.
    /// </summary>
    /// <param name="text">the text to write to the screen</param>
    /// <param name="args">any replaceable parameters included in text using {#} syntax</param>
    public static void WriteParagraph(string text, params object[] args)
    {
        text = String.Format(text, args);
        Console.WriteLine(String.Join(Environment.NewLine, GetWrappedText(text)));
    }

    /// <summary>
    /// Write text to the screen, inserting new lines at appropriate places
    /// in order to properly wrap the text only at spaces. The specified foreground
    /// and background colors will be used.
    /// </summary>
    /// <param name="text">the text to write to the screen</param>
    /// <param name="foreground">the foreground color to use when writing the text</param>
    /// <param name="background">the background color to use when writing the text</param>
    public static void WriteColoredParagraph(string text, ConsoleColor foreground, ConsoleColor background)
    {
        WriteColoredParagraph(text, foreground, background, new { });
    }

    /// <summary>
    /// Write text to the screen, inserting new lines at appropriate places
    /// in order to properly wrap the text only at spaces. The specified foreground
    /// and background colors will be used.
    /// </summary>
    /// <param name="text">the text to write to the screen</param>
    /// <param name="foreground">the foreground color to use when writing the text</param>
    /// <param name="background">the background color to use when writing the text</param>
    /// <param name="args">any replaceable parameters included in text using {#} syntax</param>
    public static void WriteColoredParagraph(string text, ConsoleColor foreground, ConsoleColor background, params object[] args)
    {
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
        text = String.Format(text, args);
        List<string> lines = GetWrappedText(text);
        foreach (string line in lines)
        {
            Console.Write(line.PadRight(Console.WindowWidth));
        }
        Console.ResetColor();
    }

    /// <summary>
    /// Returns a list of string lines that have been sized such that each line
    /// doesn't exceed the length of hte console window.
    /// </summary>
    /// <param name="text">the text to wrap</param>
    /// <returns></returns>
    private static List<string> GetWrappedText(string text)
    {
        List<string> lines = new List<string>();
        StringBuilder sb = new StringBuilder();

        if (text != null)
        {
            text = Regex.Replace(text, @"\s+", " ").Trim();
            string[] words = text.Split(' ');

            for (int wordNum = 0; wordNum < words.Length; wordNum++)
            {
                String word = words[wordNum];
                if (sb.Length != 0 && (sb.Length + word.Length + 2) > Console.WindowWidth)
                {
                    lines.Add(sb.ToString());
                    sb.Clear();
                }
                sb.Append(word).Append(' ');
            }
        }

        lines.Add(sb.ToString());
        return lines;
    }
}
