namespace NP_03._TCP_Task_Manger_Listener;
public class Command
{
    public const string ProccessList = "PROCLIST";
    public const string Kill = "KILL";
    public const string Run = "RUN";
    public string? Text {  get; set; }
    public string? Param {  get; set; }

}
