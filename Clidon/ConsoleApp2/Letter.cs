//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Letter
    {
        public int Letters_Code { get; set; }
        public Nullable<int> Ascii_Code { get; set; }
        public string Letter_Image { get; set; }
        public Nullable<int> User_Code { get; set; }
    
        public virtual User User { get; set; }
    }
}
