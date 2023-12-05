//MergeSort
/*
class Program
{
    private static void MergeSort(int[] array)
    {
        int length = array.Length;
        if (length <= 1) return;

        int middle = length / 2;
        int[] leftArray = new int[middle];
        int[] rightArray = new int[length - middle];

        for (int i = 0; i < length; i++)
        {
            if (i < middle)
            {
                leftArray[i] = array[i];
            }
            else
            {
                rightArray[i - middle] = array[i];
            }
        }

        MergeSort(leftArray);
        MergeSort(rightArray);
        Merge(leftArray, rightArray, array);
    }

    private static void Merge(int[] leftArray, int[] rightArray, int[] array)
    {
        int leftSize = leftArray.Length;
        int rightSize = rightArray.Length;
        int i = 0, l = 0, r = 0;

        while (l < leftSize && r < rightSize)
        {
            if (leftArray[l] < rightArray[r])
            {
                array[i] = leftArray[l];
                i++;
                l++;
            }
            else
            {
                array[i] = rightArray[r];
                i++;
                r++;
            }
        }

        while (l < leftSize)
        {
            array[i] = leftArray[l];
            i++;
            l++;
        }

        while (r < rightSize)
        {
            array[i] = rightArray[r];
            i++;
            r++;
        }
    }

    static void Main()
    {
        string filePath = "In0201.txt";
        string fileContent = File.ReadAllText(filePath);
        string[] values = fileContent.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(values[0]);
        int[] array = new int[n];

        for (int i = 1; i <= n; i++)
        {
            array[i - 1] = int.Parse(values[i]);
            Console.WriteLine($"tab = {array[i - 1]}");
        }

        MergeSort(array);

        using (StreamWriter writer = new StreamWriter("Out0201.txt"))
        {
            for (int i = 0; i < n; i++)
            {
                writer.WriteLine($"tab = {array[i]}");
            }
        }
    }
}
*/
/* Choinka */
/*
class Program
{
    static void Main(string[] args)
    {

        using (StreamReader reader = new StreamReader("In0202.txt"))
        {
            string[] input = reader.ReadLine().Split();
            int n = int.Parse(input[0]);

            using (StreamWriter writer = new StreamWriter("Out0205.txt"))
            {
                DrawTriangle(n);
            }
        }
    }

    static void DrawTriangle(int n, int currentLine = 1)
    {
        if (currentLine > n)
            return;
        int starsCount = 2 * currentLine - 1;
        int spacesCount = n - currentLine;
        for (int i = 0; i < spacesCount; i++)
        {
            Console.Write(" ");
        }
        for (int i = 0; i < starsCount; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
        DrawTriangle(n, currentLine + 1);
    }
}
*/


/* Bisekcja */
/*

class Program
{
    static void Main()
    {
        double a = -1;   // Początkowy punkt przedziału
        double b = 5;    // Końcowy punkt przedziału
        double E = 0.25; // Dokładność
        // c to srodkowy punkt
        double result = Bisection(a, b, E);

        using (StreamWriter writer = new StreamWriter("Out0205.txt"))
        {
            writer.WriteLine(result);
            Console.WriteLine(result);
        }
    }

    static double Bisection(double a, double b, double E)
    {
        double c = (a + b) / 2;
        double funA = Function(a);
        double funB = Function(b);
        double funC = Function(c);

        if (funA * funB < 0)
        {
            if (Math.Abs(funC) < E) //Math.Abs to zwracanie wartosci bezwzglednej
            {
                return c;
            }

            if (funC * funA < 0)
            {
                return Bisection(a, c, E);
            }
            else
            {
                return Bisection(c, b, E);
            }
        }
        else
        {
            return 0;
        }

    }

    // Funkcja f(x) = x^2 - 2
    static double Function(double x)
    {
        return x * x - 2;
    }
}
*/


/* BST KLP*/

using System;
using System.IO;

public class TreeNode<T>
{
    public T Data { get; set; }
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }
    public TreeNode<T> Parent { get; set; }

    public TreeNode(T data)
    {
        Data = data;
        Left = null;
        Right = null;
        Parent = null;
    }
}

public class BinaryTree<T>
{
    private TreeNode<T> root;

    public BinaryTree()
    {
        root = null;
    }

    public void Insert(T data)
    {
        TreeNode<T> newNode = new TreeNode<T>(data);

        if (root == null)
        {
            root = newNode;
        }
        else
        {
            InsertRecursive(root, newNode);
        }
    }

    private void InsertRecursive(TreeNode<T> currentNode, TreeNode<T> newNode)
    {
        // porównywanie dwóch elementów
        int comparisonResult = Comparer<T>.Default.Compare(newNode.Data, currentNode.Data);

        if (comparisonResult < 0)
        {
            if (currentNode.Left == null)
            {
                currentNode.Left = newNode;
                newNode.Parent = currentNode;
            }
            else
            {
                InsertRecursive(currentNode.Left, newNode);
            }
        }
        else if (comparisonResult > 0)
        {
            if (currentNode.Right == null)
            {
                currentNode.Right = newNode;
                newNode.Parent = currentNode;
            }
            else
            {
                InsertRecursive(currentNode.Right, newNode);
            }
        }
    }

    public void PreOrderTraversal(TreeNode<T> currentNode, StreamWriter writer)
    {
        if (currentNode != null)
        {
            writer.Write(currentNode.Data + " ");
            PreOrderTraversal(currentNode.Left, writer);
            PreOrderTraversal(currentNode.Right, writer);
        }
    }
    public void PrintTreePreOrder(StreamWriter writer)
    {
        PreOrderTraversal(root, writer);
    }
}

class Program
{
    static void Main()
    {
        BinaryTree<int> binaryTree = new BinaryTree<int>();


        using (StreamReader reader = new StreamReader("In0207.txt"))
        {
            string line = reader.ReadLine();
            if (line != null)
            {
                string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string valueStr in values)
                {
                    if (int.TryParse(valueStr, out int value))
                    {
                        binaryTree.Insert(value);
                    }
                }
            }
        }

        using (StreamWriter writer = new StreamWriter("Out0207.txt"))
        {
            binaryTree.PrintTreePreOrder(writer);
        }
    }
}

