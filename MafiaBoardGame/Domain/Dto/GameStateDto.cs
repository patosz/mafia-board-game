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
        [DataMemberAttribute]
        public string JoueurCourant;
        [DataMemberAttribute]
        public List<JoueurStateDto> Adversaires;

        [DataMemberAttribute]
        public List<CarteDto> Cartes;

        [DataMemberAttribute]
        public List<DeDto> Des;
        
        [DataMemberAttribute]
        public int Etat;

    }
}