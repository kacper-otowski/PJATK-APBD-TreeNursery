using CSharp_C3_Zagadnienia.Classes;
using CSharp_C3_Zagadnienia.Exception;

/*
 * Utwórz program wspomagający działanie organizacji, zajmującej się sprzedażą drzew ze szkółek leśnych.
 * 
 * Każda szkółka leśna powinna mieć przypisane unikalne id,
 * liczbę miejsce na drzewa oraz powinna przechowywać listę obecnie zasadzonych tam drzew.
 * Szkółki leśne powinny posiadać funkcjonalność:
 * - Dodawania do szkółki pojedynczego drzewa (w trakcie dodawania powinniśmy sprawdzić,
 *   czy w szkółce znajduje się miejsce na kolejne drzewo - gdy takiego nie ma,
 *   powinien zostać rzucony wyjątek "TooManyTreesException");
 * - Dodawania do szkółki wielu (listy) drzew jednocześnie (w trakcie dodawania powinniśmy sprawdzić,
 *   czy w szkółce znajduje się miejsce na dodawaną liczbę drzew - gdy takiego nie ma,
 *   powinien zostać rzucony wyjątek "TooManyTreesException");
 * - Pobrania danego drzewa po jego unikalnym identyfikatorze;
 * - Sprzedaży drzewa (Organizacja ustaliła, że sprzedawać można tylko drzewa, które mają conajmniej 10 lat.
 *   Jeżeli następuje próba sprzedaży młodszego drzewa, powinien zostać rzucony wyjątek "TooYoungException");
 * - Wypisania informacji o samej szkółce jak i o drzewach znajdujących się w niej.
 *
 * O każdym rosnącym w szkółce drzewie powinniśmy przechowywać informacje o:
 * - jego wieku;
 * - jego obecnej wysokości (w cm);
 * - oraz szerokości (w cm).
 * Każde drzewo powinno implementować metodę AgeUp, pochodząca z interfejsu ITree.
 * Metoda AgeUp odpowiada za zmianę wieku drzewa,
 * wraz z jego rozmiarem - każdy gatunek drzewa posiada inny przyrost z wiekiem.
 *
 * W systemie rozróżnia się w tym momencie następujące gatunki drzew:
 * - Sosna (roczny przyrost to 1cm w szerokości oraz 5cm w wysokości);
 * - Dąb (roczny przyrost to 1cm w szerokości oraz 3.5cm w wysokości)
 *   W przypadku dębu powinniśmy przechowywać dodatkowo informację o jego rasie np. "Pin Oak";
 * - Wierzba (roczny przyrost to 2cm w szerokości oraz 3cm w wysokości)
 *   W przypadku wierzby powinniśmy przechowywać dodatkowo informację o jej kolorze np. "Yellow".
 */




/* Test wybranych metod */

var treeNursery = new TreeNursery(3);
treeNursery.AddManyTrees(
    [
        new Oak(10, 10, 10, "Pin Oak"), // ID: 0
        new Pine(10, 10, 20), // ID: 1
        new Willow(4, 3, 5, "Yellow") // ID: 2
    ]
);

Console.WriteLine(treeNursery);

var tree = treeNursery.GetTreeById(10);

Console.WriteLine(tree is null);

try
{
    treeNursery.AddTree(new Oak(1, 1, 1, "Bur Oak"));
}
catch (TooManyTreesException e)
{
    Console.WriteLine(e.Message);
}
 
var tree2 = treeNursery.GetTreeById(0);
tree2?.AgeUp();

Console.WriteLine(treeNursery);

if (tree2 != null)
{
    treeNursery.SellTree(tree2);
}

Console.WriteLine(treeNursery);

var tree3 = treeNursery.GetTreeById(2);

try
{
    if (tree3 != null)
    {
        treeNursery.SellTree(tree3);
    }
}
catch (TooYoungException e)
{
    Console.WriteLine(e.Message);
}