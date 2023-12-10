using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaProject.Common
{
    internal class Enums
    {
        public enum Type : uint
        {
            Unknown = 0,
            ReflectorNotMVVM = 1,
            Keyboard = 2,
            RotorNotMVVM = 3,
        }
        public enum RotorType : uint
        {
            Unknown = 0,
            Rotor_I,
            Rotor_II,
            Rotor_III,
        }
        public enum ReflectorType : uint
        {
            Unknown = 0,
            UWK_A,
            UWK_B,
            UWK_C,
        }
    }
}
