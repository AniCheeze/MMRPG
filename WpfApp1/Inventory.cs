//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stat { get; set; }
        public Nullable<int> IdSaveData { get; set; }
        public Nullable<bool> IsArmor { get; set; }
    
        public virtual SaveData SaveData { get; set; }
    }
}
