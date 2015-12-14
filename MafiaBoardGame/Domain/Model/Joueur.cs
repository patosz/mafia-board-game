//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Joueur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Joueur()
        {
            this.PartiesJouees = new HashSet<JoueurPartie>();
            this.PartiesGagnees = new HashSet<Partie>();
        }
    
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Mdp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JoueurPartie> PartiesJouees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partie> PartiesGagnees { get; set; }
    }
}
