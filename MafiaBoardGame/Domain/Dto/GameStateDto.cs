using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Dto
{
    [DataContract]
    public class GameStateDto
    {
        [DataMember]
        public string JoueurCourant;
        [DataMember]
        public List<JoueurStateDto> Adversaires;

        [DataMember]
        public List<CarteDto> Cartes;

        [DataMember]
        public List<DeDto> Des;
        
        [DataMember]
        public ETAT_PARTIE Etat;

    }
}