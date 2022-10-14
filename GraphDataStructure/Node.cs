using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure
{
    //public class Node<T>
    //{
    //    T _value;
    //    List<Node<T>> _neighbors;
    //    public Node( T value)
    //    {
    //        _value = value;
    //        _neighbors = new();
    //    }

    //    public T Value
    //    {
    //        get { return _value; }
    //    }

    //    public IList<Node<T>> Neighbors
    //    {
    //        get { return _neighbors.AsReadOnly(); }
    //    }

    //    public bool AddNeighbor(Node<T> nieghbor)
    //    {
    //        if (_neighbors.Contains(nieghbor))
    //            return false;
    //        _neighbors.Add(nieghbor);
    //        return true;
    //    }
    //    public bool RemoveNeighbor(Node<T> nieghbor)
    //    {
    //        return _neighbors.Remove(nieghbor);
    //    }

    //    public void RemoveAllNeighbors()
    //    {
    //        for (int i = _neighbors.Count; i >= 0; i--)
    //        {
    //            _neighbors.Remove(_neighbors[i]);
    //        }
    //    }
    //    public override string ToString()
    //    {
    //        StringBuilder nodeString = new StringBuilder();
    //        nodeString.Append("[ Node value " + _value + " with nieghbors : ");
    //        for (int i = 0; i < _neighbors.Count; i++)
    //        {
    //            nodeString.Append(_neighbors[i].Value + " ");
    //        }
    //        nodeString.Append("]");
    //        return nodeString.ToString();

    //    }

    //}
}
