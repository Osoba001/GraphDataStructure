// See https://aka.ms/new-console-template for more information

using GraphDataStructure;

//Graph<int> genericGraph = Graph<int>.BuildGraph();
//Graph<int>.PrintGraph(genericGraph);
//Console.ReadLine();

GraphW<int> genericGraph = GraphW<int>.BuildGraph();
GraphW<int>.PrintGraph(genericGraph);


Console.WriteLine("\n\n\n");
#region Kruskal's Algorithm
//List<Edge<int>> mstKruskal = genericGraph.MinimumSpanningTreeKruskal();
//foreach (var edge in mstKruskal)
//{
//    Console.WriteLine(edge.ToString());
//}
#endregion Kruskal's Algorithm

#region Prim's Algorithm
//List<Edge<int>> mstPrim=genericGraph.MinimumSpanningTreePrim();
//foreach (var edge in mstPrim)
//{
//    Console.WriteLine(edge.ToString());
//}
#endregion Prim's Algorithm

#region Shortest Distance
//GraphW<int> graph = new GraphW<int>(true, true);
//NodeW<int> n1 = graph.AddNode(1);
//NodeW<int> n2 = graph.AddNode(2);
//NodeW<int> n3 = graph.AddNode(3);
//NodeW<int> n4 = graph.AddNode(4);
//NodeW<int> n5 = graph.AddNode(5);
//NodeW<int> n6 = graph.AddNode(6);
//NodeW<int> n7 = graph.AddNode(7);
//NodeW<int> n8 = graph.AddNode(8);
//graph.AddEdge(n1, n2, 9);
//graph.AddEdge(n1, n3, 5);
//graph.AddEdge(n2, n1, 3);
//graph.AddEdge(n2, n4, 18);
//graph.AddEdge(n3, n4, 12);
//graph.AddEdge(n4, n8, 8);
//graph.AddEdge(n4, n2, 2);
//graph.AddEdge(n5, n4, 9);
//graph.AddEdge(n5, n6, 2);
//graph.AddEdge(n5, n8, 3);
//graph.AddEdge(n5, n7, 5);
//graph.AddEdge(n6, n7, 1);
//graph.AddEdge(n7, n5, 4);
//graph.AddEdge(n7, n8, 6);
//graph.AddEdge(n8, n5, 3);

//List<Edge<int>> path = graph.GetShortestPathDijkstra(graph.Nodes[0], graph.Nodes[6]);

//foreach (var p in path)
//{
//    Console.WriteLine(p.ToString());
//}
#endregion Shortest Distance
Console.ReadLine();