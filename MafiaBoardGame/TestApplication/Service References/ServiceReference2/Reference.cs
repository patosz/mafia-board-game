﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestApplication.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IGestionPartie")]
    public interface IGestionPartie {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/CreerPartie", ReplyAction="http://tempuri.org/IGestionPartie/CreerPartieResponse")]
        Domain.Dto.PartieDto CreerPartie(string nomPartie, string nomJoueur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/CreerPartie", ReplyAction="http://tempuri.org/IGestionPartie/CreerPartieResponse")]
        System.Threading.Tasks.Task<Domain.Dto.PartieDto> CreerPartieAsync(string nomPartie, string nomJoueur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/RejoindrePartie", ReplyAction="http://tempuri.org/IGestionPartie/RejoindrePartieResponse")]
        bool RejoindrePartie(string pseudo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/RejoindrePartie", ReplyAction="http://tempuri.org/IGestionPartie/RejoindrePartieResponse")]
        System.Threading.Tasks.Task<bool> RejoindrePartieAsync(string pseudo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/CommencerPartie", ReplyAction="http://tempuri.org/IGestionPartie/CommencerPartieResponse")]
        bool CommencerPartie();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/CommencerPartie", ReplyAction="http://tempuri.org/IGestionPartie/CommencerPartieResponse")]
        System.Threading.Tasks.Task<bool> CommencerPartieAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/GetPartieDebug", ReplyAction="http://tempuri.org/IGestionPartie/GetPartieDebugResponse")]
        string GetPartieDebug();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/GetPartieDebug", ReplyAction="http://tempuri.org/IGestionPartie/GetPartieDebugResponse")]
        System.Threading.Tasks.Task<string> GetPartieDebugAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/VoirPartie", ReplyAction="http://tempuri.org/IGestionPartie/VoirPartieResponse")]
        System.Collections.Generic.List<Domain.Dto.PartieDto> VoirPartie(string pseudo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/VoirPartie", ReplyAction="http://tempuri.org/IGestionPartie/VoirPartieResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.PartieDto>> VoirPartieAsync(string pseudo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/LancerPartie", ReplyAction="http://tempuri.org/IGestionPartie/LancerPartieResponse")]
        Domain.Dto.PartieDto LancerPartie();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/LancerPartie", ReplyAction="http://tempuri.org/IGestionPartie/LancerPartieResponse")]
        System.Threading.Tasks.Task<Domain.Dto.PartieDto> LancerPartieAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/piocherCarte", ReplyAction="http://tempuri.org/IGestionPartie/piocherCarteResponse")]
        Domain.Dto.CarteDto piocherCarte(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/piocherCarte", ReplyAction="http://tempuri.org/IGestionPartie/piocherCarteResponse")]
        System.Threading.Tasks.Task<Domain.Dto.CarteDto> piocherCarteAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getJoueurParticipantDto", ReplyAction="http://tempuri.org/IGestionPartie/getJoueurParticipantDtoResponse")]
        Domain.Dto.JoueurPartieDto getJoueurParticipantDto(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getJoueurParticipantDto", ReplyAction="http://tempuri.org/IGestionPartie/getJoueurParticipantDtoResponse")]
        System.Threading.Tasks.Task<Domain.Dto.JoueurPartieDto> getJoueurParticipantDtoAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getListJoueurParticipantsDto", ReplyAction="http://tempuri.org/IGestionPartie/getListJoueurParticipantsDtoResponse")]
        System.Collections.Generic.List<Domain.Dto.JoueurPartieDto> getListJoueurParticipantsDto(int IdPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getListJoueurParticipantsDto", ReplyAction="http://tempuri.org/IGestionPartie/getListJoueurParticipantsDtoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.JoueurPartieDto>> getListJoueurParticipantsDtoAsync(int IdPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getListDesDto", ReplyAction="http://tempuri.org/IGestionPartie/getListDesDtoResponse")]
        System.Collections.Generic.List<Domain.Dto.DeDto> getListDesDto(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getListDesDto", ReplyAction="http://tempuri.org/IGestionPartie/getListDesDtoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.DeDto>> getListDesDtoAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getListCartesDto", ReplyAction="http://tempuri.org/IGestionPartie/getListCartesDtoResponse")]
        System.Collections.Generic.List<Domain.Dto.CarteDto> getListCartesDto(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getListCartesDto", ReplyAction="http://tempuri.org/IGestionPartie/getListCartesDtoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.CarteDto>> getListCartesDtoAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getJoueurDto", ReplyAction="http://tempuri.org/IGestionPartie/getJoueurDtoResponse")]
        Domain.JoueurDto getJoueurDto(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getJoueurDto", ReplyAction="http://tempuri.org/IGestionPartie/getJoueurDtoResponse")]
        System.Threading.Tasks.Task<Domain.JoueurDto> getJoueurDtoAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/lancerDes", ReplyAction="http://tempuri.org/IGestionPartie/lancerDesResponse")]
        System.Collections.Generic.List<Domain.Dto.DeDto> lancerDes(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/lancerDes", ReplyAction="http://tempuri.org/IGestionPartie/lancerDesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.DeDto>> lancerDesAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/autoriserCarte", ReplyAction="http://tempuri.org/IGestionPartie/autoriserCarteResponse")]
        bool autoriserCarte(int idJoueurPartie, int cout);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/autoriserCarte", ReplyAction="http://tempuri.org/IGestionPartie/autoriserCarteResponse")]
        System.Threading.Tasks.Task<bool> autoriserCarteAsync(int idJoueurPartie, int cout);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/donnerDe", ReplyAction="http://tempuri.org/IGestionPartie/donnerDeResponse")]
        bool donnerDe(int IdJoueurPartie, int IdJoueurCible);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/donnerDe", ReplyAction="http://tempuri.org/IGestionPartie/donnerDeResponse")]
        System.Threading.Tasks.Task<bool> donnerDeAsync(int IdJoueurPartie, int IdJoueurCible);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/next", ReplyAction="http://tempuri.org/IGestionPartie/nextResponse")]
        Domain.Dto.JoueurPartieDto next();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/next", ReplyAction="http://tempuri.org/IGestionPartie/nextResponse")]
        System.Threading.Tasks.Task<Domain.Dto.JoueurPartieDto> nextAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/supprimerUnDe", ReplyAction="http://tempuri.org/IGestionPartie/supprimerUnDeResponse")]
        void supprimerUnDe(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/supprimerUnDe", ReplyAction="http://tempuri.org/IGestionPartie/supprimerUnDeResponse")]
        System.Threading.Tasks.Task supprimerUnDeAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/supprimerDeuxDes", ReplyAction="http://tempuri.org/IGestionPartie/supprimerDeuxDesResponse")]
        void supprimerDeuxDes(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/supprimerDeuxDes", ReplyAction="http://tempuri.org/IGestionPartie/supprimerDeuxDesResponse")]
        System.Threading.Tasks.Task supprimerDeuxDesAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/donnerDeAGaucheOuDroite", ReplyAction="http://tempuri.org/IGestionPartie/donnerDeAGaucheOuDroiteResponse")]
        void donnerDeAGaucheOuDroite();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/donnerDeAGaucheOuDroite", ReplyAction="http://tempuri.org/IGestionPartie/donnerDeAGaucheOuDroiteResponse")]
        System.Threading.Tasks.Task donnerDeAGaucheOuDroiteAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/rejouerEtChangementDeSens", ReplyAction="http://tempuri.org/IGestionPartie/rejouerEtChangementDeSensResponse")]
        void rejouerEtChangementDeSens(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/rejouerEtChangementDeSens", ReplyAction="http://tempuri.org/IGestionPartie/rejouerEtChangementDeSensResponse")]
        System.Threading.Tasks.Task rejouerEtChangementDeSensAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/prendreUneCarteDUnJoueur", ReplyAction="http://tempuri.org/IGestionPartie/prendreUneCarteDUnJoueurResponse")]
        void prendreUneCarteDUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/prendreUneCarteDUnJoueur", ReplyAction="http://tempuri.org/IGestionPartie/prendreUneCarteDUnJoueurResponse")]
        System.Threading.Tasks.Task prendreUneCarteDUnJoueurAsync(int IdJoueurPartie, int IdJoueurPartieCible);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/donnerUnDeAUnJoueur", ReplyAction="http://tempuri.org/IGestionPartie/donnerUnDeAUnJoueurResponse")]
        void donnerUnDeAUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/donnerUnDeAUnJoueur", ReplyAction="http://tempuri.org/IGestionPartie/donnerUnDeAUnJoueurResponse")]
        System.Threading.Tasks.Task donnerUnDeAUnJoueurAsync(int IdJoueurPartie, int IdJoueurPartieCible);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/ciblerJoueurQUUneCarte", ReplyAction="http://tempuri.org/IGestionPartie/ciblerJoueurQUUneCarteResponse")]
        void ciblerJoueurQUUneCarte(int IdJoueurPartieCible);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/ciblerJoueurQUUneCarte", ReplyAction="http://tempuri.org/IGestionPartie/ciblerJoueurQUUneCarteResponse")]
        System.Threading.Tasks.Task ciblerJoueurQUUneCarteAsync(int IdJoueurPartieCible);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/piocheTroisCartes", ReplyAction="http://tempuri.org/IGestionPartie/piocheTroisCartesResponse")]
        void piocheTroisCartes(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/piocheTroisCartes", ReplyAction="http://tempuri.org/IGestionPartie/piocheTroisCartesResponse")]
        System.Threading.Tasks.Task piocheTroisCartesAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/plusQueDeuxCartesPourLesAutres", ReplyAction="http://tempuri.org/IGestionPartie/plusQueDeuxCartesPourLesAutresResponse")]
        void plusQueDeuxCartesPourLesAutres(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/plusQueDeuxCartesPourLesAutres", ReplyAction="http://tempuri.org/IGestionPartie/plusQueDeuxCartesPourLesAutresResponse")]
        System.Threading.Tasks.Task plusQueDeuxCartesPourLesAutresAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/jeterCartePoubelle", ReplyAction="http://tempuri.org/IGestionPartie/jeterCartePoubelleResponse")]
        void jeterCartePoubelle(int IdJoueurPartie, int IdCarte);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/jeterCartePoubelle", ReplyAction="http://tempuri.org/IGestionPartie/jeterCartePoubelleResponse")]
        System.Threading.Tasks.Task jeterCartePoubelleAsync(int IdJoueurPartie, int IdCarte);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/quitterPartie", ReplyAction="http://tempuri.org/IGestionPartie/quitterPartieResponse")]
        Domain.Dto.JoueurPartieDto quitterPartie(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/quitterPartie", ReplyAction="http://tempuri.org/IGestionPartie/quitterPartieResponse")]
        System.Threading.Tasks.Task<Domain.Dto.JoueurPartieDto> quitterPartieAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/vainqueurParForfait", ReplyAction="http://tempuri.org/IGestionPartie/vainqueurParForfaitResponse")]
        Domain.JoueurDto vainqueurParForfait();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/vainqueurParForfait", ReplyAction="http://tempuri.org/IGestionPartie/vainqueurParForfaitResponse")]
        System.Threading.Tasks.Task<Domain.JoueurDto> vainqueurParForfaitAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/vainqueur", ReplyAction="http://tempuri.org/IGestionPartie/vainqueurResponse")]
        Domain.JoueurDto vainqueur(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/vainqueur", ReplyAction="http://tempuri.org/IGestionPartie/vainqueurResponse")]
        System.Threading.Tasks.Task<Domain.JoueurDto> vainqueurAsync(int IdJoueurPartie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getGameState", ReplyAction="http://tempuri.org/IGestionPartie/getGameStateResponse")]
        Domain.Dto.GameStateDto getGameState(string nomJoueur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/getGameState", ReplyAction="http://tempuri.org/IGestionPartie/getGameStateResponse")]
        System.Threading.Tasks.Task<Domain.Dto.GameStateDto> getGameStateAsync(string nomJoueur);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGestionPartieChannel : TestApplication.ServiceReference2.IGestionPartie, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GestionPartieClient : System.ServiceModel.ClientBase<TestApplication.ServiceReference2.IGestionPartie>, TestApplication.ServiceReference2.IGestionPartie {
        
        public GestionPartieClient() {
        }
        
        public GestionPartieClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GestionPartieClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionPartieClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionPartieClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Domain.Dto.PartieDto CreerPartie(string nomPartie, string nomJoueur) {
            return base.Channel.CreerPartie(nomPartie, nomJoueur);
        }
        
        public System.Threading.Tasks.Task<Domain.Dto.PartieDto> CreerPartieAsync(string nomPartie, string nomJoueur) {
            return base.Channel.CreerPartieAsync(nomPartie, nomJoueur);
        }
        
        public bool RejoindrePartie(string pseudo) {
            return base.Channel.RejoindrePartie(pseudo);
        }
        
        public System.Threading.Tasks.Task<bool> RejoindrePartieAsync(string pseudo) {
            return base.Channel.RejoindrePartieAsync(pseudo);
        }
        
        public bool CommencerPartie() {
            return base.Channel.CommencerPartie();
        }
        
        public System.Threading.Tasks.Task<bool> CommencerPartieAsync() {
            return base.Channel.CommencerPartieAsync();
        }
        
        public string GetPartieDebug() {
            return base.Channel.GetPartieDebug();
        }
        
        public System.Threading.Tasks.Task<string> GetPartieDebugAsync() {
            return base.Channel.GetPartieDebugAsync();
        }
        
        public System.Collections.Generic.List<Domain.Dto.PartieDto> VoirPartie(string pseudo) {
            return base.Channel.VoirPartie(pseudo);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.PartieDto>> VoirPartieAsync(string pseudo) {
            return base.Channel.VoirPartieAsync(pseudo);
        }
        
        public Domain.Dto.PartieDto LancerPartie() {
            return base.Channel.LancerPartie();
        }
        
        public System.Threading.Tasks.Task<Domain.Dto.PartieDto> LancerPartieAsync() {
            return base.Channel.LancerPartieAsync();
        }
        
        public Domain.Dto.CarteDto piocherCarte(int IdJoueurPartie) {
            return base.Channel.piocherCarte(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task<Domain.Dto.CarteDto> piocherCarteAsync(int IdJoueurPartie) {
            return base.Channel.piocherCarteAsync(IdJoueurPartie);
        }
        
        public Domain.Dto.JoueurPartieDto getJoueurParticipantDto(int IdJoueurPartie) {
            return base.Channel.getJoueurParticipantDto(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task<Domain.Dto.JoueurPartieDto> getJoueurParticipantDtoAsync(int IdJoueurPartie) {
            return base.Channel.getJoueurParticipantDtoAsync(IdJoueurPartie);
        }
        
        public System.Collections.Generic.List<Domain.Dto.JoueurPartieDto> getListJoueurParticipantsDto(int IdPartie) {
            return base.Channel.getListJoueurParticipantsDto(IdPartie);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.JoueurPartieDto>> getListJoueurParticipantsDtoAsync(int IdPartie) {
            return base.Channel.getListJoueurParticipantsDtoAsync(IdPartie);
        }
        
        public System.Collections.Generic.List<Domain.Dto.DeDto> getListDesDto(int IdJoueurPartie) {
            return base.Channel.getListDesDto(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.DeDto>> getListDesDtoAsync(int IdJoueurPartie) {
            return base.Channel.getListDesDtoAsync(IdJoueurPartie);
        }
        
        public System.Collections.Generic.List<Domain.Dto.CarteDto> getListCartesDto(int IdJoueurPartie) {
            return base.Channel.getListCartesDto(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.CarteDto>> getListCartesDtoAsync(int IdJoueurPartie) {
            return base.Channel.getListCartesDtoAsync(IdJoueurPartie);
        }
        
        public Domain.JoueurDto getJoueurDto(int IdJoueurPartie) {
            return base.Channel.getJoueurDto(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task<Domain.JoueurDto> getJoueurDtoAsync(int IdJoueurPartie) {
            return base.Channel.getJoueurDtoAsync(IdJoueurPartie);
        }
        
        public System.Collections.Generic.List<Domain.Dto.DeDto> lancerDes(int IdJoueurPartie) {
            return base.Channel.lancerDes(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Domain.Dto.DeDto>> lancerDesAsync(int IdJoueurPartie) {
            return base.Channel.lancerDesAsync(IdJoueurPartie);
        }
        
        public bool autoriserCarte(int idJoueurPartie, int cout) {
            return base.Channel.autoriserCarte(idJoueurPartie, cout);
        }
        
        public System.Threading.Tasks.Task<bool> autoriserCarteAsync(int idJoueurPartie, int cout) {
            return base.Channel.autoriserCarteAsync(idJoueurPartie, cout);
        }
        
        public bool donnerDe(int IdJoueurPartie, int IdJoueurCible) {
            return base.Channel.donnerDe(IdJoueurPartie, IdJoueurCible);
        }
        
        public System.Threading.Tasks.Task<bool> donnerDeAsync(int IdJoueurPartie, int IdJoueurCible) {
            return base.Channel.donnerDeAsync(IdJoueurPartie, IdJoueurCible);
        }
        
        public Domain.Dto.JoueurPartieDto next() {
            return base.Channel.next();
        }
        
        public System.Threading.Tasks.Task<Domain.Dto.JoueurPartieDto> nextAsync() {
            return base.Channel.nextAsync();
        }
        
        public void supprimerUnDe(int IdJoueurPartie) {
            base.Channel.supprimerUnDe(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task supprimerUnDeAsync(int IdJoueurPartie) {
            return base.Channel.supprimerUnDeAsync(IdJoueurPartie);
        }
        
        public void supprimerDeuxDes(int IdJoueurPartie) {
            base.Channel.supprimerDeuxDes(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task supprimerDeuxDesAsync(int IdJoueurPartie) {
            return base.Channel.supprimerDeuxDesAsync(IdJoueurPartie);
        }
        
        public void donnerDeAGaucheOuDroite() {
            base.Channel.donnerDeAGaucheOuDroite();
        }
        
        public System.Threading.Tasks.Task donnerDeAGaucheOuDroiteAsync() {
            return base.Channel.donnerDeAGaucheOuDroiteAsync();
        }
        
        public void rejouerEtChangementDeSens(int IdJoueurPartie) {
            base.Channel.rejouerEtChangementDeSens(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task rejouerEtChangementDeSensAsync(int IdJoueurPartie) {
            return base.Channel.rejouerEtChangementDeSensAsync(IdJoueurPartie);
        }
        
        public void prendreUneCarteDUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible) {
            base.Channel.prendreUneCarteDUnJoueur(IdJoueurPartie, IdJoueurPartieCible);
        }
        
        public System.Threading.Tasks.Task prendreUneCarteDUnJoueurAsync(int IdJoueurPartie, int IdJoueurPartieCible) {
            return base.Channel.prendreUneCarteDUnJoueurAsync(IdJoueurPartie, IdJoueurPartieCible);
        }
        
        public void donnerUnDeAUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible) {
            base.Channel.donnerUnDeAUnJoueur(IdJoueurPartie, IdJoueurPartieCible);
        }
        
        public System.Threading.Tasks.Task donnerUnDeAUnJoueurAsync(int IdJoueurPartie, int IdJoueurPartieCible) {
            return base.Channel.donnerUnDeAUnJoueurAsync(IdJoueurPartie, IdJoueurPartieCible);
        }
        
        public void ciblerJoueurQUUneCarte(int IdJoueurPartieCible) {
            base.Channel.ciblerJoueurQUUneCarte(IdJoueurPartieCible);
        }
        
        public System.Threading.Tasks.Task ciblerJoueurQUUneCarteAsync(int IdJoueurPartieCible) {
            return base.Channel.ciblerJoueurQUUneCarteAsync(IdJoueurPartieCible);
        }
        
        public void piocheTroisCartes(int IdJoueurPartie) {
            base.Channel.piocheTroisCartes(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task piocheTroisCartesAsync(int IdJoueurPartie) {
            return base.Channel.piocheTroisCartesAsync(IdJoueurPartie);
        }
        
        public void plusQueDeuxCartesPourLesAutres(int IdJoueurPartie) {
            base.Channel.plusQueDeuxCartesPourLesAutres(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task plusQueDeuxCartesPourLesAutresAsync(int IdJoueurPartie) {
            return base.Channel.plusQueDeuxCartesPourLesAutresAsync(IdJoueurPartie);
        }
        
        public void jeterCartePoubelle(int IdJoueurPartie, int IdCarte) {
            base.Channel.jeterCartePoubelle(IdJoueurPartie, IdCarte);
        }
        
        public System.Threading.Tasks.Task jeterCartePoubelleAsync(int IdJoueurPartie, int IdCarte) {
            return base.Channel.jeterCartePoubelleAsync(IdJoueurPartie, IdCarte);
        }
        
        public Domain.Dto.JoueurPartieDto quitterPartie(int IdJoueurPartie) {
            return base.Channel.quitterPartie(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task<Domain.Dto.JoueurPartieDto> quitterPartieAsync(int IdJoueurPartie) {
            return base.Channel.quitterPartieAsync(IdJoueurPartie);
        }
        
        public Domain.JoueurDto vainqueurParForfait() {
            return base.Channel.vainqueurParForfait();
        }
        
        public System.Threading.Tasks.Task<Domain.JoueurDto> vainqueurParForfaitAsync() {
            return base.Channel.vainqueurParForfaitAsync();
        }
        
        public Domain.JoueurDto vainqueur(int IdJoueurPartie) {
            return base.Channel.vainqueur(IdJoueurPartie);
        }
        
        public System.Threading.Tasks.Task<Domain.JoueurDto> vainqueurAsync(int IdJoueurPartie) {
            return base.Channel.vainqueurAsync(IdJoueurPartie);
        }
        
        public Domain.Dto.GameStateDto getGameState(string nomJoueur) {
            return base.Channel.getGameState(nomJoueur);
        }
        
        public System.Threading.Tasks.Task<Domain.Dto.GameStateDto> getGameStateAsync(string nomJoueur) {
            return base.Channel.getGameStateAsync(nomJoueur);
        }
    }
}
