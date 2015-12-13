using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain
{

    //TODO ID useless ?
    //TODO Etendre Biz au DTO ??

    [DataContract]
    public class JoueurDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Pseudo { get; set; }
        [DataMember]
        public string Mdp { get; set; }
    }
}