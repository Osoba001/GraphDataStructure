using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure
{
    //public class Graph<T>
    //{
    //    List<Node<T>> nodes = new();


    //    public int Length
    //    {
    //        get { return nodes.Count; }
    //    }

    //    public IList<Node<T>> Nodes
    //    {
    //        get
    //        {
    //            return nodes.AsReadOnly();
    //        }
    //    }
    //    public bool AddNode(T value)
    //    {
    //        if (Find(value) != null)
    //        {
    //            //duplicate value
    //            return false;
    //        }
    //        else
    //        {
    //            nodes.Add(new Node<T>(value));
    //            return true;
    //        }
    //    }
    //    public bool AddEdge(T value1, T value2)
    //    {
    //        Node<T> node1 = Find(value1);
    //        Node<T> node2 = Find(value2);
    //        if (node1 == null || node2 == null)
    //        {
    //            return false;
    //        }
    //        else if (node1.Neighbors.Contains(node2))
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            node1.AddNeighbor(node2);
    //            node2.AddNeighbor(node1);
    //            return true;
    //        }
    //    }
    //    public Node<T> Find(T value)
    //    {
    //        foreach (Node<T> node in nodes)
    //        {
    //            if (node.Value.Equals(value))
    //            {
    //                return node;
    //            }
    //        }
    //        return null;
    //    }
    //    public bool RemoveNode(T value)
    //    {
    //        Node<T> removeNode = Find(value);
    //        if (removeNode == null)
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            nodes.Remove(removeNode);
    //            foreach (Node<T> node in nodes)
    //            {
    //                node.RemoveNeighbor(removeNode);
    //            }
    //            return true;
    //        }
    //    }
    //    public bool RemoveEdge(T value1, T value2)
    //    {
    //        Node<T> node1 = Find(value1);
    //        Node<T> node2 = Find(value2);
    //        if (node1 == null || node2 == null)
    //        {
    //            return false;
    //        }
    //        else if (!node1.Neighbors.Contains(node2))
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            //for direted graph only below 1st line is required  node1->node2
    //            node1.RemoveNeighbor(node2);
    //            //for undireted graph need below line as well
    //            node2.RemoveNeighbor(node1);
    //            return true;
    //        }
    //    }
    //    public void Clear()
    //    {
    //        foreach (Node<T> node in nodes)
    //        {
    //            node.RemoveAllNeighbors();
    //        }
    //        for (int i = nodes.Count - 1; i >= 0; i--)
    //        {
    //            nodes.RemoveAt(i);
    //        }
    //    }
    //    public override string ToString()
    //    {
    //        StringBuilder nodeString = new StringBuilder();
    //        for (int i = 0; i < Length; i++)
    //        {
    //            nodeString.Append(nodes[i].ToString());
    //            if (i < Length - 1)
    //            {
    //                nodeString.Append("\n");
    //            }
    //        }
    //        return nodeString.ToString();
    //    }

    //    public static Graph<int> BuildGraph()
    //    {
    //        Graph<int> graph = new Graph<int>();
    //        graph.AddNode(1);
    //        graph.AddNode(4);
    //        graph.AddNode(5);
    //        graph.AddNode(7);
    //        graph.AddNode(10);
    //        graph.AddNode(11);
    //        graph.AddNode(12);
    //        graph.AddNode(42);

    //        graph.AddEdge(1, 5);
    //        graph.AddEdge(4, 11);
    //        graph.AddEdge(4, 42);
    //        graph.AddEdge(5, 11);
    //        graph.AddEdge(5, 12);
    //        graph.AddEdge(5, 42);
    //        graph.AddEdge(7, 10);
    //        graph.AddEdge(7, 11);
    //        graph.AddEdge(10, 11);
    //        graph.AddEdge(11, 42);
    //        graph.AddEdge(12, 42);
    //        return graph;
    //    }
    //    internal static void PrintGraph(Graph<T> graph)
    //    {
    //        Console.WriteLine(graph.ToString());
    //    }
    //}
}
