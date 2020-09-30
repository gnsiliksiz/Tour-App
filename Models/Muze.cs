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
    using System.ComponentModel.DataAnnotations;

    public partial class Muze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Muze()
        {
            this.MuzeKots = new HashSet<MuzeKot>();
            this.TurMuzes = new HashSet<TurMuze>();
        }
    
        public int muzeID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string muzeAd { get; set; }
        [Required]
        public string muzeIl { get; set; }
        [Required]
        public string muzeIlce { get; set; }
        public string muzeFoto { get; set; }
        public string muzeAdres { get; set; }
        public Nullable<double> muzeGirisFiyat { get; set; }
        public string muzeFiyatBirim { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuzeKot> MuzeKots { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TurMuze> TurMuzes { get; set; }
    }
}
