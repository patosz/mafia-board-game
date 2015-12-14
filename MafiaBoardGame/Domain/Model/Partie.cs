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
    
    public partial class Partie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partie()
        {
            this.Sens = true;
            this.JoueursParticipants = new HashSet<JoueurPartie>();
            this.CartePartie = new HashSet<CartePartie>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public System.DateTime DateHeureCreation { get; set; }
        public bool Sens { get; set; }
        public Nullable<int> JoueurId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JoueurPartie> JoueursParticipants { get; set; }
        public virtual Joueur Vainqueur { get; set; }
        public virtual JoueurPartie JoueurCourant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartePartie> CartePartie { get; set; }
    }
}
