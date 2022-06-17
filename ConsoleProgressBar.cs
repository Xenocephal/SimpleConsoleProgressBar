public class ConsoleProgressBar {        
    public string Description { get; set; }
    public int Total { get; set; } = 0;

    int status_length = 30; // length of progress line
    string status = ""; // progress line body
    private const string animation = @"-\|/-";

    public ConsoleProgressBar(string description = "Progress") { Description = description; }

    /// <summary>
    /// Print message with progress of current operation.
    /// </summary>
    /// <param name="step">current step of iteration</param>
    /// <param name="suffix">text in the end of message</param>
    public void ShowProgress(int step, string suffix="") {
        if (Total == 0) Total = step;
        double percents = (double)step / Total * 100;
        int progress_count = (int)(percents * status_length / 100);
        int points_count = status_length - progress_count;
        status = "[" + new string('■', progress_count) + new string('.', points_count) + "]";
        string current_message = $"\r{Description}: " +
            $"{percents:f1}% " +
            $"{status} " +
            $"{animation[step % animation.Length]} " +
            $"{step}/{Total} " +
            $"{suffix}";     
        Console.Write(current_message);
        last_message = current_message;
    }
}    
