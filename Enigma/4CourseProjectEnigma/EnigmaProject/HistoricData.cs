using EnigmaProject.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaProject
{
    public static class HistoricData
    {

        /// <summary>
        /// Keyboard
        /// </summary>
        public static MyRotor Keyboard
        {
            get => new MyRotor("ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                Notch = '\0',
                Turnover = '\0',
            };
        }

        /// <summary>
        /// Reflectors
        /// </summary>
        public static class Reflectors
        {

            public static MyRotor ReflectorA
            {
                get => new MyRotor("EJMZALYXVBWFCRQUONTSPIKHGD");
            }
            public static MyRotor ReflectorB
            {
                get => new MyRotor("YRUHQSLDPXNGOKMIEBFZCWVJAT");
            }

            public static MyRotor ReflectorC
            {
                get => new MyRotor("FVPJIAOYEDRZXWGCTKUQSBNMHL");
            }
        }
    }
}
