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
    
    public partial class Tbl_Grade
    {
        public int GradeId { get; set; }
        public Nullable<byte> ClassId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<byte> Exam1 { get; set; }
        public Nullable<byte> Exam2 { get; set; }
        public Nullable<byte> Exam3 { get; set; }
        public Nullable<byte> Project { get; set; }
        public Nullable<decimal> Average { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual Tbl_Class Tbl_Class { get; set; }
        public virtual Tbl_Student Tbl_Student { get; set; }
    }
}