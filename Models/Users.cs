//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Avto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public string login { get; set; }
        public string password { get; set; }
        public int id_roles { get; set; }
        public Nullable<int> id_client { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual roles roles { get; set; }
    }
}
