//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmsMvc.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Class()
        {
            this.Tbl_Grade = new HashSet<Tbl_Grade>();
            this.Tbl_Teacher = new HashSet<Tbl_Teacher>();
        }
    
        public byte ClassId { get; set; }
        public string ClassName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Grade> Tbl_Grade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Teacher> Tbl_Teacher { get; set; }
    }
}