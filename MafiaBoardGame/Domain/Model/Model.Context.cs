﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelContainer : DbContext
    {
        public ModelContainer()
            : base("name=ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Joueur> JoueurSet { get; set; }
        public virtual DbSet<Partie> PartieSet { get; set; }
        public virtual DbSet<JoueurPartie> JoueurPartieSet { get; set; }
        public virtual DbSet<De> DeSet { get; set; }
        public virtual DbSet<Carte> CarteSet { get; set; }
    }
}