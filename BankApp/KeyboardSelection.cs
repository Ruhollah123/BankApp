using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp;

internal class KeyboardSelection
{
    public static int SelectionOfTheMenu()
    {
        int selectedIndex = 0;

        string[] options = { 
            "Skapa Konto", 
            "Ta bort konto", 
            "Visa konton", 
            "Hantera konto", 
            "Stäng" };

        ConsoleKey key;

        do
        {
                Console.Clear();
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(0, i);
                if (i == selectedIndex)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(options[i]);
            }

            Console.ResetColor();

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow && selectedIndex > 0)
                selectedIndex--;
            if (key == ConsoleKey.DownArrow && selectedIndex < options.Length - 1)
                selectedIndex++;
                
        } while (key != ConsoleKey.Enter);

        return selectedIndex;
    }
}