﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestApplication.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IGestionJoueurImpl")]
    public interface IGestionJoueurImpl {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionJoueurImpl/InscriptionJoueur", ReplyAction="http://tempuri.org/IGestionJoueurImpl/InscriptionJoueurResponse")]
        bool InscriptionJoueur(string pseudo, string mdp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionJoueurImpl/InscriptionJoueur", ReplyAction="http://tempuri.org/IGestionJoueurImpl/InscriptionJoueurResponse")]
        System.Threading.Tasks.Task<bool> InscriptionJoueurAsync(string pseudo, string mdp);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGestionJoueurImplChannel : TestApplication.ServiceReference1.IGestionJoueurImpl, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GestionJoueurImplClient : System.ServiceModel.ClientBase<TestApplication.ServiceReference1.IGestionJoueurImpl>, TestApplication.ServiceReference1.IGestionJoueurImpl {
        
        public GestionJoueurImplClient() {
        }
        
        public GestionJoueurImplClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GestionJoueurImplClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionJoueurImplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionJoueurImplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool InscriptionJoueur(string pseudo, string mdp) {
            return base.Channel.InscriptionJoueur(pseudo, mdp);
        }
        
        public System.Threading.Tasks.Task<bool> InscriptionJoueurAsync(string pseudo, string mdp) {
            return base.Channel.InscriptionJoueurAsync(pseudo, mdp);
        }
    }
}