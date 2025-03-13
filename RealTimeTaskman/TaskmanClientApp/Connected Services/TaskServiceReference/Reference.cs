﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskmanClientApp.TaskServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TaskItem", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class TaskItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreatedAtField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreatedAt {
            get {
                return this.CreatedAtField;
            }
            set {
                if ((this.CreatedAtField.Equals(value) != true)) {
                    this.CreatedAtField = value;
                    this.RaisePropertyChanged("CreatedAt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TaskServiceReference.ITaskService")]
    public interface ITaskService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskService/AddTask", ReplyAction="http://tempuri.org/ITaskService/AddTaskResponse")]
        void AddTask(string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskService/AddTask", ReplyAction="http://tempuri.org/ITaskService/AddTaskResponse")]
        System.Threading.Tasks.Task AddTaskAsync(string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskService/GetTasks", ReplyAction="http://tempuri.org/ITaskService/GetTasksResponse")]
        TaskmanClientApp.TaskServiceReference.TaskItem[] GetTasks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskService/GetTasks", ReplyAction="http://tempuri.org/ITaskService/GetTasksResponse")]
        System.Threading.Tasks.Task<TaskmanClientApp.TaskServiceReference.TaskItem[]> GetTasksAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITaskServiceChannel : TaskmanClientApp.TaskServiceReference.ITaskService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskServiceClient : System.ServiceModel.ClientBase<TaskmanClientApp.TaskServiceReference.ITaskService>, TaskmanClientApp.TaskServiceReference.ITaskService {
        
        public TaskServiceClient() {
        }
        
        public TaskServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TaskServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddTask(string description) {
            base.Channel.AddTask(description);
        }
        
        public System.Threading.Tasks.Task AddTaskAsync(string description) {
            return base.Channel.AddTaskAsync(description);
        }
        
        public TaskmanClientApp.TaskServiceReference.TaskItem[] GetTasks() {
            return base.Channel.GetTasks();
        }
        
        public System.Threading.Tasks.Task<TaskmanClientApp.TaskServiceReference.TaskItem[]> GetTasksAsync() {
            return base.Channel.GetTasksAsync();
        }
    }
}
