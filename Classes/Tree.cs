using CSharp_C3_Zagadnienia.Interfaces;

namespace CSharp_C3_Zagadnienia.Classes;

// C# approach
public abstract class Tree(int age, double width, double height) : ITree
{
    private static int _nextId = 0;


    public int Id { get; } = _nextId++;
    public int Age { get; private set; } = age;
    public double Width { get; protected set; } = width;
    public double Height { get; protected set; } = height;

    public virtual void AgeUp()
    {
        Age++;
    }

    public override string ToString()
    {
        return $"[{GetType().Name}] -- ID: {Id}, Age: {Age}, Width: {Width}, Height: {Height}";
    }
}



// Java approach
public abstract class Tree2 : ITree
{
    private static int _nextId = 0;
    

    private readonly int _id = _nextId++;
    private int _age;
    private double _width;
    private double _height;

    public Tree2(int age, double width, double height)
    {
        _age = age;
        _width = width;
        _height = height;
    }

    public int GetId()
    {
        return _id;
    }

    public int GetAge()
    {
        return _age;
    }

    protected void SetAge(int age)
    {
        _age = age;
    }

    public double GetWidth()
    {
        return _width;
    }

    protected void SetWidth(double width)
    {
        _width = width;
    }

    public double GetHeight()
    {
        return _height;
    }

    protected void SetHeight(double height)
    {
        _height = height;
    }

    public virtual void AgeUp()
    {
        _age++;
    }

    public override string ToString()
    {
        return "[" + GetType() + "] -- ID: " + _id + ", Age: " + _age + ", Width: " + _width + ", Height: " +
               _height;
    }
}