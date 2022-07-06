using System.Windows;
using System.Windows.Controls;

namespace DailyProject.MyDebug
{
    /// <summary>
    /// DebugPage.xaml の相互作用ロジック
    /// </summary>
    public partial class DebugPage : Page
    {
        public DebugPage()
        {
            InitializeComponent();
        }

        void OnClickDebugButton1(object sender, RoutedEventArgs e)
        {
            var msInfo = new MissionStatementInfo();
            for (int i = 0; i < 100; i++)
            {
                msInfo.MissionsToMe.Add("aaa");
                msInfo.MissionsToOpponent.Add("bbb");
            }
            JsonUtility.SaveJson(msInfo, $@"{PathDefinition.DebugDirectoryPath}\debugJson.json");
        }
        void OnClickDebugButton2(object sender, RoutedEventArgs e)
        {

        }
        void OnClickDebugButton3(object sender, RoutedEventArgs e)
        {

        }
    }
}
