using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaProject.Common;

namespace EnigmaProject.Components
{
    public class MyRotor
    {

        #region Instruments

        private readonly char[] _chars;

        private int _head;

        public char Notch { get; set; }

        public char Turnover { get; set; }

        public MyRotor Prev { get; set; }

        public MyRotor Next { get; set; }

        public Type Type { get; set; }

        public bool IsFirst { get; set; }

        public char Current
        {
            get => Common.Common.ALPHABET[this._head];
            set => this.SetHead(value);
        }

        #endregion
        //+
        public MyRotor(string chars)
        {
            this._chars = chars.ToCharArray();
            //this.Type = type;
        }
        /// <summary>
        /// Получает индекс символа в алфавите
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static int GetAlphabetCharIndex(char @char) => Array.IndexOf(Common.Common.ALPHABET, char.ToUpper(@char));

        /// <summary>
        /// Получает символ из алфавита
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public char GetFromAlphabet(char @char)
        {
            int index = GetAlphabetCharIndex(@char);
            return this._chars[index];
        }

        /// <summary>
        /// Получает символ из ротора по заданному символу
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public char GetFromRotor(char @char)
        {
            int index = Array.IndexOf(this._chars, char.ToUpper(@char));
            return Common.Common.ALPHABET[index];
        }

        /// <summary>
        /// Устанавливает начальную позицию ротора
        /// </summary>
        /// <param name="char"></param>
        public void SetHead(char @char) => this._head = GetAlphabetCharIndex(@char);

        /// <summary>
        /// Производит шифрование символа по заданному правилу ротора
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public char Enter(char @char)
        {
            if (this.Current == this.Turnover)
                this.Prev.Rotate();
            if (this.IsFirst)
                this.Rotate();

            int from = Array.IndexOf(Common.Common.ALPHABET, char.ToUpper(this.Current));
            int to = this.Next == null ? 0 : Array.IndexOf(Common.Common.ALPHABET, char.ToUpper(this.Next.Current));
            int index = Array.IndexOf(Common.Common.ALPHABET, char.ToUpper(@char));

            int distance = Common.Common.Mod(from, to);
            char get = Common.Common.CharPlusN(index, distance);

            char map = GetFromAlphabet(get);
            return map;
        }

        /// <summary>
        /// Производит обратное шифрование символа
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public char Reverse(char @char)
        {
            int f = Array.IndexOf(Common.Common.ALPHABET, char.ToUpper(this.Current));
            int t = this.Prev == null ? 0 : Array.IndexOf(Common.Common.ALPHABET, char.ToUpper(this.Prev.Current));
            int nn = Array.IndexOf(Common.Common.ALPHABET, char.ToUpper(@char));

            int d = Common.Common.Mod(f, t);
            char get = Common.Common.CharPlusN(nn, d);

            char map = GetFromRotor(get);
            return map;
        }

        /// <summary>
        /// Поворачивает ротор на один символ
        /// </summary>
        public void Rotate()
        {
            if (this._head + 1 >= this._chars.Length)
                this._head = 0;
            else
                this._head++;
        }
    }
}
