namespace StarOJ.Models.Judging
{
    public class JudgingTask
    {
        public string Id { get; set; } = string.Empty;

        public CodeLanguage Language { get; set; }

        public string Code { get; set; } = string.Empty;

        public string? StandardInput { get; set; }

        public string? StandardOutput { get; set; }

        public string? StandardError { get; set; }
    }
}
