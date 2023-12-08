using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaLogicProcessor.Common;
using EnigmaProject.ViewModel;

namespace EnigmaProject.Model
{
    public class RotorModel
    {
        #region Fields & Properties
        public Rotor RotorData { get; set; }
        public int IdRotor
        {
            get => RotorData.IdRotor;
            set => RotorData.IdRotor = value;
        }
        public int? IdSetOfRotors
        {
            get => RotorData.IdSetOfRotors;
            set => RotorData.IdSetOfRotors = value;
        }
        public string Dictionary
        {
            get => RotorData.Dictionary;
            set => RotorData.Dictionary = value;
        }
        public RotorModel(Rotor rotorModel)
        {
            RotorData = rotorModel;
        }

        public char[] _chars;

        public int _head;

        public char Notch { get; set; }

        public char Turnover { get; set; }

        public RotorModel Prev { get; set; }

        public RotorModel Next { get; set; }

        public Type Type { get; set; }

        public bool IsFirst { get; set; }
        public RotorVM RotorVMInstance { get; set; }
        public char Current
        {
            get => Common.ALPHABET[this._head];
            set => this.RotorVMInstance.SetHead(value);
        }
        #endregion
    }
}