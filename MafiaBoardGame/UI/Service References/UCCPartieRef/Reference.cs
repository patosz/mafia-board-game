﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI.UCCPartieRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UCCPartieRef.IGestionPartie")]
    public interface IGestionPartie {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/CreerPartie", ReplyAction="http://tempuri.org/IGestionPartie/CreerPartieResponse")]
        bool CreerPartie(string nomPartie, string nomJoueur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/CreerPartie", ReplyAction="http://tempuri.org/IGestionPartie/CreerPartieResponse")]
        System.Threading.Tasks.Task<bool> CreerPartieAsync(string nomPartie, string nomJoueur);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/RejoindrePartie", ReplyAction="http://tempuri.org/IGestionPartie/RejoindrePartieResponse")]
        bool RejoindrePartie(string pseudo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/RejoindrePartie", ReplyAction="http://tempuri.org/IGestionPartie/RejoindrePartieResponse")]
        System.Threading.Tasks.Task<bool> RejoindrePartieAsync(string pseudo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/CommencerPartie", ReplyAction="http://tempuri.org/IGestionPartie/CommencerPartieResponse")]
        bool CommencerPartie();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/CommencerPartie", ReplyAction="http://tempuri.org/IGestionPartie/CommencerPartieResponse")]
        System.Threading.Tasks.Task<bool> CommencerPartieAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/GetPartie", ReplyAction="http://tempuri.org/IGestionPartie/GetPartieResponse")]
        string GetPartie();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionPartie/GetPartie", ReplyAction="http://tempuri.org/IGestionPartie/GetPartieResponse")]
        System.Threading.Tasks.Task<string> GetPartieAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGestionPartieChannel : UI.UCCPartieRef.IGestionPartie, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GestionPartieClient : System.ServiceModel.ClientBase<UI.UCCPartieRef.IGestionPartie>, UI.UCCPartieRef.IGestionPartie {
        
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
        
        public bool CreerPartie(string nomPartie, string nomJoueur) {
            return base.Channel.CreerPartie(nomPartie, nomJoueur);
        }
        
        public System.Threading.Tasks.Task<bool> CreerPartieAsync(string nomPartie, string nomJoueur) {
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
        
        public string GetPartie() {
            return base.Channel.GetPartie();
        }
        
        public System.Threading.Tasks.Task<string> GetPartieAsync() {
            return base.Channel.GetPartieAsync();
        }
    }
}
