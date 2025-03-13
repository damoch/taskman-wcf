using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System;
using System.Threading.Tasks;

[ServiceContract]
public interface ITaskService
{
    [OperationContract]
    Task AddTask(string description);

    [OperationContract]
    Task<List<TaskItem>> GetTasks();
}

[DataContract]
public class TaskItem
{
    [DataMember] public int Id { get; set; }
    [DataMember] public string Description { get; set; }
    [DataMember] public DateTime CreatedAt { get; set; }
}