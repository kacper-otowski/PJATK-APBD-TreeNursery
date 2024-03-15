namespace CSharp_C3_Zagadnienia.Classes;

public class Oak(int age, double width, double height, string species) : Tree(age, width, height)
{
    public string Species { get; } = species;
    
    public override void AgeUp()
    {
        base.AgeUp();
        Width += 1;
        Height += 3.5;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Species: {Species}";
    }
}