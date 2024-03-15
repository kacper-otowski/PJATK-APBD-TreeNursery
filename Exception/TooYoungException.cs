namespace CSharp_C3_Zagadnienia.Exception;

public class TooYoungException: System.Exception
{
    public TooYoungException()
    {
    }

    public TooYoungException(string message)
        : base(message)
    {
    }

    public TooYoungException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}