namespace DailyProject
{
    public class MainPageViewModel
    {
        public StandardCommand MoveDebugPageCommand { get; } = null;

        public MainPageViewModel(StandardCommand moveDebugPageCommand)
        {
            MoveDebugPageCommand = moveDebugPageCommand;
        }
    }
}
