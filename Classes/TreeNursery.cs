using System.Text;
using CSharp_C3_Zagadnienia.Exception;

namespace CSharp_C3_Zagadnienia.Classes;

public class TreeNursery(int space)
{
    private static int _nextId = 0;

    
    public int Id { get; } = _nextId++;
    public int Space { get; private set; } = space;
    private List<Tree> Trees { get; set; } = [];
    

    public void SellTree(Tree tree)
    {
        if (!Trees.Contains(tree)) return;

        if (tree.Age < 10)
        {
            throw new TooYoungException("The tree is too young to sell it");
        }

        Trees.Remove(tree);
    }

    public void AddTree(Tree tree)
    {
        CheckIfThereIsEnoughEmptySpace(1);
        if (Trees.Contains(tree)) return;
        
        Trees.Add(tree);
    }

    public void AddManyTrees(List<Tree> trees)
    {
        CheckIfThereIsEnoughEmptySpace(trees.Count);
        foreach (var tree in trees)
        {
            if (Trees.Contains(tree))
            {
                continue;
            }

            Trees.Add(tree);
        }
    }

    public Tree? GetTreeById(int id)
    {
        /* Option1: Get tree object */
        var tree = Trees.Find(tree => tree.Id == id);
        return tree;
        

        /* Option2: Get index of the tree at first */
        var treeIndex = Trees.FindIndex(tree => tree.Id == id);
        if (treeIndex != -1)
        {
            return Trees[treeIndex];
        }
        
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var tree in Trees)
        {
            sb.Append($" {tree}");
            sb.AppendLine();
        }

        return $"TreeNursery {Id} : Space: {Space}, OccupiedSpace: {Trees.Count}, Trees: \n[\n{sb}]";
    }
    
    private void CheckIfThereIsEnoughEmptySpace(int amount)
    {
        if (Trees.Count + amount > Space)
        {
            throw new TooManyTreesException("Action aborted - there is not enough space to add such a number of new trees.");
        }
    }
}