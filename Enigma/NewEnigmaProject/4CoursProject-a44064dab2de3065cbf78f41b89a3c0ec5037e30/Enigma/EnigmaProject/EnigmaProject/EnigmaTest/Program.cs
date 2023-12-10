using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaProject.Components;

namespace EnigmaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enigma machine emulator:");

            string data = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";//= "The quick brown fox jumps over the lazy dog";

            // Rotors for encryption
            //1
            MyRotor rotor1 = new MyRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ")
            {
                //сделать окно
                Notch = 'Y',
                Turnover = 'Q',
            };
            //
            MyRotor rotor2 = new MyRotor("AJDKSIRUXBLHWTMCQGZNPYFVOE")
            {
                Notch = 'M',
                Turnover = 'E',
            };
            //3
            MyRotor rotor3 = new MyRotor("BDFHJLCPRTXVZNYEIWGAKMUSQO")
            {
                Notch = 'D',
                Turnover = 'V',
            };
            //A EJMZALYXVBWFCRQUONTSPIKHGD
            //B YRUHQSLDPXNGOKMIEBFZCWVJAT
            //C FVPJIAOYEDRZXWGCTKUQSBNMHL 
            MyRotor ReflectorB = new MyRotor("YRUHQSLDPXNGOKMIEBFZCWVJAT");

            Enigma e = new Enigma();

            // Plugboard
            //сделать отдельное окно
            e.Plugboard.Add('X', 'D');
            e.Plugboard.Add('A', 'V');

            e.Rotors.Add(rotor1, 'A');
            e.Rotors.Add(rotor2, 'B');
            e.Rotors.Add(rotor3, 'C');

            // Reflector
            e.Rotors.SetReflector(ReflectorB);

            string result = e.Encrypt(data);

            Console.WriteLine("Input: " + data);
            Console.WriteLine("Output: " + result);

            //// Reset Rotors for decryption
            //e.Rotors.Clear(); // Очищаем роторы от текущего состояния
            //e.Rotors.Add(rotor1, 'A');
            //e.Rotors.Add(rotor2, 'B');
            //e.Rotors.Add(rotor3, 'C');
            //e.Rotors.SetReflector(ReflectorB);

            //string decrypt = e.Decrypt(result);

           // Console.WriteLine("Decrypt: " + decrypt);

            Console.WriteLine();
            Console.Read();
        }
    }
}