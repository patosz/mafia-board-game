using Domain.Dto;
using Domain.Model;
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
        bool CreerPartie(String nomPartie,String nomJoueur);
        [OperationContract]
        bool RejoindrePartie(String pseudo);
        [OperationContract]
        bool CommencerPartie();
        [OperationContract]
        string GetPartieDebug();

        [OperationContract]
        List<PartieDto> VoirPartie(string pseudo);

        [OperationContract]
        PartieDto LancerPartie();

        [OperationContract]
        CarteDto piocherCarte(int IdJoueurPartie);

        void initDe(int IdJoueurPartie);

        [OperationContract]
        JoueurPartieDto getJoueurParticipantDto(int IdJoueurPartie);
        [OperationContract]
        List<JoueurPartieDto> getListJoueurParticipantsDto(int IdPartie);
        [OperationContract]
        List<DeDto> getListDesDto(int IdJoueurPartie);
        [OperationContract]
        List<CarteDto> getListCartesDto(int IdJoueurPartie);
        [OperationContract]
        JoueurDto getJoueurDto(int IdJoueurPartie);
        [OperationContract]
        List<DeDto> lancerDes(int IdJoueurPartie);

        [OperationContract]
        void supprimerUnDe(int IdJoueurPartie,int IdDe);

        [OperationContract]
        void supprimerDeuxDes(int IdJoueurPartie, int IdDe);

        [OperationContract]
        void donnerDeAGaucheOuDroite(int IdJoueurPartie, bool sens);

        [OperationContract]
        void rejouerEtChangementDeSens(int IdJoueurPartie);

        [OperationContract]
        void prendreUneCarteDUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible);

        [OperationContract]
        void donnerUnDeAUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible, int IdDe);

        [OperationContract]
        void ciblerJoueurQUUneCarte(int IdJoueurPartie,int IdJoueurPartieCible);

        [OperationContract]
        void passeSonTour(int IdJoueurPartie, int IdJoueurPartieCible);

        [OperationContract]
        void piocheTroisCartes(int IdJoueurPartie);

        [OperationContract]
        void plusQueDeuxCartesPourLesAutres(int IdJoueurPartie);


    }
}
