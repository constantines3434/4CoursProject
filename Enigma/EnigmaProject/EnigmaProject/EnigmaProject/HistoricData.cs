using EnigmaLogicProcessor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaLogicProcessor
{
    public static class HistoricData
    {
        /// <summary>
        /// Keyboard
        /// </summary>
        public static Rotor Keyboard
        {
            get => new Rotor("ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                Notch = '\0',
                Turnover = '\0',
            };
        }

        /// <summary>
        /// Enigma I
        /// </summary>
        public static class EnigmaI
        {

            //public static Rotor I
            //{
            //	get => new Rotor(Type.Rotor, "EKMFLGDQVZNTOWYHXUSPAIBRCJ")
            //	{
            //		Notch = 'Y',
            //		Turnover = 'Q',
            //	};
            //}

            //public static Rotor II
            //{
            //	get => new Rotor(Type.Rotor, "AJDKSIRUXBLHWTMCQGZNPYFVOE")
            //	{
            //		Notch = 'M',
            //		Turnover = 'E',
            //	};
            //}

            //public static Rotor III
            //{
            //	get => new Rotor(Type.Rotor, "BDFHJLCPRTXVZNYEIWGAKMUSQO")
            //	{
            //		Notch = 'D',
            //		Turnover = 'V',
            //	};
            //}

        }
        /// <summary>
        /// Reflectors
        /// </summary>
        public static class Reflectors
        {

            public static Rotor ReflectorA
            {
                get => new Rotor("EJMZALYXVBWFCRQUONTSPIKHGD");
            }
            public static Rotor ReflectorB
            {
                get => new Rotor("YRUHQSLDPXNGOKMIEBFZCWVJAT");
            }

            public static Rotor ReflectorC
            {
                get => new Rotor("FVPJIAOYEDRZXWGCTKUQSBNMHL");
            }
        }
    }
}
