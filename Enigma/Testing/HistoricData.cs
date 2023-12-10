using EnigmaLogicProcessor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaProject.ViewModel;
using EnigmaProject.Model;

namespace EnigmaProject
{
    public static class HistoricData
    {
        /// <summary>
        /// Keyboard
        /// </summary>
        public static RotorNotMVVM Keyboard
        {
            get => new RotorNotMVVM(Type.Keyboard, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
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
