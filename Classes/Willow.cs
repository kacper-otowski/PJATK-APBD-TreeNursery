namespace CSharp_C3_Zagadnienia.Classes;

public class Willow(int age, double width, double height, string color) : Tree(age, width, height)
{
    public string Color { get; } = color;
    
    public override void AgeUp()
    {
        base.AgeUp();
        Width += 2;
        Height += 3;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Color: {Color}";
    }
}