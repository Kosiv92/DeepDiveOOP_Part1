using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    public static class Menu
    {
        public static int ChooseMenuItem(string[] menuItems)
        {
            int visibleChoice = 0; //счетчик выбранного пользователем пункта меню

            ConsoleKeyInfo buttonPressed; //нажимаемая пользователем клавиша

            while (true) //цикл использования меню
            {
                Console.Clear();

                for (int i = 0; i < menuItems.Length; i++) //цикл для определения положения выбора пользователя
                {
                    if (i == visibleChoice)
                        Console.Write(
                            "> "); //отображение положения пользователя в меню если счетчик совпадает с номером строки
                    else
                        Console.Write(
                            "  "); //отображение пробела (пустого места) в меню если счетчик не совпадает с номером строки
                    Console.WriteLine(menuItems[i]); //отображение пунктов меню
                }

                buttonPressed = Console.ReadKey();

                if (buttonPressed.Key == ConsoleKey.UpArrow && visibleChoice != 0)
                    visibleChoice--; //уменьшение счетчика если нажата клавиша "вверх" и счетчик не находится в максимально верхнем положении
                if (buttonPressed.Key == ConsoleKey.DownArrow && visibleChoice != menuItems.Length - 1)
                    visibleChoice++; //увеличение счетчика если нажата клавиша "вниз" и счетчик не находится в максимально нижнем положении

                if (buttonPressed.Key == ConsoleKey.Enter) break;
            }

            return visibleChoice;
        }


    }
}
