using EnigmaProject.Model;
using EnigmaLogicProcessor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaProject.ViewModel
{
    public class RotorVM
    {
        public RotorModel RotorDataHandler { get; set; }
        public char Notch
        {
            get => RotorDataHandler.Notch;
            set => RotorDataHandler.Notch = value;
        }

        public char Turnover
        {
            get => RotorDataHandler.Turnover;
            set => RotorDataHandler.Turnover = value;
        }

        public RotorVM(string chars)
        {
            this.RotorDataHandler._chars = chars.ToCharArray();
            //this.Type = type;
        }
        #region Methods
        public static int GetAlphabetCharIndex(char @char) => Array.IndexOf(Common.ALPHABET, char.ToUpper(@char));

        public char GetFromAlphabet(char @char)
        {
            int index = GetAlphabetCharIndex(@char);
            return this.RotorDataHandler._chars[index];
        }
        public char GetFromRotor(char @char)
        {
            int index = Array.IndexOf(this.RotorDataHandler._chars, char.ToUpper(@char));
            return Common.ALPHABET[index];
        }
        public void SetHead(char @char)
        {
            this.RotorDataHandler._head = GetAlphabetCharIndex(@char);
        }
        //+s
        public char Enter(char @char)
        {
            if (this.RotorDataHandler.Current == this.RotorDataHandler.Turnover)// && this.Type == Type.Rotor)
                this.Rotate();
            if (this.RotorDataHandler.IsFirst)
                this.Rotate();

            int from = Array.IndexOf(Common.ALPHABET, char.ToUpper(this.RotorDataHandler.Current));
            int to = this.RotorDataHandler.Next == null ? 0 : Array.IndexOf(Common.ALPHABET, char.ToUpper(this.RotorDataHandler.Next.Current));
            int index = Array.IndexOf(Common.ALPHABET, char.ToUpper(@char));

            int distance = Common.Mod(from, to);
            char get = Common.CharPlusN(index, distance);

            char map = GetFromAlphabet(get);
            return map;
        }
        public char Reverse(char @char)
        {
            int f = Array.IndexOf(Common.ALPHABET, char.ToUpper(this.RotorDataHandler.Current));
            int t = this.RotorDataHandler.Prev == null ? 0 : Array.IndexOf(Common.ALPHABET, char.ToUpper(this.RotorDataHandler.Prev.Current));
            int nn = Array.IndexOf(Common.ALPHABET, char.ToUpper(@char));

            int d = Common.Mod(f, t);
            char get = Common.CharPlusN(nn, d);

            char map = GetFromRotor(get);
            return map;
        }
        public void Rotate()
        {
            if (this.RotorDataHandler._head + 1 >= this.RotorDataHandler._chars.Length)
                this.RotorDataHandler._head = 0;
            else
                this.RotorDataHandler._head++;
        }
        #endregion
    }
}