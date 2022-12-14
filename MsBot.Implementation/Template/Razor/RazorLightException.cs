namespace MsBot.Implementation.Template.Razor;

public class RazorLightException : Exception
{
    public RazorLightException()
    {
    }

    public RazorLightException(string message) : base(message) { }

    public RazorLightException(string message, Exception exception) : base(message, exception) { }
}
