using EnigmaProject.Common;
using EnigmaProject.Components;
namespace EnigmaProject
{

	public static class HistoricData
	{

		/// <summary>
		/// Keyboard
		/// </summary>
		public static Rotor Keyboard
		{
			get => new Rotor(EnigmaType.Keyboard, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
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

			public static Rotor I
			{
				get => new Rotor(EnigmaType.Rotor, "EKMFLGDQVZNTOWYHXUSPAIBRCJ")
				{
					Notch = 'Y',
					Turnover = 'Q',
				};
			}

			public static Rotor II
			{
				get => new Rotor(EnigmaType.Rotor, "AJDKSIRUXBLHWTMCQGZNPYFVOE")
				{
					Notch = 'M',
					Turnover = 'E',
				};
			}

			public static Rotor III
			{
				get => new Rotor(EnigmaType.Rotor, "BDFHJLCPRTXVZNYEIWGAKMUSQO")
				{
					Notch = 'D',
					Turnover = 'V',
				};
			}

		}

		/// <summary>
		/// Reflectors
		/// </summary>
		public static class Reflectors
		{

			public static Rotor ReflectorA
			{
				get => new Rotor(EnigmaType.Reflector, "EJMZALYXVBWFCRQUONTSPIKHGD");
			}


			public static Rotor ReflectorB
			{
				get => new Rotor(EnigmaType.Reflector, "YRUHQSLDPXNGOKMIEBFZCWVJAT");
			}

			public static Rotor ReflectorC
			{
				get => new Rotor(EnigmaType.Reflector, "FVPJIAOYEDRZXWGCTKUQSBNMHL");
			}

		}

	}

}
