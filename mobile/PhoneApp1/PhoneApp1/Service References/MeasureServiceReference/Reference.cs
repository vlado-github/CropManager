﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace PhoneApp1.MeasureServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Measure", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
    public partial class Measure : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int measureidField;
        
        private string typeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int measureid {
            get {
                return this.measureidField;
            }
            set {
                if ((this.measureidField.Equals(value) != true)) {
                    this.measureidField = value;
                    this.RaisePropertyChanged("measureid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                if ((object.ReferenceEquals(this.typeField, value) != true)) {
                    this.typeField = value;
                    this.RaisePropertyChanged("type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MeasureServiceReference.IFieldMeasureService")]
    public interface IFieldMeasureService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IFieldMeasureService/GetAllMeasures", ReplyAction="http://tempuri.org/IFieldMeasureService/GetAllMeasuresResponse")]
        System.IAsyncResult BeginGetAllMeasures(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<PhoneApp1.MeasureServiceReference.Measure> EndGetAllMeasures(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFieldMeasureServiceChannel : PhoneApp1.MeasureServiceReference.IFieldMeasureService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetAllMeasuresCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetAllMeasuresCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<PhoneApp1.MeasureServiceReference.Measure> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<PhoneApp1.MeasureServiceReference.Measure>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FieldMeasureServiceClient : System.ServiceModel.ClientBase<PhoneApp1.MeasureServiceReference.IFieldMeasureService>, PhoneApp1.MeasureServiceReference.IFieldMeasureService {
        
        private BeginOperationDelegate onBeginGetAllMeasuresDelegate;
        
        private EndOperationDelegate onEndGetAllMeasuresDelegate;
        
        private System.Threading.SendOrPostCallback onGetAllMeasuresCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public FieldMeasureServiceClient() {
        }
        
        public FieldMeasureServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FieldMeasureServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FieldMeasureServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FieldMeasureServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetAllMeasuresCompletedEventArgs> GetAllMeasuresCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhoneApp1.MeasureServiceReference.IFieldMeasureService.BeginGetAllMeasures(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetAllMeasures(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<PhoneApp1.MeasureServiceReference.Measure> PhoneApp1.MeasureServiceReference.IFieldMeasureService.EndGetAllMeasures(System.IAsyncResult result) {
            return base.Channel.EndGetAllMeasures(result);
        }
        
        private System.IAsyncResult OnBeginGetAllMeasures(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((PhoneApp1.MeasureServiceReference.IFieldMeasureService)(this)).BeginGetAllMeasures(callback, asyncState);
        }
        
        private object[] OnEndGetAllMeasures(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<PhoneApp1.MeasureServiceReference.Measure> retVal = ((PhoneApp1.MeasureServiceReference.IFieldMeasureService)(this)).EndGetAllMeasures(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetAllMeasuresCompleted(object state) {
            if ((this.GetAllMeasuresCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetAllMeasuresCompleted(this, new GetAllMeasuresCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetAllMeasuresAsync() {
            this.GetAllMeasuresAsync(null);
        }
        
        public void GetAllMeasuresAsync(object userState) {
            if ((this.onBeginGetAllMeasuresDelegate == null)) {
                this.onBeginGetAllMeasuresDelegate = new BeginOperationDelegate(this.OnBeginGetAllMeasures);
            }
            if ((this.onEndGetAllMeasuresDelegate == null)) {
                this.onEndGetAllMeasuresDelegate = new EndOperationDelegate(this.OnEndGetAllMeasures);
            }
            if ((this.onGetAllMeasuresCompletedDelegate == null)) {
                this.onGetAllMeasuresCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetAllMeasuresCompleted);
            }
            base.InvokeAsync(this.onBeginGetAllMeasuresDelegate, null, this.onEndGetAllMeasuresDelegate, this.onGetAllMeasuresCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override PhoneApp1.MeasureServiceReference.IFieldMeasureService CreateChannel() {
            return new FieldMeasureServiceClientChannel(this);
        }
        
        private class FieldMeasureServiceClientChannel : ChannelBase<PhoneApp1.MeasureServiceReference.IFieldMeasureService>, PhoneApp1.MeasureServiceReference.IFieldMeasureService {
            
            public FieldMeasureServiceClientChannel(System.ServiceModel.ClientBase<PhoneApp1.MeasureServiceReference.IFieldMeasureService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetAllMeasures(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("GetAllMeasures", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<PhoneApp1.MeasureServiceReference.Measure> EndGetAllMeasures(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<PhoneApp1.MeasureServiceReference.Measure> _result = ((System.Collections.ObjectModel.ObservableCollection<PhoneApp1.MeasureServiceReference.Measure>)(base.EndInvoke("GetAllMeasures", _args, result)));
                return _result;
            }
        }
    }
}
