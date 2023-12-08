using EnigmaLogicProcessor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaProject.ViewModel;

namespace EnigmaProject
{
    public static class HistoricData
    {
        /// <summary>
        /// Keyboard
        /// </summary>
        public static RotorVM Keyboard
        {
            get => new RotorVM("ABCDEFGHIJKLMNOPQRSTUVWXYZ")
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

            public static RotorVM ReflectorA
            {
                get => new RotorVM("EJMZALYXVBWFCRQUONTSPIKHGD");
            }
            public static RotorVM ReflectorB
            {
                get => new RotorVM("YRUHQSLDPXNGOKMIEBFZCWVJAT");
            }

            public static RotorVM ReflectorC
            {
                get => new RotorVM("FVPJIAOYEDRZXWGCTKUQSBNMHL");
            }
        }
    }
}
