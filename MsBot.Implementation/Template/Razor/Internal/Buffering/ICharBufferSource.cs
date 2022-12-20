namespace MsBot.Implementation.Template.Razor.Internal.Buffering;

public interface ICharBufferSource
{
    char[] Rent(int bufferSize);

    void Return(char[] buffer);
}
