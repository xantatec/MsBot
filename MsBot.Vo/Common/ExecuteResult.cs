namespace MsBot.Vo.Common;

public class ExecuteResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}

public class ExecuteResult<T>: ExecuteResult
{ 
    public T Result { get; set; }
}