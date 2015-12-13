﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI.UCCJoueurRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UCCJoueurRef.IGestionJoueur")]
    public interface IGestionJoueur {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionJoueur/InscriptionJoueur", ReplyAction="http://tempuri.org/IGestionJoueur/InscriptionJoueurResponse")]
        bool InscriptionJoueur(string pseudo, string mdp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionJoueur/InscriptionJoueur", ReplyAction="http://tempuri.org/IGestionJoueur/InscriptionJoueurResponse")]
        System.Threading.Tasks.Task<bool> InscriptionJoueurAsync(string pseudo, string mdp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionJoueur/ConnexionJoueur", ReplyAction="http://tempuri.org/IGestionJoueur/ConnexionJoueurResponse")]
        bool ConnexionJoueur(string pseudo, string mdp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionJoueur/ConnexionJoueur", ReplyAction="http://tempuri.org/IGestionJoueur/ConnexionJoueurResponse")]
        System.Threading.Tasks.Task<bool> ConnexionJoueurAsync(string pseudo, string mdp);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGestionJoueurChannel : UI.UCCJoueurRef.IGestionJoueur, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GestionJoueurClient : System.ServiceModel.ClientBase<UI.UCCJoueurRef.IGestionJoueur>, UI.UCCJoueurRef.IGestionJoueur {
        
        public GestionJoueurClient() {
        }
        
        public GestionJoueurClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GestionJoueurClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionJoueurClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionJoueurClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool InscriptionJoueur(string pseudo, string mdp) {
            return base.Channel.InscriptionJoueur(pseudo, mdp);
        }
        
        public System.Threading.Tasks.Task<bool> InscriptionJoueurAsync(string pseudo, string mdp) {
            return base.Channel.InscriptionJoueurAsync(pseudo, mdp);
        }
        
        public bool ConnexionJoueur(string pseudo, string mdp) {
            return base.Channel.ConnexionJoueur(pseudo, mdp);
        }
        
        public System.Threading.Tasks.Task<bool> ConnexionJoueurAsync(string pseudo, string mdp) {
            return base.Channel.ConnexionJoueurAsync(pseudo, mdp);
        }
    }
}
