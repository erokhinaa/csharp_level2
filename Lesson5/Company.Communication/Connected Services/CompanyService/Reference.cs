﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Company.Communication.CompanyService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int _IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string _FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string _LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string _SecondNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string _PositionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string _CommentField;
        
        private bool _WorksField;
        
        private Company.Communication.CompanyService.EmployeeCategory _CategoryField;
        
        private Company.Communication.CompanyService.Department _departmentField;
        
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SecondNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PositionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CommentField;
        
        private bool WorksField;
        
        private Company.Communication.CompanyService.EmployeeCategory CategoryField;
        
        private Company.Communication.CompanyService.Department departmentField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int _ID {
            get {
                return this._IDField;
            }
            set {
                if ((this._IDField.Equals(value) != true)) {
                    this._IDField = value;
                    this.RaisePropertyChanged("_ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string _FirstName {
            get {
                return this._FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this._FirstNameField, value) != true)) {
                    this._FirstNameField = value;
                    this.RaisePropertyChanged("_FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string _LastName {
            get {
                return this._LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this._LastNameField, value) != true)) {
                    this._LastNameField = value;
                    this.RaisePropertyChanged("_LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string _SecondName {
            get {
                return this._SecondNameField;
            }
            set {
                if ((object.ReferenceEquals(this._SecondNameField, value) != true)) {
                    this._SecondNameField = value;
                    this.RaisePropertyChanged("_SecondName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string _Position {
            get {
                return this._PositionField;
            }
            set {
                if ((object.ReferenceEquals(this._PositionField, value) != true)) {
                    this._PositionField = value;
                    this.RaisePropertyChanged("_Position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string _Comment {
            get {
                return this._CommentField;
            }
            set {
                if ((object.ReferenceEquals(this._CommentField, value) != true)) {
                    this._CommentField = value;
                    this.RaisePropertyChanged("_Comment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public bool _Works {
            get {
                return this._WorksField;
            }
            set {
                if ((this._WorksField.Equals(value) != true)) {
                    this._WorksField = value;
                    this.RaisePropertyChanged("_Works");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public Company.Communication.CompanyService.EmployeeCategory _Category {
            get {
                return this._CategoryField;
            }
            set {
                if ((this._CategoryField.Equals(value) != true)) {
                    this._CategoryField = value;
                    this.RaisePropertyChanged("_Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public Company.Communication.CompanyService.Department _department {
            get {
                return this._departmentField;
            }
            set {
                if ((this._departmentField.Equals(value) != true)) {
                    this._departmentField = value;
                    this.RaisePropertyChanged("_department");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string SecondName {
            get {
                return this.SecondNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SecondNameField, value) != true)) {
                    this.SecondNameField = value;
                    this.RaisePropertyChanged("SecondName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string Position {
            get {
                return this.PositionField;
            }
            set {
                if ((object.ReferenceEquals(this.PositionField, value) != true)) {
                    this.PositionField = value;
                    this.RaisePropertyChanged("Position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string Comment {
            get {
                return this.CommentField;
            }
            set {
                if ((object.ReferenceEquals(this.CommentField, value) != true)) {
                    this.CommentField = value;
                    this.RaisePropertyChanged("Comment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=15)]
        public bool Works {
            get {
                return this.WorksField;
            }
            set {
                if ((this.WorksField.Equals(value) != true)) {
                    this.WorksField = value;
                    this.RaisePropertyChanged("Works");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=16)]
        public Company.Communication.CompanyService.EmployeeCategory Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((this.CategoryField.Equals(value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=17)]
        public Company.Communication.CompanyService.Department department {
            get {
                return this.departmentField;
            }
            set {
                if ((this.departmentField.Equals(value) != true)) {
                    this.departmentField = value;
                    this.RaisePropertyChanged("department");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmployeeCategory", Namespace="http://tempuri.org/")]
    public enum EmployeeCategory : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FullTime = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Freelance = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Department", Namespace="http://tempuri.org/")]
    public enum Department : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IT = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Management = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        HR = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Business = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CompanyService.CompanyServiceSoap")]
    public interface CompanyServiceSoap {
        
        // CODEGEN: Generating message contract since element name employee from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Add", ReplyAction="*")]
        Company.Communication.CompanyService.AddResponse Add(Company.Communication.CompanyService.AddRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Add", ReplyAction="*")]
        System.Threading.Tasks.Task<Company.Communication.CompanyService.AddResponse> AddAsync(Company.Communication.CompanyService.AddRequest request);
        
        // CODEGEN: Generating message contract since element name LoadResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Load", ReplyAction="*")]
        Company.Communication.CompanyService.LoadResponse Load(Company.Communication.CompanyService.LoadRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Load", ReplyAction="*")]
        System.Threading.Tasks.Task<Company.Communication.CompanyService.LoadResponse> LoadAsync(Company.Communication.CompanyService.LoadRequest request);
        
        // CODEGEN: Generating message contract since element name employee from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        Company.Communication.CompanyService.UpdateResponse Update(Company.Communication.CompanyService.UpdateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        System.Threading.Tasks.Task<Company.Communication.CompanyService.UpdateResponse> UpdateAsync(Company.Communication.CompanyService.UpdateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteFromEmployees", ReplyAction="*")]
        void DeleteFromEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteFromEmployees", ReplyAction="*")]
        System.Threading.Tasks.Task DeleteFromEmployeesAsync();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Add", Namespace="http://tempuri.org/", Order=0)]
        public Company.Communication.CompanyService.AddRequestBody Body;
        
        public AddRequest() {
        }
        
        public AddRequest(Company.Communication.CompanyService.AddRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Company.Communication.CompanyService.Employee employee;
        
        public AddRequestBody() {
        }
        
        public AddRequestBody(Company.Communication.CompanyService.Employee employee) {
            this.employee = employee;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddResponse", Namespace="http://tempuri.org/", Order=0)]
        public Company.Communication.CompanyService.AddResponseBody Body;
        
        public AddResponse() {
        }
        
        public AddResponse(Company.Communication.CompanyService.AddResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int AddResult;
        
        public AddResponseBody() {
        }
        
        public AddResponseBody(int AddResult) {
            this.AddResult = AddResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Load", Namespace="http://tempuri.org/", Order=0)]
        public Company.Communication.CompanyService.LoadRequestBody Body;
        
        public LoadRequest() {
        }
        
        public LoadRequest(Company.Communication.CompanyService.LoadRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class LoadRequestBody {
        
        public LoadRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoadResponse", Namespace="http://tempuri.org/", Order=0)]
        public Company.Communication.CompanyService.LoadResponseBody Body;
        
        public LoadResponse() {
        }
        
        public LoadResponse(Company.Communication.CompanyService.LoadResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoadResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Company.Communication.CompanyService.Employee[] LoadResult;
        
        public LoadResponseBody() {
        }
        
        public LoadResponseBody(Company.Communication.CompanyService.Employee[] LoadResult) {
            this.LoadResult = LoadResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Update", Namespace="http://tempuri.org/", Order=0)]
        public Company.Communication.CompanyService.UpdateRequestBody Body;
        
        public UpdateRequest() {
        }
        
        public UpdateRequest(Company.Communication.CompanyService.UpdateRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Company.Communication.CompanyService.Employee employee;
        
        public UpdateRequestBody() {
        }
        
        public UpdateRequestBody(Company.Communication.CompanyService.Employee employee) {
            this.employee = employee;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateResponse", Namespace="http://tempuri.org/", Order=0)]
        public Company.Communication.CompanyService.UpdateResponseBody Body;
        
        public UpdateResponse() {
        }
        
        public UpdateResponse(Company.Communication.CompanyService.UpdateResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int UpdateResult;
        
        public UpdateResponseBody() {
        }
        
        public UpdateResponseBody(int UpdateResult) {
            this.UpdateResult = UpdateResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CompanyServiceSoapChannel : Company.Communication.CompanyService.CompanyServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CompanyServiceSoapClient : System.ServiceModel.ClientBase<Company.Communication.CompanyService.CompanyServiceSoap>, Company.Communication.CompanyService.CompanyServiceSoap {
        
        public CompanyServiceSoapClient() {
        }
        
        public CompanyServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CompanyServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompanyServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompanyServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Company.Communication.CompanyService.AddResponse Company.Communication.CompanyService.CompanyServiceSoap.Add(Company.Communication.CompanyService.AddRequest request) {
            return base.Channel.Add(request);
        }
        
        public int Add(Company.Communication.CompanyService.Employee employee) {
            Company.Communication.CompanyService.AddRequest inValue = new Company.Communication.CompanyService.AddRequest();
            inValue.Body = new Company.Communication.CompanyService.AddRequestBody();
            inValue.Body.employee = employee;
            Company.Communication.CompanyService.AddResponse retVal = ((Company.Communication.CompanyService.CompanyServiceSoap)(this)).Add(inValue);
            return retVal.Body.AddResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Company.Communication.CompanyService.AddResponse> Company.Communication.CompanyService.CompanyServiceSoap.AddAsync(Company.Communication.CompanyService.AddRequest request) {
            return base.Channel.AddAsync(request);
        }
        
        public System.Threading.Tasks.Task<Company.Communication.CompanyService.AddResponse> AddAsync(Company.Communication.CompanyService.Employee employee) {
            Company.Communication.CompanyService.AddRequest inValue = new Company.Communication.CompanyService.AddRequest();
            inValue.Body = new Company.Communication.CompanyService.AddRequestBody();
            inValue.Body.employee = employee;
            return ((Company.Communication.CompanyService.CompanyServiceSoap)(this)).AddAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Company.Communication.CompanyService.LoadResponse Company.Communication.CompanyService.CompanyServiceSoap.Load(Company.Communication.CompanyService.LoadRequest request) {
            return base.Channel.Load(request);
        }
        
        public Company.Communication.CompanyService.Employee[] Load() {
            Company.Communication.CompanyService.LoadRequest inValue = new Company.Communication.CompanyService.LoadRequest();
            inValue.Body = new Company.Communication.CompanyService.LoadRequestBody();
            Company.Communication.CompanyService.LoadResponse retVal = ((Company.Communication.CompanyService.CompanyServiceSoap)(this)).Load(inValue);
            return retVal.Body.LoadResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Company.Communication.CompanyService.LoadResponse> Company.Communication.CompanyService.CompanyServiceSoap.LoadAsync(Company.Communication.CompanyService.LoadRequest request) {
            return base.Channel.LoadAsync(request);
        }
        
        public System.Threading.Tasks.Task<Company.Communication.CompanyService.LoadResponse> LoadAsync() {
            Company.Communication.CompanyService.LoadRequest inValue = new Company.Communication.CompanyService.LoadRequest();
            inValue.Body = new Company.Communication.CompanyService.LoadRequestBody();
            return ((Company.Communication.CompanyService.CompanyServiceSoap)(this)).LoadAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Company.Communication.CompanyService.UpdateResponse Company.Communication.CompanyService.CompanyServiceSoap.Update(Company.Communication.CompanyService.UpdateRequest request) {
            return base.Channel.Update(request);
        }
        
        public int Update(Company.Communication.CompanyService.Employee employee) {
            Company.Communication.CompanyService.UpdateRequest inValue = new Company.Communication.CompanyService.UpdateRequest();
            inValue.Body = new Company.Communication.CompanyService.UpdateRequestBody();
            inValue.Body.employee = employee;
            Company.Communication.CompanyService.UpdateResponse retVal = ((Company.Communication.CompanyService.CompanyServiceSoap)(this)).Update(inValue);
            return retVal.Body.UpdateResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Company.Communication.CompanyService.UpdateResponse> Company.Communication.CompanyService.CompanyServiceSoap.UpdateAsync(Company.Communication.CompanyService.UpdateRequest request) {
            return base.Channel.UpdateAsync(request);
        }
        
        public System.Threading.Tasks.Task<Company.Communication.CompanyService.UpdateResponse> UpdateAsync(Company.Communication.CompanyService.Employee employee) {
            Company.Communication.CompanyService.UpdateRequest inValue = new Company.Communication.CompanyService.UpdateRequest();
            inValue.Body = new Company.Communication.CompanyService.UpdateRequestBody();
            inValue.Body.employee = employee;
            return ((Company.Communication.CompanyService.CompanyServiceSoap)(this)).UpdateAsync(inValue);
        }
        
        public void DeleteFromEmployees() {
            base.Channel.DeleteFromEmployees();
        }
        
        public System.Threading.Tasks.Task DeleteFromEmployeesAsync() {
            return base.Channel.DeleteFromEmployeesAsync();
        }
    }
}