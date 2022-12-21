namespace MsBot.Implementation.Event;

public interface IMsBotEventHandler
{
    string Handle(string requestStr);
}
