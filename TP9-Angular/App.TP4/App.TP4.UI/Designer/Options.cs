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
                                       {"Ver Proveedores o Clientes",
                                        "Insertar Proveedor",
                                        "Eliminar Proveedor",
                                        "Actualizar Proveedor",
                                        "Salir del programa"};

        private static string[] _optionsOne = { "Ver todos los Proveedores",
                                                "Ver todos los Clientes",
                                                "Volver" };

        public static string[] OptionHome { get => _optionsHome;}
        public static string[] OptionsOne { get => _optionsOne;}
    }
}
