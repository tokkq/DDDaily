using System;
using System.IO;

namespace DailyProject
{
    static class PathDefinition
    {
        public static string RootPath = AppDomain.CurrentDomain.BaseDirectory;

        public static string DailyJsonDirectoryPath = Path.Combine(RootPath, @"Data\Day");
        public static string WeeklyJsonDirectoryPath = Path.Combine(RootPath, @"Data\Week");

        public static string MissionStateJsonFilePath = Path.Combine(RootPath, @"Data\MissionStatement.json");

        public static string DebugDirectoryPath = Path.Combine(RootPath, @"Data\Debug");

    }

}
