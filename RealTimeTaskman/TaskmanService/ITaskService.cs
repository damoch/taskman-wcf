using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System;

[ServiceContract]
public interface ITaskService
{
    [OperationContract]
    void AddTask(string description);

    [OperationContract]
    List<TaskItem> GetTasks();
}

[DataContract]
public class TaskItem
{
    [DataMember] public int Id { get; set; }
    [DataMember] public string Description { get; set; }
    [DataMember] public DateTime CreatedAt { get; set; }
}