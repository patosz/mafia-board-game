using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Dto
{
    [DataContract]
    public class PartieDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public DateTime DateHeureCreation { get; set; }
        [DataMember]
        public bool Sens { get; set; }
        //[DataMember]
        //public List<CarteDto> CartesPioche { get; set; }
        //[DataMember]
        //public JoueurPartieDto JoueurCourant { get; set; }
        //[DataMember]
        //public List<JoueurPartieDto> JoueursParticipants { get; set; }
        [DataMember]
        public JoueurDto Vainqueur { get; set; }
    }
}