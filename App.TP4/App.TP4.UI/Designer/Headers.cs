using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TP4.UI
{
    public static class Headers
    {
        private static string _headerHome = @"             
         __      __   _                     _          _  _         _          _         _ 
         \ \    / /__| |__ ___ _ __  ___   | |_ ___   | \| |___ _ _| |___ __ _(_)_ _  __| |
          \ \/\/ / -_) / _/ _ \ '  \/ -_)  |  _/ _ \  | .` / _ \ '_|  _\ V  V / | ' \/ _` |
           \_/\_/\___|_\__\___/_|_|_\___|   \__\___/  |_|\_\___/_|  \__|\_/\_/|_|_||_\__,_|
                                                                                                                                                      
----(Use las flechas hacia abajo y arriba para navegar y presione enter para seleccionar)-----";

        private static string _headerOptionOne= @"
                      _  _         _          _         _ 
                     | \| |___ _ _| |___ __ _(_)_ _  __| |
                     | .` / _ \ '_|  _\ V  V / | ' \/ _` |
                     |_|\_\___/_|  \__|\_/\_/|_|_||_\__,_|
                                            
                     ------------------------------------
                      SELECCIONE UNA ENTIDAD A CONSULTAR
                     -----------------------------------";
        private static string _headerOptions = @"
                      _  _         _          _         _ 
                     | \| |___ _ _| |___ __ _(_)_ _  __| |
                     | .` / _ \ '_|  _\ V  V / | ' \/ _` |
                     |_|\_\___/_|  \__|\_/\_/|_|_||_\__,_| 
                                                        ";

        public static string HeaderHome { get => _headerHome; }
        public static string HeaderOptionOne { get => _headerOptionOne;}
        public static string HeaderOptions { get => _headerOptions; }
    }
}
