using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico.TP5.UI
{
    public class Options
    {
        private static string[] _optionsHome =
                                       {"Ejercicio 1",
                                        "Ejercicio 2",
                                        "Ejercicio 3",
                                        "Ejercicio 4",
                                        "Ejercicio 5",
                                        "Ejercicio 6",
                                        "Ejercicio 7",
                                        "Salir del programa"};

        public static string[] OptionHome { get => _optionsHome; }
    }
}
