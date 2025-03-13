using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskmanClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TaskServiceReference.TaskServiceClient service = new TaskServiceReference.TaskServiceClient();
        private readonly ObservableCollection<string> tasks = new ObservableCollection<string>();
        private HubConnection hubConnection;
        private IHubProxy hubProxy;

        public MainWindow()
        {
            InitializeComponent();
            TaskList.ItemsSource = tasks;
            LoadTasks();
            SetupSignalR();
        }

        private async void LoadTasks()
        {
            var taskItems = await service.GetTasksAsync();
            foreach (var task in taskItems)
            {
                tasks.Add(task.Description);
            }
        }

        private async void SetupSignalR()
        {
            hubConnection = new HubConnection("http://localhost:50390/");
            hubProxy = hubConnection.CreateHubProxy("TaskHub");
            hubProxy.On<string>("taskAdded", task => Dispatcher.Invoke(() => tasks.Add(task)));
            await hubConnection.Start();
        }

        private async void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TaskInput.Text))
            {
                await service.AddTaskAsync(TaskInput.Text);
                TaskInput.Clear();
            }
        }
    }
}
