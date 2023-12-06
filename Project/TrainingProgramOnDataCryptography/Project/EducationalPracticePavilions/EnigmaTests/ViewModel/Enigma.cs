using System;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Tests")]

namespace Enigma
{

	/// <summary>
	/// Enigma Machine emulator
	/// </summary>
	public class Enigma
	{

		public Rotors Rotors { get; private set; }

		public Plugboard Plugboard { get; private set; }
        Rotor Reflector = new Rotor("YRUHQSLDPXNGOKMIEBFZCWVJAT");

        public Enigma()
		{
			this.Rotors = new Rotors();//Reflector.;
            this.Plugboard = new Plugboard();
		}

		public string Encrypt(string data)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));

			StringBuilder sb = new StringBuilder();
			foreach (char d in data.ToCharArray())
				if (char.IsLetter(d))
				{
					char r = this.Rotors.Enter(d, this.Plugboard);
					sb.Append(r);
				}
				else
					sb.Append(d);
			return sb.ToString();
		}

	}

}
