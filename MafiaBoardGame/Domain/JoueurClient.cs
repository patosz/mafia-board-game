using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain
{

    //pas utile je pense
    [DataContract]
    public class JoueurClient
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Pseudo { get; set; }
        [DataMember]
        public string Mdp { get; set; }
    }
}