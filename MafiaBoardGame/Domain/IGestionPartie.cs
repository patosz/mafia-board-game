using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Domain
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IGestionPartieImpl" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IGestionPartie
    {
        [OperationContract]
        bool CreerPartie(String nomPartie);
        [OperationContract]
        bool RejoindrePartie(String pseudo);
        [OperationContract]
        bool CommencerPartie();
        


    }
}
