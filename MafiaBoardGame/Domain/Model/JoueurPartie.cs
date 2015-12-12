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
    
    public partial class JoueurPartie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JoueurPartie()
        {
            this.De = new HashSet<De>();
            this.Carte = new HashSet<Carte>();
        }
    
        public int Id { get; set; }
        public int OrdreJoueurs { get; set; }
        public int JoueurId { get; set; }
    
        public virtual Joueur Joueur { get; set; }
        public virtual Partie PartieCourante { get; set; }
        public virtual Partie Partie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<De> De { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carte> Carte { get; set; }
    }
}
