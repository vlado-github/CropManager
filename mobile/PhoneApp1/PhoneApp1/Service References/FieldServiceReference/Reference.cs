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
namespace PhoneApp1.FieldServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Field", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
    public partial class Field : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double AltitudeField;
        
        private double AreaSizeField;
        
        private string AreaSizeMeasureField;
        
        private int Crop_fkField;
        
        private int IdField;
        
        private int Map_fkField;
        
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Altitude {
            get {
                return this.AltitudeField;
            }
            set {
                if ((this.AltitudeField.Equals(value) != true)) {
                    this.AltitudeField = value;
                    this.RaisePropertyChanged("Altitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AreaSize {
            get {
                return this.AreaSizeField;
            }
            set {
                if ((this.AreaSizeField.Equals(value) != true)) {
                    this.AreaSizeField = value;
                    this.RaisePropertyChanged("AreaSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AreaSizeMeasure {
            get {
                return this.AreaSizeMeasureField;
            }
            set {
                if ((object.ReferenceEquals(this.AreaSizeMeasureField, value) != true)) {
                    this.AreaSizeMeasureField = value;
                    this.RaisePropertyChanged("AreaSizeMeasure");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Crop_fk {
            get {
                return this.Crop_fkField;
            }
            set {
                if ((this.Crop_fkField.Equals(value) != true)) {
                    this.Crop_fkField = value;
                    this.RaisePropertyChanged("Crop_fk");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Map_fk {
            get {
                return this.Map_fkField;
            }
            set {
                if ((this.Map_fkField.Equals(value) != true)) {
                    this.Map_fkField = value;
                    this.RaisePropertyChanged("Map_fk");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FieldServiceReference.IFieldService")]
    public interface IFieldService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IFieldService/InsertField", ReplyAction="http://tempuri.org/IFieldService/InsertFieldResponse")]
        System.IAsyncResult BeginInsertField(PhoneApp1.FieldServiceReference.Field field, System.AsyncCallback callback, object asyncState);
        
        int EndInsertField(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IFieldService/DeleteField", ReplyAction="http://tempuri.org/IFieldService/DeleteFieldResponse")]
        System.IAsyncResult BeginDeleteField(int field_id, System.AsyncCallback callback, object asyncState);
        
        void EndDeleteField(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IFieldService/SelectFieldById", ReplyAction="http://tempuri.org/IFieldService/SelectFieldByIdResponse")]
        System.IAsyncResult BeginSelectFieldById(int field_id, System.AsyncCallback callback, object asyncState);
        
        PhoneApp1.FieldServiceReference.Field EndSelectFieldById(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IFieldService/SelectFields", ReplyAction="http://tempuri.org/IFieldService/SelectFieldsResponse")]
        System.IAsyncResult BeginSelectFields(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<PhoneApp1.FieldServiceReference.Field> EndSelectFields(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFieldServiceChannel : PhoneApp1.FieldServiceReference.IFieldService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InsertFieldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public InsertFieldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public partial class SelectFieldByIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SelectFieldByIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public PhoneApp1.FieldServiceReference.Field Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((PhoneApp1.FieldServiceReference.Field)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SelectFieldsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SelectFieldsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<PhoneApp1.FieldServiceReference.Field> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<PhoneApp1.FieldServiceReference.Field>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FieldServiceClient : System.ServiceModel.ClientBase<PhoneApp1.FieldServiceReference.IFieldService>, PhoneApp1.FieldServiceReference.IFieldService {
        
        private BeginOperationDelegate onBeginInsertFieldDelegate;
        
        private EndOperationDelegate onEndInsertFieldDelegate;
        
        private System.Threading.SendOrPostCallback onInsertFieldCompletedDelegate;
        
        private BeginOperationDelegate onBeginDeleteFieldDelegate;
        
        private EndOperationDelegate onEndDeleteFieldDelegate;
        
        private System.Threading.SendOrPostCallback onDeleteFieldCompletedDelegate;
        
        private BeginOperationDelegate onBeginSelectFieldByIdDelegate;
        
        private EndOperationDelegate onEndSelectFieldByIdDelegate;
        
        private System.Threading.SendOrPostCallback onSelectFieldByIdCompletedDelegate;
        
        private BeginOperationDelegate onBeginSelectFieldsDelegate;
        
        private EndOperationDelegate onEndSelectFieldsDelegate;
        
        private System.Threading.SendOrPostCallback onSelectFieldsCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public FieldServiceClient() {
        }
        
        public FieldServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FieldServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FieldServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FieldServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
        
        public event System.EventHandler<InsertFieldCompletedEventArgs> InsertFieldCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DeleteFieldCompleted;
        
        public event System.EventHandler<SelectFieldByIdCompletedEventArgs> SelectFieldByIdCompleted;
        
        public event System.EventHandler<SelectFieldsCompletedEventArgs> SelectFieldsCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhoneApp1.FieldServiceReference.IFieldService.BeginInsertField(PhoneApp1.FieldServiceReference.Field field, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginInsertField(field, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int PhoneApp1.FieldServiceReference.IFieldService.EndInsertField(System.IAsyncResult result) {
            return base.Channel.EndInsertField(result);
        }
        
        private System.IAsyncResult OnBeginInsertField(object[] inValues, System.AsyncCallback callback, object asyncState) {
            PhoneApp1.FieldServiceReference.Field field = ((PhoneApp1.FieldServiceReference.Field)(inValues[0]));
            return ((PhoneApp1.FieldServiceReference.IFieldService)(this)).BeginInsertField(field, callback, asyncState);
        }
        
        private object[] OnEndInsertField(System.IAsyncResult result) {
            int retVal = ((PhoneApp1.FieldServiceReference.IFieldService)(this)).EndInsertField(result);
            return new object[] {
                    retVal};
        }
        
        private void OnInsertFieldCompleted(object state) {
            if ((this.InsertFieldCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.InsertFieldCompleted(this, new InsertFieldCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void InsertFieldAsync(PhoneApp1.FieldServiceReference.Field field) {
            this.InsertFieldAsync(field, null);
        }
        
        public void InsertFieldAsync(PhoneApp1.FieldServiceReference.Field field, object userState) {
            if ((this.onBeginInsertFieldDelegate == null)) {
                this.onBeginInsertFieldDelegate = new BeginOperationDelegate(this.OnBeginInsertField);
            }
            if ((this.onEndInsertFieldDelegate == null)) {
                this.onEndInsertFieldDelegate = new EndOperationDelegate(this.OnEndInsertField);
            }
            if ((this.onInsertFieldCompletedDelegate == null)) {
                this.onInsertFieldCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnInsertFieldCompleted);
            }
            base.InvokeAsync(this.onBeginInsertFieldDelegate, new object[] {
                        field}, this.onEndInsertFieldDelegate, this.onInsertFieldCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhoneApp1.FieldServiceReference.IFieldService.BeginDeleteField(int field_id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDeleteField(field_id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void PhoneApp1.FieldServiceReference.IFieldService.EndDeleteField(System.IAsyncResult result) {
            base.Channel.EndDeleteField(result);
        }
        
        private System.IAsyncResult OnBeginDeleteField(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int field_id = ((int)(inValues[0]));
            return ((PhoneApp1.FieldServiceReference.IFieldService)(this)).BeginDeleteField(field_id, callback, asyncState);
        }
        
        private object[] OnEndDeleteField(System.IAsyncResult result) {
            ((PhoneApp1.FieldServiceReference.IFieldService)(this)).EndDeleteField(result);
            return null;
        }
        
        private void OnDeleteFieldCompleted(object state) {
            if ((this.DeleteFieldCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DeleteFieldCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DeleteFieldAsync(int field_id) {
            this.DeleteFieldAsync(field_id, null);
        }
        
        public void DeleteFieldAsync(int field_id, object userState) {
            if ((this.onBeginDeleteFieldDelegate == null)) {
                this.onBeginDeleteFieldDelegate = new BeginOperationDelegate(this.OnBeginDeleteField);
            }
            if ((this.onEndDeleteFieldDelegate == null)) {
                this.onEndDeleteFieldDelegate = new EndOperationDelegate(this.OnEndDeleteField);
            }
            if ((this.onDeleteFieldCompletedDelegate == null)) {
                this.onDeleteFieldCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDeleteFieldCompleted);
            }
            base.InvokeAsync(this.onBeginDeleteFieldDelegate, new object[] {
                        field_id}, this.onEndDeleteFieldDelegate, this.onDeleteFieldCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhoneApp1.FieldServiceReference.IFieldService.BeginSelectFieldById(int field_id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSelectFieldById(field_id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PhoneApp1.FieldServiceReference.Field PhoneApp1.FieldServiceReference.IFieldService.EndSelectFieldById(System.IAsyncResult result) {
            return base.Channel.EndSelectFieldById(result);
        }
        
        private System.IAsyncResult OnBeginSelectFieldById(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int field_id = ((int)(inValues[0]));
            return ((PhoneApp1.FieldServiceReference.IFieldService)(this)).BeginSelectFieldById(field_id, callback, asyncState);
        }
        
        private object[] OnEndSelectFieldById(System.IAsyncResult result) {
            PhoneApp1.FieldServiceReference.Field retVal = ((PhoneApp1.FieldServiceReference.IFieldService)(this)).EndSelectFieldById(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSelectFieldByIdCompleted(object state) {
            if ((this.SelectFieldByIdCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SelectFieldByIdCompleted(this, new SelectFieldByIdCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SelectFieldByIdAsync(int field_id) {
            this.SelectFieldByIdAsync(field_id, null);
        }
        
        public void SelectFieldByIdAsync(int field_id, object userState) {
            if ((this.onBeginSelectFieldByIdDelegate == null)) {
                this.onBeginSelectFieldByIdDelegate = new BeginOperationDelegate(this.OnBeginSelectFieldById);
            }
            if ((this.onEndSelectFieldByIdDelegate == null)) {
                this.onEndSelectFieldByIdDelegate = new EndOperationDelegate(this.OnEndSelectFieldById);
            }
            if ((this.onSelectFieldByIdCompletedDelegate == null)) {
                this.onSelectFieldByIdCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSelectFieldByIdCompleted);
            }
            base.InvokeAsync(this.onBeginSelectFieldByIdDelegate, new object[] {
                        field_id}, this.onEndSelectFieldByIdDelegate, this.onSelectFieldByIdCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhoneApp1.FieldServiceReference.IFieldService.BeginSelectFields(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSelectFields(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<PhoneApp1.FieldServiceReference.Field> PhoneApp1.FieldServiceReference.IFieldService.EndSelectFields(System.IAsyncResult result) {
            return base.Channel.EndSelectFields(result);
        }
        
        private System.IAsyncResult OnBeginSelectFields(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((PhoneApp1.FieldServiceReference.IFieldService)(this)).BeginSelectFields(callback, asyncState);
        }
        
        private object[] OnEndSelectFields(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<PhoneApp1.FieldServiceReference.Field> retVal = ((PhoneApp1.FieldServiceReference.IFieldService)(this)).EndSelectFields(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSelectFieldsCompleted(object state) {
            if ((this.SelectFieldsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SelectFieldsCompleted(this, new SelectFieldsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SelectFieldsAsync() {
            this.SelectFieldsAsync(null);
        }
        
        public void SelectFieldsAsync(object userState) {
            if ((this.onBeginSelectFieldsDelegate == null)) {
                this.onBeginSelectFieldsDelegate = new BeginOperationDelegate(this.OnBeginSelectFields);
            }
            if ((this.onEndSelectFieldsDelegate == null)) {
                this.onEndSelectFieldsDelegate = new EndOperationDelegate(this.OnEndSelectFields);
            }
            if ((this.onSelectFieldsCompletedDelegate == null)) {
                this.onSelectFieldsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSelectFieldsCompleted);
            }
            base.InvokeAsync(this.onBeginSelectFieldsDelegate, null, this.onEndSelectFieldsDelegate, this.onSelectFieldsCompletedDelegate, userState);
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
        
        protected override PhoneApp1.FieldServiceReference.IFieldService CreateChannel() {
            return new FieldServiceClientChannel(this);
        }
        
        private class FieldServiceClientChannel : ChannelBase<PhoneApp1.FieldServiceReference.IFieldService>, PhoneApp1.FieldServiceReference.IFieldService {
            
            public FieldServiceClientChannel(System.ServiceModel.ClientBase<PhoneApp1.FieldServiceReference.IFieldService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginInsertField(PhoneApp1.FieldServiceReference.Field field, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = field;
                System.IAsyncResult _result = base.BeginInvoke("InsertField", _args, callback, asyncState);
                return _result;
            }
            
            public int EndInsertField(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("InsertField", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginDeleteField(int field_id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = field_id;
                System.IAsyncResult _result = base.BeginInvoke("DeleteField", _args, callback, asyncState);
                return _result;
            }
            
            public void EndDeleteField(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("DeleteField", _args, result);
            }
            
            public System.IAsyncResult BeginSelectFieldById(int field_id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = field_id;
                System.IAsyncResult _result = base.BeginInvoke("SelectFieldById", _args, callback, asyncState);
                return _result;
            }
            
            public PhoneApp1.FieldServiceReference.Field EndSelectFieldById(System.IAsyncResult result) {
                object[] _args = new object[0];
                PhoneApp1.FieldServiceReference.Field _result = ((PhoneApp1.FieldServiceReference.Field)(base.EndInvoke("SelectFieldById", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSelectFields(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("SelectFields", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<PhoneApp1.FieldServiceReference.Field> EndSelectFields(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<PhoneApp1.FieldServiceReference.Field> _result = ((System.Collections.ObjectModel.ObservableCollection<PhoneApp1.FieldServiceReference.Field>)(base.EndInvoke("SelectFields", _args, result)));
                return _result;
            }
        }
    }
}
