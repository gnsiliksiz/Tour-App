//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MuzeKot
    {
        public int muzeKotID { get; set; }
        public string muzeTarih { get; set; }
        public Nullable<double> muzeToplamFiyat { get; set; }
        public Nullable<int> muzeID { get; set; }
        public Nullable<int> kotasyonID { get; set; }
    
        public virtual Kotasyon Kotasyon { get; set; }
        public virtual Muze Muze { get; set; }
    }
}
