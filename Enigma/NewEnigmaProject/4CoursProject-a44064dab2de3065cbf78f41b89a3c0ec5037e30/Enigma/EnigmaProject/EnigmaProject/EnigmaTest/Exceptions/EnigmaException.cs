using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaProject.Exceptions
{
    public class EnigmaException : Exception
    {
        public EnigmaException() : base("Enigma general error")
        {
        }

    }
}
