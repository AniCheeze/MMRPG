//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Players
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Players()
        {
            this.SaveData = new HashSet<SaveData>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int HP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaveData> SaveData { get; set; }
    }
}
