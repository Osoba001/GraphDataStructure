using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure
{
    public class GraphW<T>
    {
        List<NodeW<T>> nodes = new();
        private bool _isDirected = false;
        private bool _isWeighted = false;

        public GraphW(bool isDirected, bool isWeighted)
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }
        private void Fill<Q>(Q[] array, Q value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
        public int Count
        {
            get
            {
                return nodes.Count;
            }
        }
        public List<NodeW<T>> Nodes
        {
            get
            {
                return nodes;
            }
        }

        public List<Edge<T>> GetShortestPathDijkstra(NodeW<T> source, NodeW<T> target)
        {

            int[] previous = new int[Nodes.Count];
            //Set Every Previous node with initial value -1
            Fill(previous, -1);

            int[] distances = new int[Nodes.Count];
            //Set Every Previous node with initial value -1
            Fill(distances, int.MaxValue);
            //Initially distance will be 0 on starting node
            distances[source.Index] = 0;

            SimplePriorityQueue<NodeW<T>> nodes = new SimplePriorityQueue<NodeW<T>>();
            for (int i = 0; i < Nodes.Count; i++)
            {
                nodes.Enqueue(Nodes[i], distances[i]);
            }
            while (nodes.Count != 0)
            {
                NodeW<T> node = nodes.Dequeue();
                for (int i = 0; i < node.Neighbors.Count; i++)
                {
                    NodeW<T> neighbor = node.Neighbors[i];
                    int weight = i < node.Weights.Count ? node.Weights[i] : 0;
                    int weightTotal = distances[node.Index] + weight;

                    if (distances[neighbor.Index] > weightTotal)
                    {
                        distances[neighbor.Index] = weightTotal;
                        previous[neighbor.Index] = node.Index;
                        nodes.UpdatePriority(neighbor, distances[neighbor.Index]);
                    }
                }
            }
            //Getting all the index
            List<int> indices = new List<int>();
            int index = target.Index;
            while (index >= 0)
            {
                indices.Add(index);
                index = previous[index];
            }

            //Reverse all the index to get the correct order
            indices.Reverse();
            List<Edge<T>> result = new();
            for (int i = 0; i < indices.Count - 1; i++)
            {
                Edge<T> edge = this[indices[i], indices[i + 1]];
                result.Add(edge);
            }
            //return list of WeightedEdge
            return result;
        }
       
    }
}
