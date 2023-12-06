namespace Enigma
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

		/// <summary>
		/// Reflectors
		/// </summary>
		public class Reflectors
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
