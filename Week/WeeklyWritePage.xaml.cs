using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DailyProject.Week
{
    /// <summary>
    /// WeeklyWritePage.xaml の相互作用ロジック
    /// </summary>
    public partial class WeeklyWritePage : Page
    {
        WeeklyWritePageViewModel _weeklyWritePageViewModel = null;

        DateTime _date = default;
        string _weeklyNoteInfoPath = "";

        public WeeklyWritePage()
        {
            InitializeComponent();

            _weeklyWritePageViewModel = new WeeklyWritePageViewModel(null, new StandardCommand(saveTexts));
        }

        void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            initializeDataContext();
        }

        void OnLoadedLabel(object sender, RoutedEventArgs e)
        {
            if (sender is Label label)
            {
                var firstDayOfWeek = _date.GetFirstDayOfWeek(DayOfWeek.Sunday);
                var endDayOfWeek = _date.GetLastDayOfWeek(DayOfWeek.Sunday);
                label.Content = $"{firstDayOfWeek:yyyy年MM月dd日}～{endDayOfWeek:yyyy年MM月dd日}";
            }
        }

        public void SetDate(DateTime date)
        {
            _date = date;

            var firstDayOfWeek = _date.GetFirstDayOfWeek(DayOfWeek.Sunday);
            _weeklyNoteInfoPath = Path.Combine(PathDefinition.WeeklyJsonDirectoryPath, $@"Weekly_{firstDayOfWeek:yyyy_MM_dd}.json");
        }

        void initializeDataContext()
        {
            var loadedInfo = JsonUtility.LoadJson<WeeklyNoteInfo>(_weeklyNoteInfoPath, shouldCreateNewFileIfNoExistJson: true);
            _weeklyWritePageViewModel.UpdateWeeklyNoteInfo(loadedInfo);

            DataContext = _weeklyWritePageViewModel;
        }

        void saveTexts()
        {
            var dailyNoteInfo = _weeklyWritePageViewModel.WeeklyNoteInfo;
            var result = JsonUtility.SaveJson(dailyNoteInfo, _weeklyNoteInfoPath);
        }


    }

    class WeeklyWritePageViewModel
    {
        public WeeklyNoteInfo WeeklyNoteInfo { get; private set; } = new WeeklyNoteInfo();

        public StandardCommand SaveCommand { get; } = null;

        public WeeklyWritePageViewModel(WeeklyNoteInfo weeklyNoteInfo, StandardCommand saveCommand)
        {
            WeeklyNoteInfo = weeklyNoteInfo;
            SaveCommand = saveCommand;
        }

        public void UpdateWeeklyNoteInfo(WeeklyNoteInfo weeklyNoteInfo)
        {
            WeeklyNoteInfo = weeklyNoteInfo;
        }
    }
}
