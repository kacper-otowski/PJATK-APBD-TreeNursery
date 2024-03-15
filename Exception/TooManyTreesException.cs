namespace CSharp_C3_Zagadnienia.Exception;

public class TooManyTreesException: System.Exception
{
    public TooManyTreesException()
    {
    }

    public TooManyTreesException(string message)
        : base(message)
    {
    }

    public TooManyTreesException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}