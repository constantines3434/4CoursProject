//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnigmaProject.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SetOfRotor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SetOfRotor()
        {
            this.EnigmaMachines = new HashSet<EnigmaMachine>();
            this.Rotors = new HashSet<Rotor>();
        }
    
        public int IdSetOfRotors { get; set; }
        public string NameOfSetOfRotors { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnigmaMachine> EnigmaMachines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rotor> Rotors { get; set; }
    }
}
