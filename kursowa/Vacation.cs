//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kursowa
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vacation
    {
        public long id_vacation { get; set; }
        public long employee_id { get; set; }
        public System.DateTime vacation_start { get; set; }
        public System.DateTime vacation_end { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
