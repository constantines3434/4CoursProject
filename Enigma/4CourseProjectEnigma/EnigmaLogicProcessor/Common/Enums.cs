﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaLogicProcessor.Common
{
    internal class Enums
    {
        public enum Type : uint
        {
            Unknown = 0,
            Reflector = 1,
            Keyboard = 2,
            Rotor = 3,
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
