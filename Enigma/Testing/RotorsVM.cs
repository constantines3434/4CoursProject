using EnigmaProject.Model;
using EnigmaProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EnigmaLogicProcessor.Components;
using EnigmaLogicProcessor.Exceptions;
namespace EnigmaProject.View
{
    public class RotorsVM
    {
        public RotorsModel RotorsDataHandler { get; set; }
        #region
        public void Add(RotorModel Rotor, char head)
        {
            RotorModel rotor = Rotor;

            rotor.RotorVMInstance.SetHead(head);
            this.Add(rotor);
        }

        public void Add(RotorModel rotor)
        {
            rotor.IsFirst = this.RotorsDataHandler._list.Count == 0; //this.R_list.Count == 0;
            if (rotor.IsFirst)
                this.RotorsDataHandler._keyboard.RotorDataHandler.Prev = rotor;//.Prev = rotor;
            else
            {
                rotor.Next = this.RotorsDataHandler._list[this.RotorsDataHandler._list.Count - 1];
                this.RotorsDataHandler._list[this.RotorsDataHandler._list.Count - 1].Prev = rotor;
            }
            this.RotorsDataHandler._list.Add(rotor);
            this.RotorsDataHandler.ReflectorData.RotorDataHandler.Prev = rotor;
        }

        public void Clear()
        {
            this.RotorsDataHandler.ReflectorData.RotorDataHandler.Prev = null;
            this.RotorsDataHandler._keyboard.RotorDataHandler.Prev = null;
            this.RotorsDataHandler._list.Clear();
        }

        public void SetHead(params char[] heads)
        {
            if (heads.Length != this.RotorsDataHandler._list.Count)
                throw new EnigmaLogicProcessor.Exceptions.EnigmaRotorsException();

            for (int i = 0; i < heads.Length; i++)
                this.RotorsDataHandler._list[i].RotorVMInstance.SetHead(heads[i]); //?
        }
        //+
        public void SetReflector(RotorModel reflector)
        {
            this.RotorsDataHandler.ReflectorData.RotorDataHandler = reflector;
            if (this.RotorsDataHandler._list.Count > 0)
                this.RotorsDataHandler.ReflectorData.RotorDataHandler.Prev = this.RotorsDataHandler._list[this.RotorsDataHandler._list.Count - 1];
        }
        public char Enter(char @char, Plugboard pb)
        {
            char result = @char;

            // Применение Plugboard перед шифрованием
            if (pb.Exist(result))
                result = pb.Get(result);

            // Прохождение через роторы
            for (int i = 0; i < this.RotorsDataHandler._list.Count; i++)
                result = this.RotorsDataHandler._list[i].RotorVMInstance.Enter(result);

            // Прохождение через отражатель
            result = this.RotorsDataHandler.ReflectorData.Reverse(result);

            // Обратное прохождение через роторы
            for (int i = this.RotorsDataHandler._list.Count - 1; i >= 0; i--)
                result = this.RotorsDataHandler._list[i].RotorVMInstance.Reverse(result);

            // Обратное прохождение через клавиатуру
            result = this.RotorsDataHandler._keyboard.Reverse(result);

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
            result = this.RotorsDataHandler._keyboard.Reverse(result);

            // Обратное прохождение через роторы
            for (int i = this.RotorsDataHandler._list.Count - 1; i >= 0; i--)
                result = this.RotorsDataHandler._list[i].RotorVMInstance.Reverse(result);

            // Обратное прохождение через отражатель
            result = this.RotorsDataHandler.ReflectorData.Reverse(result);

            // Применение Plugboard после дешифрования
            if (pb.Exist(result))
                result = pb.Get(result);

            return result;
        }
        #endregion
    }
}
