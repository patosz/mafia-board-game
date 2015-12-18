using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ModelPlateau
    {


        public string JoueurCourant { get; set; }

        public List<AdversaireModel> Adversaires { get; set; }

        public List<CarteDto> MesCartes { get; set; }

        public List<DeDto> MesDes { get; set; }

        public ETAT_PARTIE Etat { get; set; }

        public CarteDto DerniereCarteJouee { get; set; }

    }

}