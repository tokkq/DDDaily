using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace DailyProject.Schedule
{
    /// <summary>
    /// ScheduleWritePage.xaml の相互作用ロジック
    /// </summary>
    public partial class ScheduleWritePage : Page
    {
        public ScheduleWritePageViewModel ScheduleWritePageViewModel { get; }

        public ScheduleWritePage()
        {
            InitializeComponent();

            var info = new ScheduleInfo();
            var saveCommnad = new StandardCommand(saveTexts);
            var addCommand = new StandardCommand(addTask);
            var deleteCommand = new StandardCommand(deleteTask);

            ScheduleWritePageViewModel = new ScheduleWritePageViewModel(info, saveCommnad, addCommand, deleteCommand);
            DataContext = ScheduleWritePageViewModel;
        }
        void saveTexts()
        {
            var path = Path.Combine(PathDefinition.DailyJsonDirectoryPath, $@"Daily_Schedule_.json");
            var result = JsonUtility.SaveJson(ScheduleWritePageViewModel.ScheduleInfo, path);
        }
        void addTask()
        {
            ScheduleWritePageViewModel.ScheduleInfo.Schedules.Add(new Schedule());
        }
        void deleteTask()
        {
            var deleteTasks = ScheduleWritePageViewModel.ScheduleInfo.Schedules.Where(s => s.ShouldDelete).ToArray();
            foreach (var item in deleteTasks)
            {
                ScheduleWritePageViewModel.ScheduleInfo.Schedules.Remove(item);
            }
        }
    }

    public class ScheduleWritePageViewModel
    {
        public ScheduleInfo ScheduleInfo { get; set; } = null;

        public StandardCommand SaveCommand { get; } = null;
        public StandardCommand AddTaskCommand { get; } = null;
        public StandardCommand DeleteTaskCommand { get; } = null;

        public ScheduleWritePageViewModel(ScheduleInfo scheduleInfo, StandardCommand saveCommand, StandardCommand addTaskCommand, StandardCommand deleteTaskCommand)
        {
            ScheduleInfo = scheduleInfo;
            SaveCommand = saveCommand;
            AddTaskCommand = addTaskCommand;
            DeleteTaskCommand = deleteTaskCommand;
        }
    }

    public class ScheduleInfo
    {
        public ObservableCollection<Schedule> Schedules { get; set; } = new ObservableCollection<Schedule>();
    }

    public class Schedule
    {
        public string StartTime { get; set; } = "StartTime";
        public string EndTime { get; set; } = "EndTime";
        public string Task { get; set; } = "Task";
        public bool ShouldDelete { get; set; } = false;
    }
}
