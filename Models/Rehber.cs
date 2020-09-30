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
    
    public partial class Rehber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rehber()
        {
            this.Dils = new HashSet<Dil>();
            this.Turs = new HashSet<Tur>();
        }
    
        public int rehberID { get; set; }
        public string rehberUsername { get; set; }
        public string rehberPassword { get; set; }
        public string rehberAd { get; set; }
        public string rehberTelefon { get; set; }
        public string rehberEmail { get; set; }
        public string rehberPhoto { get; set; }
        public string rehberAdres { get; set; }
        public string rehberCinsiyet { get; set; }
        public Nullable<double> rehberRating { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dil> Dils { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tur> Turs { get; set; }
    }
}
