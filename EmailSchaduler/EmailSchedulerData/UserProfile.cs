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
    
    public partial class UserProfile
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_NO { get; set; }
        public string Gender { get; set; }
    
        public virtual Schedule_table Schedule_table { get; set; }
        public virtual Status_table Status_table { get; set; }
    }
}