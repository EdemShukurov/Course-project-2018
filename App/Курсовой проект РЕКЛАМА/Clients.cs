//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Курсовой_проект_РЕКЛАМА
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clients
    {
        public Clients()
        {
            this.Advertisements = new HashSet<Advertisements>();
        }
    
        public byte cl_id { get; set; }
        public string cl_surname { get; set; }
        public string cl_name { get; set; }
        public string cl_lastname { get; set; }
        public string cl_passport { get; set; }
        public string cl_tel { get; set; }
        public string cl_bankcard { get; set; }
    
        public virtual ICollection<Advertisements> Advertisements { get; set; }
    }
}
