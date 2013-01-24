﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace CropMngPhoneApp.IllnessServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Illness", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
    public partial class Illness : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int cropidField;
        
        private System.DateTime datefromField;
        
        private System.DateTime datetoField;
        
        private string diagnoseField;
        
        private int illnessidField;
        
        private byte[] illnessimageField;
        
        private int journalidField;
        
        private string nameField;
        
        private double percentageinfectedField;
        
        private string typeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int cropid {
            get {
                return this.cropidField;
            }
            set {
                if ((this.cropidField.Equals(value) != true)) {
                    this.cropidField = value;
                    this.RaisePropertyChanged("cropid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime datefrom {
            get {
                return this.datefromField;
            }
            set {
                if ((this.datefromField.Equals(value) != true)) {
                    this.datefromField = value;
                    this.RaisePropertyChanged("datefrom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime dateto {
            get {
                return this.datetoField;
            }
            set {
                if ((this.datetoField.Equals(value) != true)) {
                    this.datetoField = value;
                    this.RaisePropertyChanged("dateto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string diagnose {
            get {
                return this.diagnoseField;
            }
            set {
                if ((object.ReferenceEquals(this.diagnoseField, value) != true)) {
                    this.diagnoseField = value;
                    this.RaisePropertyChanged("diagnose");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int illnessid {
            get {
                return this.illnessidField;
            }
            set {
                if ((this.illnessidField.Equals(value) != true)) {
                    this.illnessidField = value;
                    this.RaisePropertyChanged("illnessid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] illnessimage {
            get {
                return this.illnessimageField;
            }
            set {
                if ((object.ReferenceEquals(this.illnessimageField, value) != true)) {
                    this.illnessimageField = value;
                    this.RaisePropertyChanged("illnessimage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int journalid {
            get {
                return this.journalidField;
            }
            set {
                if ((this.journalidField.Equals(value) != true)) {
                    this.journalidField = value;
                    this.RaisePropertyChanged("journalid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double percentageinfected {
            get {
                return this.percentageinfectedField;
            }
            set {
                if ((this.percentageinfectedField.Equals(value) != true)) {
                    this.percentageinfectedField = value;
                    this.RaisePropertyChanged("percentageinfected");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="IllnessServiceReference.IIllnessService")]
    public interface IIllnessService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IIllnessService/InsertIllness", ReplyAction="http://tempuri.org/IIllnessService/InsertIllnessResponse")]
        System.IAsyncResult BeginInsertIllness(CropMngPhoneApp.IllnessServiceReference.Illness illness, System.AsyncCallback callback, object asyncState);
        
        int EndInsertIllness(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IIllnessService/SelectIllnessesByCropId", ReplyAction="http://tempuri.org/IIllnessService/SelectIllnessesByCropIdResponse")]
        System.IAsyncResult BeginSelectIllnessesByCropId(int crop_id, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.IllnessServiceReference.Illness> EndSelectIllnessesByCropId(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IIllnessServiceChannel : CropMngPhoneApp.IllnessServiceReference.IIllnessService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InsertIllnessCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public InsertIllnessCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SelectIllnessesByCropIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SelectIllnessesByCropIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.IllnessServiceReference.Illness> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.IllnessServiceReference.Illness>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IllnessServiceClient : System.ServiceModel.ClientBase<CropMngPhoneApp.IllnessServiceReference.IIllnessService>, CropMngPhoneApp.IllnessServiceReference.IIllnessService {
        
        private BeginOperationDelegate onBeginInsertIllnessDelegate;
        
        private EndOperationDelegate onEndInsertIllnessDelegate;
        
        private System.Threading.SendOrPostCallback onInsertIllnessCompletedDelegate;
        
        private BeginOperationDelegate onBeginSelectIllnessesByCropIdDelegate;
        
        private EndOperationDelegate onEndSelectIllnessesByCropIdDelegate;
        
        private System.Threading.SendOrPostCallback onSelectIllnessesByCropIdCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public IllnessServiceClient() {
        }
        
        public IllnessServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IllnessServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IllnessServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IllnessServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
        
        public event System.EventHandler<InsertIllnessCompletedEventArgs> InsertIllnessCompleted;
        
        public event System.EventHandler<SelectIllnessesByCropIdCompletedEventArgs> SelectIllnessesByCropIdCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CropMngPhoneApp.IllnessServiceReference.IIllnessService.BeginInsertIllness(CropMngPhoneApp.IllnessServiceReference.Illness illness, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginInsertIllness(illness, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int CropMngPhoneApp.IllnessServiceReference.IIllnessService.EndInsertIllness(System.IAsyncResult result) {
            return base.Channel.EndInsertIllness(result);
        }
        
        private System.IAsyncResult OnBeginInsertIllness(object[] inValues, System.AsyncCallback callback, object asyncState) {
            CropMngPhoneApp.IllnessServiceReference.Illness illness = ((CropMngPhoneApp.IllnessServiceReference.Illness)(inValues[0]));
            return ((CropMngPhoneApp.IllnessServiceReference.IIllnessService)(this)).BeginInsertIllness(illness, callback, asyncState);
        }
        
        private object[] OnEndInsertIllness(System.IAsyncResult result) {
            int retVal = ((CropMngPhoneApp.IllnessServiceReference.IIllnessService)(this)).EndInsertIllness(result);
            return new object[] {
                    retVal};
        }
        
        private void OnInsertIllnessCompleted(object state) {
            if ((this.InsertIllnessCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.InsertIllnessCompleted(this, new InsertIllnessCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void InsertIllnessAsync(CropMngPhoneApp.IllnessServiceReference.Illness illness) {
            this.InsertIllnessAsync(illness, null);
        }
        
        public void InsertIllnessAsync(CropMngPhoneApp.IllnessServiceReference.Illness illness, object userState) {
            if ((this.onBeginInsertIllnessDelegate == null)) {
                this.onBeginInsertIllnessDelegate = new BeginOperationDelegate(this.OnBeginInsertIllness);
            }
            if ((this.onEndInsertIllnessDelegate == null)) {
                this.onEndInsertIllnessDelegate = new EndOperationDelegate(this.OnEndInsertIllness);
            }
            if ((this.onInsertIllnessCompletedDelegate == null)) {
                this.onInsertIllnessCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnInsertIllnessCompleted);
            }
            base.InvokeAsync(this.onBeginInsertIllnessDelegate, new object[] {
                        illness}, this.onEndInsertIllnessDelegate, this.onInsertIllnessCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CropMngPhoneApp.IllnessServiceReference.IIllnessService.BeginSelectIllnessesByCropId(int crop_id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSelectIllnessesByCropId(crop_id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.IllnessServiceReference.Illness> CropMngPhoneApp.IllnessServiceReference.IIllnessService.EndSelectIllnessesByCropId(System.IAsyncResult result) {
            return base.Channel.EndSelectIllnessesByCropId(result);
        }
        
        private System.IAsyncResult OnBeginSelectIllnessesByCropId(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int crop_id = ((int)(inValues[0]));
            return ((CropMngPhoneApp.IllnessServiceReference.IIllnessService)(this)).BeginSelectIllnessesByCropId(crop_id, callback, asyncState);
        }
        
        private object[] OnEndSelectIllnessesByCropId(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.IllnessServiceReference.Illness> retVal = ((CropMngPhoneApp.IllnessServiceReference.IIllnessService)(this)).EndSelectIllnessesByCropId(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSelectIllnessesByCropIdCompleted(object state) {
            if ((this.SelectIllnessesByCropIdCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SelectIllnessesByCropIdCompleted(this, new SelectIllnessesByCropIdCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SelectIllnessesByCropIdAsync(int crop_id) {
            this.SelectIllnessesByCropIdAsync(crop_id, null);
        }
        
        public void SelectIllnessesByCropIdAsync(int crop_id, object userState) {
            if ((this.onBeginSelectIllnessesByCropIdDelegate == null)) {
                this.onBeginSelectIllnessesByCropIdDelegate = new BeginOperationDelegate(this.OnBeginSelectIllnessesByCropId);
            }
            if ((this.onEndSelectIllnessesByCropIdDelegate == null)) {
                this.onEndSelectIllnessesByCropIdDelegate = new EndOperationDelegate(this.OnEndSelectIllnessesByCropId);
            }
            if ((this.onSelectIllnessesByCropIdCompletedDelegate == null)) {
                this.onSelectIllnessesByCropIdCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSelectIllnessesByCropIdCompleted);
            }
            base.InvokeAsync(this.onBeginSelectIllnessesByCropIdDelegate, new object[] {
                        crop_id}, this.onEndSelectIllnessesByCropIdDelegate, this.onSelectIllnessesByCropIdCompletedDelegate, userState);
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
        
        protected override CropMngPhoneApp.IllnessServiceReference.IIllnessService CreateChannel() {
            return new IllnessServiceClientChannel(this);
        }
        
        private class IllnessServiceClientChannel : ChannelBase<CropMngPhoneApp.IllnessServiceReference.IIllnessService>, CropMngPhoneApp.IllnessServiceReference.IIllnessService {
            
            public IllnessServiceClientChannel(System.ServiceModel.ClientBase<CropMngPhoneApp.IllnessServiceReference.IIllnessService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginInsertIllness(CropMngPhoneApp.IllnessServiceReference.Illness illness, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = illness;
                System.IAsyncResult _result = base.BeginInvoke("InsertIllness", _args, callback, asyncState);
                return _result;
            }
            
            public int EndInsertIllness(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("InsertIllness", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSelectIllnessesByCropId(int crop_id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = crop_id;
                System.IAsyncResult _result = base.BeginInvoke("SelectIllnessesByCropId", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.IllnessServiceReference.Illness> EndSelectIllnessesByCropId(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.IllnessServiceReference.Illness> _result = ((System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.IllnessServiceReference.Illness>)(base.EndInvoke("SelectIllnessesByCropId", _args, result)));
                return _result;
            }
        }
    }
}
