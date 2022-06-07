using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TP4.Entities;
using App.TP4.Logic;

namespace App.TP4.UI
{
    public class ConsoleApp
    {
        public static void Start()
        {
            short optionCurrent;
            var headerHome = Headers.HeaderHome;
            var options = Options.OptionHome;
            Menu mainMenu = new Menu(headerHome, options);
            do
            {
                mainMenu.RunMenu();
                optionCurrent = mainMenu.SelectedIndex;
                SelectOption(optionCurrent);
            } while (optionCurrent >= 0 && optionCurrent <= options.Length - 2);
        }

        private static void SelectOption(int optionCurrent)
        {
            switch (optionCurrent)
            {
                case 0:
                    OptionOne();
                    break;
                case 1:

                    break;
            }
        }
        private static void OptionOne()
        {
            Menu menuEntities = new Menu(Headers.HeaderOptionOne, Options.OptionsOne);
            menuEntities.RunMenu();
            switch (menuEntities.SelectedIndex)
            {
                case 0:
                    CustomersLogic customersLogic = new CustomersLogic();
                    customersLogic.ShowAll();
                    Console.ReadLine();
                    break;
                case 1:
                    
                    break;
                default:
                    break;
            }
        }
    }
}
