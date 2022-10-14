using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure
{
    public class Edge<T>
    {
        public NodeW<T> From { get; set; }
        public NodeW<T> To { get; set; }
        public int Weight { get; set; }

        // ComparatorTo for sorting edges based on their weight
        //public int CompareTo(WeightedEdge<T> compareEdge)
        //{
        //    return this.Weight - compareEdge.Weight;
        //}
        public override string ToString()
        {
            return $"WeightedEdge: {From.Value} -> {To.Value}, weight: { Weight}";
        }
    }
}
