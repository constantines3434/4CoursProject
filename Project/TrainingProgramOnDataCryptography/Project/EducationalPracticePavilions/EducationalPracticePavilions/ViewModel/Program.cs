using System;
using WorkingEnigma;
namespace EnigmaApi
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("EnigmaApi machine emulator:");
			
			string data = "The quick brown fox jumps over the lazy dog";
			Enigma e = new Enigma();

			//Plugboard
			e.Plugboard.Add('X', 'D');
			e.Plugboard.Add('A', 'V');

			//Rotors
			Rotor rotor1 = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'Y', 'Q');
            Rotor rotor2 = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'M', 'E');
            Rotor rotor3 = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'D', 'V');

            e.Rotors.Add(ref rotor1, 'A');
			e.Rotors.Add(ref rotor2, 'B');
			e.Rotors.Add(ref rotor3, 'C');

            //Reflector
            Rotor reflector = new Rotor("EJMZALYXVBWFCRQUONTSPIKHGD", '\0', '\0');

            e.Rotors.SetReflector(ref reflector);

			string result = e.Encrypt(data);

			Console.WriteLine("Input: " + data);
			Console.WriteLine("Output: " + result);

			Console.WriteLine();
			Console.Read();
		}
	}
}
