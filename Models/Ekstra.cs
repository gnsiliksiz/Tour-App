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
    
    public partial class Ekstra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ekstra()
        {
            this.EkstraKots = new HashSet<EkstraKot>();
            this.TurEkstras = new HashSet<TurEkstra>();
        }
    
        public int ekstraID { get; set; }
        public string ekstraAd { get; set; }
        public Nullable<double> ekstraFiyat { get; set; }
        public string ekstraFoto { get; set; }
        public string ekstraFiyatBirimi { get; set; }
        public string ekstraIl { get; set; }
        public string ekstraIlce { get; set; }
        public string ekstraTelefon { get; set; }
        public string ekstraAdres { get; set; }
        public Nullable<int> userID { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EkstraKot> EkstraKots { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TurEkstra> TurEkstras { get; set; }
    }
}
