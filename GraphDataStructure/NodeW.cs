using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure
{
    public class NodeW<T>
    {
        public int Index { get; set; }
        public T Value { get; set; }
        public List<NodeW<T>> Neighbors { get; set; } = new();
        public List<int> Weights { get; set; } = new List<int>();

      
        public bool AddNeighbors(NodeW<T> neighbor)
        {
            if (Neighbors.Contains(neighbor))
            {
                return false;
            }
            else
            {
                Neighbors.Add(neighbor);
                return true;
            }
        }
        public bool RemoveNeighbors(NodeW<T> neighbor)
        {
            return Neighbors.Remove(neighbor);
        }

        public bool RemoveAllNeighbors()
        {
            for (int i = Neighbors.Count; i >= 0; i--)
            {
                Neighbors.RemoveAt(i);
            }
            return true;
        }
       
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append("[ Node Value - " + Value + " with Neighbors : ");
            for (int i = 0; i < Neighbors.Count; i++)
            {
                //WeightedEdge<T> edge = new WeightedEdge<T>()
                //{
                //    From = this,
                //    To = this.Neighbors[i],
                //    Weight = i < this.Weights.Count ? this.Weights[i] : 0
                //};
                nodeString.Append(Neighbors[i].Value + " ");// + edge.ToString()+ " ");                
            }
            nodeString.Append("]");
            return nodeString.ToString();
        }
    }
}
