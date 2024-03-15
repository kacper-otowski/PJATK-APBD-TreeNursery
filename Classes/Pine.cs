namespace CSharp_C3_Zagadnienia.Classes;

public class Pine(int age, double width, double height) : Tree(age, width, height)
{
    public override void AgeUp()
    {
        base.AgeUp();
        Width += 1;
        Height += 5;
    }
}