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
        /// Enigma I
        /// </summary>
        public static class EnigmaI
        {

            //public static MyRotor I
            //{
            //	get => new MyRotor(Type.MyRotor, "EKMFLGDQVZNTOWYHXUSPAIBRCJ")
            //	{
            //		Notch = 'Y',
            //		Turnover = 'Q',
            //	};
            //}

            //public static MyRotor II
            //{
            //	get => new MyRotor(Type.MyRotor, "AJDKSIRUXBLHWTMCQGZNPYFVOE")
            //	{
            //		Notch = 'M',
            //		Turnover = 'E',
            //	};
            //}

            //public static MyRotor III
            //{
            //	get => new MyRotor(Type.MyRotor, "BDFHJLCPRTXVZNYEIWGAKMUSQO")
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
