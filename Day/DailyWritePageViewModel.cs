namespace DailyProject.Day
{
    public class DailyWritePageViewModel
    {
        public DailyNoteInfo DailyNoteInfo { get; private set; } = default;

        public StandardCommand SaveCommand { get; } = null;
        public StandardCommand DebugCommand { get; } = null;

        public DailyWritePageViewModel(DailyNoteInfo dailyNoteInfo, StandardCommand saveCommand, StandardCommand debugCommand)
        {
            DailyNoteInfo = dailyNoteInfo;
            SaveCommand = saveCommand;
            DebugCommand = debugCommand;
        }

        public void UpdateDailyNoteInfo(DailyNoteInfo dailyNoteInfo)
        {
            DailyNoteInfo = dailyNoteInfo;
        }
    }
}
