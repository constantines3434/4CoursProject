using System.Collections.Generic;

namespace Enigma
{
	/// <summary>
	/// задаются ротеры и рефлектор
	/// </summary>
	public class Rotors
	{
		private List<Rotor> _list = new List<Rotor>();
		//+
		private Rotor _keyboard = new Rotor("ABCDEFGHIJKLMNOPQRSTUVWXYZ", '\0', '\0');

        public Rotor Reflector { get; private set; }
		/// <summary>
		/// исправить Рефлектор
		/// </summary>
		//+
		public Rotors()
		{
            this.Reflector = HistoricData.Reflectors.ReflectorB;
            //this.Reflector = Reflector;//ReflectorB new Rotor("YRUHQSLDPXNGOKMIEBFZCWVJAT", '\0', '\0');
        }

		/// <summary>
		/// статичные ротеры
		/// </summary>
		/// <param name="type"></param>
		/// <param name="head"></param>
		/// <exception cref="Exceptions.EnigmaRotorsException"></exception>
		//+
		public void Add(ref Rotor ChoicedRotor, char head)
		{
			Rotor rotor;
			rotor = ChoicedRotor;
			rotor.SetHead(head);
			this.Add(ref rotor);
		}

		public void Add(ref Rotor rotor) 
		{
			rotor.IsFirst = this._list.Count == 0;
			if (rotor.IsFirst)
				this._keyboard.Prev = rotor;
			else
			{
				rotor.Next = this._list[this._list.Count - 1];
				this._list[this._list.Count - 1].Prev = rotor;
			}
			this._list.Add(rotor);
			this.Reflector.Prev = rotor;
		}

		public void Clear()
		{
			this.Reflector.Prev = null;
			this._keyboard.Prev = null;
			this._list.Clear();
		}

		public void SetHead(params char[] heads)
		{
			if (heads.Length != this._list.Count)
				throw new Exceptions.EnigmaRotorsException();

			for (int i = 0; i < heads.Length; i++)
				this._list[i].SetHead(heads[i]);
		}
		//+
		public void SetReflector(ref Rotor reflector)
		{
			this.Reflector = reflector;
			if(this._list.Count > 0)
				this.Reflector.Prev = this._list[this._list.Count - 1];
		}

		//public void SetReflector(Rotor reflector)
		//{
		//	if (reflector.Type != Type.Reflector)
		//		throw new Exceptions.EnigmaRotorsException();

		//	this.Reflector = reflector;
		//}

		public char Enter(char @char, Plugboard pb)
		{
			char result = @char;

			if (pb.Exist(result))
				result = pb.Get(result);

			for (int i = 0; i < this._list.Count; i++)
				result = this._list[i].Enter(result);
			result = this.Reflector.Reverse(result);
			for (int i = this._list.Count - 1; i >= 0; i--)
				result = this._list[i].Reverse(result);
			result = this._keyboard.Reverse(result);

			if (pb.Exist(result))
				result = pb.Get(result);

			return result;
		}
	}
}
