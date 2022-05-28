using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Transporte.Presentacion
{
    public class Menu
    {
        private int _selectedIndex;
        private string[] Options;
        private string headTitle;
        public Menu(string headTitle, string[] options)
        {
            this.headTitle = headTitle;
            this.Options = options;
            _selectedIndex = 0;
        }
        public int SelectedIndex { get => _selectedIndex; }

        public void DisplayOptions()
        {
            Console.WriteLine(headTitle);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == _selectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                Console.WriteLine($"{prefix} << {currentOption} >>");
            }
            Console.ResetColor();
        }
        public void RunMenu()
        {
            Console.Clear();
            //Se guarda las cordenadas iniciales del puntero
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorVisible = false;
            ConsoleKey keyPressed;
            do
            {
                //Se le vuelve a agregar las cordenadas iniciales para 
                //asi en la proxima renderización de las opciones esta
                //no lo cargue desde las ultimas cordenadas tomadas.
                Console.CursorLeft = x;
                Console.CursorTop = y;
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (_selectedIndex == 0) continue;
                    _selectedIndex--;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (_selectedIndex == Options.Length - 1) continue;
                    _selectedIndex++;
                }
            } while (keyPressed != ConsoleKey.Enter);
            // Clear();
        }
    }
}
