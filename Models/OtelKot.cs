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
    
    public partial class OtelKot
    {
        public int otelKotID { get; set; }
        public string otelkotTarih { get; set; }
        public Nullable<int> singleKisi { get; set; }
        public Nullable<int> doubleKisi { get; set; }
        public Nullable<int> familyKisi { get; set; }
        public Nullable<int> kingSuitKisi { get; set; }
        public Nullable<double> otelToplamFiyat { get; set; }
        public Nullable<int> otelID { get; set; }
        public Nullable<int> kotasyonID { get; set; }
    
        public virtual Kotasyon Kotasyon { get; set; }
        public virtual Otel Otel { get; set; }
    }
}
