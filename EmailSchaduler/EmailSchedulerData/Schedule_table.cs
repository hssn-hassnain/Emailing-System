//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmailSchedulerData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule_table
    {
        public int id { get; set; }
        public System.DateTime Time { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }
    }
}
