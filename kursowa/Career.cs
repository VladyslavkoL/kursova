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
    
    public partial class Career
    {
        public long id_career { get; set; }
        public long employee_id { get; set; }
        public long position_id { get; set; }
        public long department_name { get; set; }
        public System.DateTime start_work { get; set; }
        public System.DateTime end_work { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Position Position { get; set; }
        public virtual Department Department { get; set; }
    }
}
