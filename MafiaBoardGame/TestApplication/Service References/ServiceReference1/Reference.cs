﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestApplication.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IGestionJoueur")]
    public interface IGestionJoueur {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionJoueur/InscriptionJoueur", ReplyAction="http://tempuri.org/IGestionJoueur/InscriptionJoueurResponse")]
        bool InscriptionJoueur(string pseudo, string mdp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionJoueur/InscriptionJoueur", ReplyAction="http://tempuri.org/IGestionJoueur/InscriptionJoueurResponse")]
        System.Threading.Tasks.Task<bool> InscriptionJoueurAsync(string pseudo, string mdp);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGestionJoueurChannel : TestApplication.ServiceReference1.IGestionJoueur, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GestionJoueurClient : System.ServiceModel.ClientBase<TestApplication.ServiceReference1.IGestionJoueur>, TestApplication.ServiceReference1.IGestionJoueur {
        
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
    }
}
