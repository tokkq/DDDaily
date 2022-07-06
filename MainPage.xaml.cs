using DailyProject.Day;
using DailyProject.MyDebug;
using DailyProject.Week;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DailyProject
{
    /// <summary>
    /// MainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MainPage : Page
    {
        DailyWritePage _dailyWritePage = new DailyWritePage();
        WeeklyWritePage _weeklyWritePage = new WeeklyWritePage();
        DebugPage _debugPage = new DebugPage();

        MainPageViewModel _mainPageViewModel = null;

        DateTime _selectedDate = default;

        public MainPage()
        {
            InitializeComponent();

            _mainPageViewModel = new MainPageViewModel(new StandardCommand(() => NavigationService.Navigate(_debugPage)));
        }

        void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            DataContext = _mainPageViewModel;
        }

        void OnClickGoToDailyWritePageButton(object sender, RoutedEventArgs e)
        {
            _dailyWritePage.SetDate(_selectedDate);
            var result = NavigationService.Navigate(_dailyWritePage);
        }

        void OnClickGoToWeeklyWritePage(object sender, RoutedEventArgs e)
        {
            _weeklyWritePage.SetDate(_selectedDate);
            var result = NavigationService.Navigate(_weeklyWritePage);
        }

        void OnLoadedDatePicker(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                setSelectedDateFromDatePicker(datePicker);
            }
        }

        void OnSelectedDatesChangedDatePicker(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                setSelectedDateFromDatePicker(datePicker);
            }
        }

        void OnPreviewMouseUpCalendar(object sender, MouseButtonEventArgs e)
        {
            if ((Mouse.Captured is Calendar) || (Mouse.Captured is CalendarItem))
            {
                var result = Mouse.Capture(null);
            }
        }

        void setSelectedDateFromDatePicker(DatePicker datePicker)
        {
            var isSelectedDate = datePicker.SelectedDate.HasValue;
            if (isSelectedDate == true)
            {
                var selectedDate = datePicker.SelectedDate.Value;
                _selectedDate = selectedDate;

                Utility.WriteLine($"Set selected date. [selectedDate]{selectedDate}");
            }
            else
            {
                var selectedDate = datePicker.DisplayDate.Date;
                _selectedDate = selectedDate;

                Utility.WriteLine($"Set selected date. [selectedDate]{selectedDate}");
            }
        }
    }
}
