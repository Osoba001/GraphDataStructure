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

        public Edge<T> this[int from, int to]
        {
            get
            {
                NodeW<T> nodeFrom = Nodes[from];
                NodeW<T> nodeTo = Nodes[to];
                int i = nodeFrom.Neighbors.IndexOf(nodeTo);
                if (i >= 0)
                {
                    Edge<T> edge = new Edge<T>()
                    {
                        From = nodeFrom,
                        To = nodeTo,
                        Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0
                    };
                    return edge;
                }

                return null;
            }
        }

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

        private void UpdateIndices()
        {
            int i = 0;
            Nodes.ForEach(n => n.Index = i++);
        }
        public NodeW<T> AddNode(T value)
        {
            NodeW<T> node = new NodeW<T>() { Value = value };
            if (Find(node) != null)
            {
                //duplicate value
                return null;
            }
            else
            {
                Nodes.Add(node);
                UpdateIndices();
                return node;
            }
        }
        public List<Edge<T>> GetEdges()
        {
            List<Edge<T>> edges = new List<Edge<T>>();
            foreach (NodeW<T> from in Nodes)
            {
                for (int i = 0; i < from.Neighbors.Count; i++)
                {
                    Edge<T> edge = new()
                    {
                        From = from,
                        To = from.Neighbors[i],
                        Weight = i < from.Weights.Count ? from.Weights[i] : 0
                    };
                    edges.Add(edge);
                }
            }
            return edges;
        }
        public NodeW<T> Find(NodeW<T> weightedGraphNode)
        {
            foreach (NodeW<T> node in nodes)
            {
                if (node.Value.Equals(weightedGraphNode.Value))
                {
                    return node;
                }
            }
            return null;
        }
        public bool RemoveNode(NodeW<T> value)
        {
           NodeW<T> removeNode = Find(value);
            if (removeNode == null)
            {
                return false;
            }
            else
            {
                nodes.Remove(removeNode);
                foreach (NodeW<T> node in nodes)
                {
                    node.RemoveNeighbors(removeNode);
                    RemoveEdge(node, removeNode);
                }
                return true;
            }
        }
        public bool AddEdge(NodeW<T> from, NodeW<T> to, int weight)
        {
            NodeW<T> source = Find(from);
            NodeW<T> destination = Find(to);
            if (source == null || destination == null)
            {
                return false;
            }
            else if (source.Neighbors.Contains(destination))
            {
                return false;
            }
            else
            {
                //for direted graph only below 1st line is required  node1->node2
                from.AddNeighbors(to);
                if (_isWeighted)
                {
                    source.Weights.Add(weight);
                }
                //for undireted graph need below line as well
                if (!_isDirected)
                {
                    to.AddNeighbors(from);
                    if (_isWeighted)
                    {
                        to.Weights.Add(weight);
                    }
                }
                return true;
            }
        }
        public bool RemoveEdge(NodeW<T> from, NodeW<T> to)
        {
            NodeW<T> node1 = Find(from);
            NodeW<T> node2 = Find(to);
            if (node1 == null || node2 == null)
            {
                return false;
            }
            else if (!node1.Neighbors.Contains(node2))
            {
                return false;
            }
            else
            {
                //for direted graph only below 1st line is required  node1->node2
                int index = from.Neighbors.FindIndex(n => n == to);
                if (index >= 0)
                {
                    from.Neighbors.RemoveAt(index);
                    if (_isWeighted)
                    {
                        from.Weights.RemoveAt(index);
                    }
                }
                //for undireted graph need below line as well
                index = to.Neighbors.FindIndex(n => n == from);
                if (index >= 0)
                {
                    to.Neighbors.RemoveAt(index);
                    if (_isWeighted)
                    {
                        to.Weights.RemoveAt(index);
                    }
                }
                return true;
            }
        }
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                nodeString.Append(nodes[i].ToString());
                if (i < Count - 1)
                {
                    nodeString.Append("\n");
                }
            }
            return nodeString.ToString();
        }
        public class Subset<T>
        {
            public NodeW<T> Parent { get; set; }
            public int Rank { get; set; }

            public override string ToString()
            {
                return $"Subset with rank {Rank}, parent: {Parent.Value} (index: { Parent.Index})";
            }
        }
        private void Union(Subset<T>[] subsets, NodeW<T> from, NodeW<T> to)
        {
            if (subsets[from.Index].Rank > subsets[to.Index].Rank)
            {
                subsets[to.Index].Parent = from;
            }
            else if (subsets[from.Index].Rank < subsets[to.Index].Rank)
            {
                subsets[from.Index].Parent = to;
            }
            else
            {
                subsets[to.Index].Parent = from;
                subsets[from.Index].Rank++;
            }
        }
        private NodeW<T> GetRoot(Subset<T>[] subsets, NodeW<T> node)
        {
            if (subsets[node.Index].Parent != node)
            {
                subsets[node.Index].Parent = GetRoot(
                    subsets,
                    subsets[node.Index].Parent);
            }

            return subsets[node.Index].Parent;
        }
        private int GetMinimumWeightIndex(int[] weights, bool[] isInMST)
        {
            int minValue = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < Nodes.Count; i++)
            {
                if (!isInMST[i] && weights[i] < minValue)
                {
                    minValue = weights[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public List<Edge<T>> MinimumSpanningTreeKruskal()
        {
            List<Edge<T>> edges = GetEdges();
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
            Queue<Edge<T>> queue = new Queue<Edge<T>>(edges);

            Subset<T>[] subsets = new Subset<T>[Nodes.Count];
            for (int i = 0; i < Nodes.Count; i++)
            {
                subsets[i] = new Subset<T>() { Parent = Nodes[i] };
            }

            List<Edge<T>> result = new List<Edge<T>>();
            while (result.Count < Nodes.Count - 1)
            {
                Edge<T> edge = queue.Dequeue();
                NodeW<T> from = GetRoot(subsets, edge.From);
                NodeW<T> to = GetRoot(subsets, edge.To);
                if (from != to)
                {
                    result.Add(edge);
                    Union(subsets, from, to);
                }
            }

            return result;
        }

        public List<Edge<T>> MinimumSpanningTreePrim()
        {
            int[] previous = new int[Nodes.Count];
            previous[0] = -1;

            int[] minWeight = new int[Nodes.Count];
            Fill(minWeight, int.MaxValue);
            minWeight[0] = 0;

            bool[] isInMST = new bool[Nodes.Count];
            Fill(isInMST, false);

            for (int i = 0; i < Nodes.Count - 1; i++)
            {
                int minWeightIndex = GetMinimumWeightIndex(minWeight, isInMST);
                isInMST[minWeightIndex] = true;

                for (int j = 0; j < Nodes.Count; j++)
                {
                    Edge<T> edge = this[minWeightIndex, j];
                    int weight = edge != null ? edge.Weight : -1;
                    if (edge != null && !isInMST[j] && weight < minWeight[j])
                    {
                        previous[j] = minWeightIndex;
                        minWeight[j] = weight;
                    }
                }
            }

            List<Edge<T>> result = new List<Edge<T>>();
            for (int i = 1; i < Nodes.Count; i++)
            {
                Edge<T> edge = this[previous[i], i];
                result.Add(edge);
            }
            return result;
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


        internal static GraphW<int> BuildGraph()
        {
            GraphW<int> graph = new GraphW<int>(true, true);
            NodeW<int> n1 = graph.AddNode(1);
            NodeW<int> n2 = graph.AddNode(2);
            NodeW<int> n3 = graph.AddNode(3);
            NodeW<int> n4 = graph.AddNode(4);
            NodeW<int> n5 = graph.AddNode(5);
            NodeW<int> n6 = graph.AddNode(6);
            NodeW<int> n7 = graph.AddNode(7);
            NodeW<int> n8 = graph.AddNode(8);

            graph.AddEdge(n1, n2, 3);
            graph.AddEdge(n1, n3, 5);
            graph.AddEdge(n2, n4, 4);
            graph.AddEdge(n3, n4, 12);
            graph.AddEdge(n4, n5, 9);
            graph.AddEdge(n4, n8, 8);
            graph.AddEdge(n5, n6, 4);
            graph.AddEdge(n5, n8, 1);
            graph.AddEdge(n5, n7, 5);
            graph.AddEdge(n6, n7, 6);
            graph.AddEdge(n7, n8, 20);
            return graph;
        }
        internal static void PrintGraph(GraphW<T> graph)
        {
            Console.WriteLine(graph.ToString());
        }
    }
}
