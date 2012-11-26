﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17020
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuGetPackageUploader.nuget {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="nuget.UploadPackageSoap")]
    public interface UploadPackageSoap {
        
        // CODEGEN: Generating message contract since element name data from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Upload", ReplyAction="*")]
        NuGetPackageUploader.nuget.UploadResponse Upload(NuGetPackageUploader.nuget.UploadRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Upload", Namespace="http://tempuri.org/", Order=0)]
        public NuGetPackageUploader.nuget.UploadRequestBody Body;
        
        public UploadRequest() {
        }
        
        public UploadRequest(NuGetPackageUploader.nuget.UploadRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UploadRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public byte[] data;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string fileName;
        
        public UploadRequestBody() {
        }
        
        public UploadRequestBody(byte[] data, string fileName) {
            this.data = data;
            this.fileName = fileName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UploadResponse", Namespace="http://tempuri.org/", Order=0)]
        public NuGetPackageUploader.nuget.UploadResponseBody Body;
        
        public UploadResponse() {
        }
        
        public UploadResponse(NuGetPackageUploader.nuget.UploadResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class UploadResponseBody {
        
        public UploadResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UploadPackageSoapChannel : NuGetPackageUploader.nuget.UploadPackageSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UploadPackageSoapClient : System.ServiceModel.ClientBase<NuGetPackageUploader.nuget.UploadPackageSoap>, NuGetPackageUploader.nuget.UploadPackageSoap {
        
        public UploadPackageSoapClient() {
        }
        
        public UploadPackageSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UploadPackageSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UploadPackageSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UploadPackageSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NuGetPackageUploader.nuget.UploadResponse NuGetPackageUploader.nuget.UploadPackageSoap.Upload(NuGetPackageUploader.nuget.UploadRequest request) {
            return base.Channel.Upload(request);
        }
        
        public void Upload(byte[] data, string fileName) {
            NuGetPackageUploader.nuget.UploadRequest inValue = new NuGetPackageUploader.nuget.UploadRequest();
            inValue.Body = new NuGetPackageUploader.nuget.UploadRequestBody();
            inValue.Body.data = data;
            inValue.Body.fileName = fileName;
            NuGetPackageUploader.nuget.UploadResponse retVal = ((NuGetPackageUploader.nuget.UploadPackageSoap)(this)).Upload(inValue);
        }
    }
}