using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TP4.UI
{
    public class Options
    {
        private static string[] _optionsHome =
                                       {"Consultar datos",
                                        "Insertar Empleado",
                                        "Eliminar Empleado",
                                        "Actualizar Empleado",
                                        "Salir del programa"};

        private static string[] _optionsOne = { "Clientes", "Empleados", "Volver" };

        public static string[] OptionHome { get => _optionsHome;}
        public static string[] OptionsOne { get => _optionsOne;}
    }
}
