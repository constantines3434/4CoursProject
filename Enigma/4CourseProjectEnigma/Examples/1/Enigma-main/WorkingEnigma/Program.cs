using System;

namespace Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enigma machine emulator:");

            string data = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";//= "The quick brown fox jumps over the lazy dog";
            Enigma e = new Enigma();

            // Plugboard
            e.Plugboard.Add('X', 'D');
            e.Plugboard.Add('A', 'V');

            // Rotors for encryption
            //1
            Rotor rotor1 = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ")
            {
                Notch = 'Y',
                Turnover = 'Q',
            };
            //
            Rotor rotor2 = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE")
            {
                Notch = 'M',
                Turnover = 'E',
            };
            //3
            Rotor rotor3 = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO")
            {
                Notch = 'D',
                Turnover = 'V',
            };
            Rotor ReflectorB = new Rotor("YRUHQSLDPXNGOKMIEBFZCWVJAT");
        
            e.Rotors.Add(rotor1, 'A');
            e.Rotors.Add(rotor2, 'B');
            e.Rotors.Add(rotor3, 'C');

            // Reflector
            e.Rotors.SetReflector(ReflectorB);

            string result = e.Encrypt(data);

            Console.WriteLine("Input: " + data);
            Console.WriteLine("Output: " + result);

            // Reset Rotors for decryption
            e.Rotors.Clear(); // Очищаем роторы от текущего состояния
            e.Rotors.Add(rotor1, 'A');
            e.Rotors.Add(rotor2, 'B');
            e.Rotors.Add(rotor3, 'C');
            e.Rotors.SetReflector(ReflectorB);

            string decrypt = e.Decrypt(result);

            Console.WriteLine("Decrypt: " + decrypt);

            Console.WriteLine();
            Console.Read();
        }


    }
}
