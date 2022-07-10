namespace DailyProject.Day
{
    public class DailyNoteInfo
    {
        public string GoodPoint { get; set; } = "良かった点";
        public string ChangePoint { get; set; } = "変更点";
        public string Target { get; set; } = "目標";
        public string Schedule { get; set; } =
            @"0800~0830

0830~1000

1000~1230

1330~1600

1600~1630
            ";
        public string Nippo { get; set; } =
            @"### 本日の作業

### 翌営業日の作業

### その他
";

        public override string ToString()
        {
            return $"[GoodPoint]{GoodPoint}[ChangePoint]{ChangePoint}[Target]{Target}";
        }
    }
}
