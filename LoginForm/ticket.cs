//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginForm
{
    using System;
    using System.Collections.Generic;
    
    public partial class ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ticket()
        {
            this.users = new HashSet<user>();
        }
    
        public int id { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> showtime { get; set; }
        public Nullable<bool> voucher { get; set; }
        public Nullable<int> seat { get; set; }
    
        public virtual seat seat1 { get; set; }
        public virtual showtime showtime1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
