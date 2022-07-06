namespace DailyProject.Day
{
    public class DailyNoteInfo
    {
        public string GoodPoint { get; set; } = "良かった点";
        public string ChangePoint { get; set; } = "変更点";
        public string Target { get; set; } = "目標";

        public override string ToString()
        {
            return $"[GoodPoint]{GoodPoint}[ChangePoint]{ChangePoint}[Target]{Target}";
        }
    }
}
