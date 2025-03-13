using Microsoft.AspNet.SignalR;

namespace TaskmanService.Messaging
{
    public class TaskHub : Hub
    {
        public static void NotifyNewTask(string description)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<TaskHub>();
            context.Clients.All.taskAdded(description);
        }
    }
}