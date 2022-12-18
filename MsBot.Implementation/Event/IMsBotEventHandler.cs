namespace MsBot.Implementation.Event;

public interface IMsBotEventHandler
{
    void Handle(string requestStr);
}
