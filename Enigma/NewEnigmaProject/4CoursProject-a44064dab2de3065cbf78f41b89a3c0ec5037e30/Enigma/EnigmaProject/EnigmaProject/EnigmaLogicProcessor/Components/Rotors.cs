using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaLogicProcessor.Components
{
    public class Rotors
    {

        private List<Rotor> _list = new List<Rotor>();

        //исправить
        private Rotor _keyboard = HistoricData.Keyboard;

        public Rotor Reflector { get; private set; }

        //исправить
        public Rotors()
        {
            this.Reflector = HistoricData.Reflectors.ReflectorB;
        }

        //+
        public void Add(Rotor Rotor, char head)
        {
            Rotor rotor = Rotor;

            rotor.SetHead(head);
            this.Add(rotor);
        }

        public void Add(Rotor rotor)
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
        public void SetReflector(Rotor reflector)
        {
            Rotor rotor = reflector;
            //switch (type)
            //{
            //	case ReflectorType.UWK_A:
            //		rotor = HistoricData.Reflectors.ReflectorA;
            //		break;
            //	case ReflectorType.UWK_B:
            //		rotor = HistoricData.Reflectors.ReflectorB;
            //		break;
            //	case ReflectorType.UWK_C:
            //		rotor = HistoricData.Reflectors.ReflectorC;
            //		break;
            //	default:
            //		throw new Exceptions.EnigmaRotorsException();
            //}

            this.Reflector = rotor;
            if (this._list.Count > 0)
                this.Reflector.Prev = this._list[this._list.Count - 1];
        }
        //+
        //public void SetReflector(Rotor reflector)
        //{
        //	//if (reflector.Type != Type.Reflector)
        //	//	throw new Exceptions.EnigmaRotorsException();

        //	this.Reflector = reflector;
        //}

        public char Enter(char @char, Plugboard pb)
        {
            char result = @char;

            // Применение Plugboard перед шифрованием
            if (pb.Exist(result))
                result = pb.Get(result);

            // Прохождение через роторы
            for (int i = 0; i < this._list.Count; i++)
                result = this._list[i].Enter(result);

            // Прохождение через отражатель
            result = this.Reflector.Reverse(result);

            // Обратное прохождение через роторы
            for (int i = this._list.Count - 1; i >= 0; i--)
                result = this._list[i].Reverse(result);

            // Обратное прохождение через клавиатуру
            result = this._keyboard.Reverse(result);

            // Применение Plugboard после шифрования
            if (pb.Exist(result))
                result = pb.Get(result);

            return result;
        }
        public char EnterReverse(char @char, Plugboard pb)
        {
            char result = @char;

            // Применение Plugboard перед дешифрованием
            if (pb.Exist(result))
                result = pb.Get(result);

            // Обратное прохождение через клавиатуру
            result = this._keyboard.Reverse(result);

            // Обратное прохождение через роторы
            for (int i = this._list.Count - 1; i >= 0; i--)
                result = this._list[i].Reverse(result);

            // Обратное прохождение через отражатель
            result = this.Reflector.Reverse(result);

            // Применение Plugboard после дешифрования
            if (pb.Exist(result))
                result = pb.Get(result);

            return result;
        }
    }
}
