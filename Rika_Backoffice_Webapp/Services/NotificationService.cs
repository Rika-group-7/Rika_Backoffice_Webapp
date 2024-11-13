namespace Rika_Backoffice_Webapp.Services;

public class NotificationService
{
    public string? Message { get; set; }

    public string? AlertType { get; set; }
    public int? Timer {  get; set; }

    public bool IsActive { get; set; } = false;

    public void Call(string Message, string Type)
    {
        this.IsActive = true;
        this.Message = Message ?? string.Empty;
        this.AlertType = Type ?? string.Empty;
    }

    public void Call(string Message, string Type, int Timer)
    {
        this.IsActive = true;
        this.Message = Message ?? string.Empty;
        this.AlertType = Type ?? string.Empty;
        this.Timer = Timer;
    }

    public void Reset()
    {
        this.IsActive = false;
        Message = null;
        AlertType = null;
        Timer = null;
    }
}