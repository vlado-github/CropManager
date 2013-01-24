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
namespace CropMngPhoneApp.MapServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Map", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
    public partial class Map : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int field_fkField;
        
        private double latitudeField;
        
        private double longitudeField;
        
        private int mapidField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int field_fk {
            get {
                return this.field_fkField;
            }
            set {
                if ((this.field_fkField.Equals(value) != true)) {
                    this.field_fkField = value;
                    this.RaisePropertyChanged("field_fk");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double latitude {
            get {
                return this.latitudeField;
            }
            set {
                if ((this.latitudeField.Equals(value) != true)) {
                    this.latitudeField = value;
                    this.RaisePropertyChanged("latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double longitude {
            get {
                return this.longitudeField;
            }
            set {
                if ((this.longitudeField.Equals(value) != true)) {
                    this.longitudeField = value;
                    this.RaisePropertyChanged("longitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int mapid {
            get {
                return this.mapidField;
            }
            set {
                if ((this.mapidField.Equals(value) != true)) {
                    this.mapidField = value;
                    this.RaisePropertyChanged("mapid");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MapServiceReference.IMapService")]
    public interface IMapService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMapService/InsertMap", ReplyAction="http://tempuri.org/IMapService/InsertMapResponse")]
        System.IAsyncResult BeginInsertMap(CropMngPhoneApp.MapServiceReference.Map map, System.AsyncCallback callback, object asyncState);
        
        int EndInsertMap(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMapService/DeleteMap", ReplyAction="http://tempuri.org/IMapService/DeleteMapResponse")]
        System.IAsyncResult BeginDeleteMap(int map_id, System.AsyncCallback callback, object asyncState);
        
        void EndDeleteMap(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMapService/SelectMapById", ReplyAction="http://tempuri.org/IMapService/SelectMapByIdResponse")]
        System.IAsyncResult BeginSelectMapById(int map_id, System.AsyncCallback callback, object asyncState);
        
        CropMngPhoneApp.MapServiceReference.Map EndSelectMapById(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMapService/SelectMaps", ReplyAction="http://tempuri.org/IMapService/SelectMapsResponse")]
        System.IAsyncResult BeginSelectMaps(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.MapServiceReference.Map> EndSelectMaps(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMapServiceChannel : CropMngPhoneApp.MapServiceReference.IMapService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InsertMapCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public InsertMapCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public partial class SelectMapByIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SelectMapByIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public CropMngPhoneApp.MapServiceReference.Map Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((CropMngPhoneApp.MapServiceReference.Map)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SelectMapsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SelectMapsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.MapServiceReference.Map> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.MapServiceReference.Map>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MapServiceClient : System.ServiceModel.ClientBase<CropMngPhoneApp.MapServiceReference.IMapService>, CropMngPhoneApp.MapServiceReference.IMapService {
        
        private BeginOperationDelegate onBeginInsertMapDelegate;
        
        private EndOperationDelegate onEndInsertMapDelegate;
        
        private System.Threading.SendOrPostCallback onInsertMapCompletedDelegate;
        
        private BeginOperationDelegate onBeginDeleteMapDelegate;
        
        private EndOperationDelegate onEndDeleteMapDelegate;
        
        private System.Threading.SendOrPostCallback onDeleteMapCompletedDelegate;
        
        private BeginOperationDelegate onBeginSelectMapByIdDelegate;
        
        private EndOperationDelegate onEndSelectMapByIdDelegate;
        
        private System.Threading.SendOrPostCallback onSelectMapByIdCompletedDelegate;
        
        private BeginOperationDelegate onBeginSelectMapsDelegate;
        
        private EndOperationDelegate onEndSelectMapsDelegate;
        
        private System.Threading.SendOrPostCallback onSelectMapsCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public MapServiceClient() {
        }
        
        public MapServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MapServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MapServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
        
        public event System.EventHandler<InsertMapCompletedEventArgs> InsertMapCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DeleteMapCompleted;
        
        public event System.EventHandler<SelectMapByIdCompletedEventArgs> SelectMapByIdCompleted;
        
        public event System.EventHandler<SelectMapsCompletedEventArgs> SelectMapsCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CropMngPhoneApp.MapServiceReference.IMapService.BeginInsertMap(CropMngPhoneApp.MapServiceReference.Map map, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginInsertMap(map, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int CropMngPhoneApp.MapServiceReference.IMapService.EndInsertMap(System.IAsyncResult result) {
            return base.Channel.EndInsertMap(result);
        }
        
        private System.IAsyncResult OnBeginInsertMap(object[] inValues, System.AsyncCallback callback, object asyncState) {
            CropMngPhoneApp.MapServiceReference.Map map = ((CropMngPhoneApp.MapServiceReference.Map)(inValues[0]));
            return ((CropMngPhoneApp.MapServiceReference.IMapService)(this)).BeginInsertMap(map, callback, asyncState);
        }
        
        private object[] OnEndInsertMap(System.IAsyncResult result) {
            int retVal = ((CropMngPhoneApp.MapServiceReference.IMapService)(this)).EndInsertMap(result);
            return new object[] {
                    retVal};
        }
        
        private void OnInsertMapCompleted(object state) {
            if ((this.InsertMapCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.InsertMapCompleted(this, new InsertMapCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void InsertMapAsync(CropMngPhoneApp.MapServiceReference.Map map) {
            this.InsertMapAsync(map, null);
        }
        
        public void InsertMapAsync(CropMngPhoneApp.MapServiceReference.Map map, object userState) {
            if ((this.onBeginInsertMapDelegate == null)) {
                this.onBeginInsertMapDelegate = new BeginOperationDelegate(this.OnBeginInsertMap);
            }
            if ((this.onEndInsertMapDelegate == null)) {
                this.onEndInsertMapDelegate = new EndOperationDelegate(this.OnEndInsertMap);
            }
            if ((this.onInsertMapCompletedDelegate == null)) {
                this.onInsertMapCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnInsertMapCompleted);
            }
            base.InvokeAsync(this.onBeginInsertMapDelegate, new object[] {
                        map}, this.onEndInsertMapDelegate, this.onInsertMapCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CropMngPhoneApp.MapServiceReference.IMapService.BeginDeleteMap(int map_id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDeleteMap(map_id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void CropMngPhoneApp.MapServiceReference.IMapService.EndDeleteMap(System.IAsyncResult result) {
            base.Channel.EndDeleteMap(result);
        }
        
        private System.IAsyncResult OnBeginDeleteMap(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int map_id = ((int)(inValues[0]));
            return ((CropMngPhoneApp.MapServiceReference.IMapService)(this)).BeginDeleteMap(map_id, callback, asyncState);
        }
        
        private object[] OnEndDeleteMap(System.IAsyncResult result) {
            ((CropMngPhoneApp.MapServiceReference.IMapService)(this)).EndDeleteMap(result);
            return null;
        }
        
        private void OnDeleteMapCompleted(object state) {
            if ((this.DeleteMapCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DeleteMapCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DeleteMapAsync(int map_id) {
            this.DeleteMapAsync(map_id, null);
        }
        
        public void DeleteMapAsync(int map_id, object userState) {
            if ((this.onBeginDeleteMapDelegate == null)) {
                this.onBeginDeleteMapDelegate = new BeginOperationDelegate(this.OnBeginDeleteMap);
            }
            if ((this.onEndDeleteMapDelegate == null)) {
                this.onEndDeleteMapDelegate = new EndOperationDelegate(this.OnEndDeleteMap);
            }
            if ((this.onDeleteMapCompletedDelegate == null)) {
                this.onDeleteMapCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDeleteMapCompleted);
            }
            base.InvokeAsync(this.onBeginDeleteMapDelegate, new object[] {
                        map_id}, this.onEndDeleteMapDelegate, this.onDeleteMapCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CropMngPhoneApp.MapServiceReference.IMapService.BeginSelectMapById(int map_id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSelectMapById(map_id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CropMngPhoneApp.MapServiceReference.Map CropMngPhoneApp.MapServiceReference.IMapService.EndSelectMapById(System.IAsyncResult result) {
            return base.Channel.EndSelectMapById(result);
        }
        
        private System.IAsyncResult OnBeginSelectMapById(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int map_id = ((int)(inValues[0]));
            return ((CropMngPhoneApp.MapServiceReference.IMapService)(this)).BeginSelectMapById(map_id, callback, asyncState);
        }
        
        private object[] OnEndSelectMapById(System.IAsyncResult result) {
            CropMngPhoneApp.MapServiceReference.Map retVal = ((CropMngPhoneApp.MapServiceReference.IMapService)(this)).EndSelectMapById(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSelectMapByIdCompleted(object state) {
            if ((this.SelectMapByIdCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SelectMapByIdCompleted(this, new SelectMapByIdCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SelectMapByIdAsync(int map_id) {
            this.SelectMapByIdAsync(map_id, null);
        }
        
        public void SelectMapByIdAsync(int map_id, object userState) {
            if ((this.onBeginSelectMapByIdDelegate == null)) {
                this.onBeginSelectMapByIdDelegate = new BeginOperationDelegate(this.OnBeginSelectMapById);
            }
            if ((this.onEndSelectMapByIdDelegate == null)) {
                this.onEndSelectMapByIdDelegate = new EndOperationDelegate(this.OnEndSelectMapById);
            }
            if ((this.onSelectMapByIdCompletedDelegate == null)) {
                this.onSelectMapByIdCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSelectMapByIdCompleted);
            }
            base.InvokeAsync(this.onBeginSelectMapByIdDelegate, new object[] {
                        map_id}, this.onEndSelectMapByIdDelegate, this.onSelectMapByIdCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CropMngPhoneApp.MapServiceReference.IMapService.BeginSelectMaps(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSelectMaps(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.MapServiceReference.Map> CropMngPhoneApp.MapServiceReference.IMapService.EndSelectMaps(System.IAsyncResult result) {
            return base.Channel.EndSelectMaps(result);
        }
        
        private System.IAsyncResult OnBeginSelectMaps(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((CropMngPhoneApp.MapServiceReference.IMapService)(this)).BeginSelectMaps(callback, asyncState);
        }
        
        private object[] OnEndSelectMaps(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.MapServiceReference.Map> retVal = ((CropMngPhoneApp.MapServiceReference.IMapService)(this)).EndSelectMaps(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSelectMapsCompleted(object state) {
            if ((this.SelectMapsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SelectMapsCompleted(this, new SelectMapsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SelectMapsAsync() {
            this.SelectMapsAsync(null);
        }
        
        public void SelectMapsAsync(object userState) {
            if ((this.onBeginSelectMapsDelegate == null)) {
                this.onBeginSelectMapsDelegate = new BeginOperationDelegate(this.OnBeginSelectMaps);
            }
            if ((this.onEndSelectMapsDelegate == null)) {
                this.onEndSelectMapsDelegate = new EndOperationDelegate(this.OnEndSelectMaps);
            }
            if ((this.onSelectMapsCompletedDelegate == null)) {
                this.onSelectMapsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSelectMapsCompleted);
            }
            base.InvokeAsync(this.onBeginSelectMapsDelegate, null, this.onEndSelectMapsDelegate, this.onSelectMapsCompletedDelegate, userState);
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
        
        protected override CropMngPhoneApp.MapServiceReference.IMapService CreateChannel() {
            return new MapServiceClientChannel(this);
        }
        
        private class MapServiceClientChannel : ChannelBase<CropMngPhoneApp.MapServiceReference.IMapService>, CropMngPhoneApp.MapServiceReference.IMapService {
            
            public MapServiceClientChannel(System.ServiceModel.ClientBase<CropMngPhoneApp.MapServiceReference.IMapService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginInsertMap(CropMngPhoneApp.MapServiceReference.Map map, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = map;
                System.IAsyncResult _result = base.BeginInvoke("InsertMap", _args, callback, asyncState);
                return _result;
            }
            
            public int EndInsertMap(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("InsertMap", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginDeleteMap(int map_id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = map_id;
                System.IAsyncResult _result = base.BeginInvoke("DeleteMap", _args, callback, asyncState);
                return _result;
            }
            
            public void EndDeleteMap(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("DeleteMap", _args, result);
            }
            
            public System.IAsyncResult BeginSelectMapById(int map_id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = map_id;
                System.IAsyncResult _result = base.BeginInvoke("SelectMapById", _args, callback, asyncState);
                return _result;
            }
            
            public CropMngPhoneApp.MapServiceReference.Map EndSelectMapById(System.IAsyncResult result) {
                object[] _args = new object[0];
                CropMngPhoneApp.MapServiceReference.Map _result = ((CropMngPhoneApp.MapServiceReference.Map)(base.EndInvoke("SelectMapById", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSelectMaps(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("SelectMaps", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.MapServiceReference.Map> EndSelectMaps(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.MapServiceReference.Map> _result = ((System.Collections.ObjectModel.ObservableCollection<CropMngPhoneApp.MapServiceReference.Map>)(base.EndInvoke("SelectMaps", _args, result)));
                return _result;
            }
        }
    }
}
