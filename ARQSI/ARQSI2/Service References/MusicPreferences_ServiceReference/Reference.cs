﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ARQSI2.MusicPreferences_ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MusicPreferences_ServiceReference.IMusicPreferences_Service")]
    public interface IMusicPreferences_Service {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicPreferences_Service/getDadosiRadioDei", ReplyAction="http://tempuri.org/IMusicPreferences_Service/getDadosiRadioDeiResponse")]
        void getDadosiRadioDei(string namePlaylist, string[] musicas, string location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicPreferences_Service/getDadosiRadioDei", ReplyAction="http://tempuri.org/IMusicPreferences_Service/getDadosiRadioDeiResponse")]
        System.Threading.Tasks.Task getDadosiRadioDeiAsync(string namePlaylist, string[] musicas, string location);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMusicPreferences_ServiceChannel : ARQSI2.MusicPreferences_ServiceReference.IMusicPreferences_Service, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MusicPreferences_ServiceClient : System.ServiceModel.ClientBase<ARQSI2.MusicPreferences_ServiceReference.IMusicPreferences_Service>, ARQSI2.MusicPreferences_ServiceReference.IMusicPreferences_Service {
        
        public MusicPreferences_ServiceClient() {
        }
        
        public MusicPreferences_ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MusicPreferences_ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MusicPreferences_ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MusicPreferences_ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void getDadosiRadioDei(string namePlaylist, string[] musicas, string location) {
            base.Channel.getDadosiRadioDei(namePlaylist, musicas, location);
        }
        
        public System.Threading.Tasks.Task getDadosiRadioDeiAsync(string namePlaylist, string[] musicas, string location) {
            return base.Channel.getDadosiRadioDeiAsync(namePlaylist, musicas, location);
        }
    }
}
