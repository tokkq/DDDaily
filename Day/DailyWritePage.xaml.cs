using DailyProject.Week;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DailyProject.Day
{
    /// <summary>
    /// DailyPage.xaml の相互作用ロジック
    /// </summary>
    public partial class DailyWritePage : Page
    {
        DailyWritePageViewModel _dailyDataViewModel = null;

        DateTime _date = default;
        string _dailyNoteInfoPath = "";

        public DailyWritePage()
        {
            InitializeComponent();
            _dailyDataViewModel = new DailyWritePageViewModel(null, new StandardCommand(saveTexts), new StandardCommand(() => Utility.WriteLine($"{_dailyDataViewModel.DailyNoteInfo.GoodPoint}")));
        }

        void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            initializeDataContext();
        }

        void OnLoadedDateLabel(object sender, RoutedEventArgs e)
        {
            if (sender is Label label)
            {
                label.Content = _date.ToString("yyyy年MM月dd日");
            }
        }

        void OnLoadedWeeklyTargetTextBlock(object sender, RoutedEventArgs e)
        {
            if (sender is TextBlock textBlock)
            {
                var firstDayOfWeek = _date.GetFirstDayOfWeek(DayOfWeek.Sunday);
                var weeklyPath = Path.Combine(PathDefinition.WeeklyJsonDirectoryPath, $@"Weekly_{firstDayOfWeek:yyyy_MM_dd}.json");
                var loadedInfo = JsonUtility.LoadJson<WeeklyNoteInfo>(weeklyPath, shouldCreateNewFileIfNoExistJson: true);

                var text = "";
                text += $"{loadedInfo.Target}";

                textBlock.Text = text;
            }
        }

        void OnLoadedMissionStatementTextBlock(object sender, RoutedEventArgs e)
        {
            if (sender is TextBlock textBlock)
            {
                var loadedInfo = JsonUtility.LoadJson<MissionStatementInfo>(PathDefinition.MissionStateJsonFilePath, shouldCreateNewFileIfNoExistJson: true);

                var text = "";
                text += "# 自分に対するミッション\n";
                foreach (var mission in loadedInfo.MissionsToMe)
                {
                    text += $"- {mission}\n";
                }

                text += "\n";
                text += "# 相手に対するミッション\n";
                foreach (var mission in loadedInfo.MissionsToOpponent)
                {
                    text += $"- {mission}\n";
                }

                text = text.TrimEnd('\n');

                textBlock.Text = text;
            }
        }

        public void SetDate(DateTime date)
        {
            _date = date;
            _dailyNoteInfoPath = Path.Combine(PathDefinition.DailyJsonDirectoryPath, $@"Daily_{_date:yyyy_MM_dd}.json");
        }

        void initializeDataContext()
        {
            var loadedInfo = JsonUtility.LoadJson<DailyNoteInfo>(_dailyNoteInfoPath, shouldCreateNewFileIfNoExistJson: true);
            _dailyDataViewModel.UpdateDailyNoteInfo(loadedInfo);

            DataContext = _dailyDataViewModel;
        }

        void saveTexts()
        {
            Utility.WriteLine($"[Save][Json]SaveTexts.");
            var dailyNoteInfo = _dailyDataViewModel.DailyNoteInfo;
            var result = JsonUtility.SaveJson(dailyNoteInfo, _dailyNoteInfoPath);
        }
    }
}
