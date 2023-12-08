using EnigmaLogicProcessor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaProject.ViewModel;
using EnigmaProject.View;

namespace EnigmaProject
{
    public class Enigma
    {
        public RotorsVM Rotors { get; private set; }

        public Plugboard Plugboard { get; private set; }

        public Enigma()
        {
            this.Rotors = new RotorsVM();
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
        public string Decrypt(string data)
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
