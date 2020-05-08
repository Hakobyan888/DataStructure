using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructureProblems
{
    public class Edge<T> : IComparable<Edge<T>>
    {
        public Edge()
        {

        }

        public Edge(T edgeTo, double weight = 0)
        {
            EdgeTo = edgeTo;
            Weight = weight;
        }
        public Edge(T edgeFrom, T edgeTo, double weight = 0)
        {
            EdgeFrom = edgeFrom;
            EdgeTo = edgeTo;
            Weight = weight;
        }

        public T EdgeFrom { get; set; }
        public T EdgeTo { get; set; }
        public double Weight { get; set; }

        public int CompareTo(Edge<T> compareEdge)
        {
            if (compareEdge == null)
                return 1;

            else
                return (int)(this.Weight - compareEdge.Weight);
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var edge = obj as Edge<T>;
            if (edge == null)
            {
                return false;
            }

            // Return true if the fields match:
            return EdgeFrom.Equals(edge.EdgeFrom) && EdgeTo.Equals(edge.EdgeTo) && Weight == edge.Weight;
        }
        public override int GetHashCode()
        {
            return EdgeTo.GetHashCode() ^ EdgeFrom.GetHashCode();
        }
    }

    public class Graph<T>
    {
        public Graph() { }
        public Graph(int n)
        {
            AdjacencyList = new Dictionary<T, HashSet<Edge<T>>>(n);
        }

        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T, double>> edges, bool isDirected = false)
        {
            foreach (var vertex in vertices)
                AddVertexToList(vertex);

            foreach (var edge in edges)
                AddEdgeToList(edge, isDirected);
        }

        public Dictionary<T, HashSet<Edge<T>>> AdjacencyList { get; } = new Dictionary<T, HashSet<Edge<T>>>();

        public HashSet<Edge<T>> Edges { get; } = new HashSet<Edge<T>>();
        public SortedSet<Tuple<T, T>> UnWeightedEdges { get; } = new SortedSet<Tuple<T, T>>();

        public void AddVertexToList(T vertex)
        {
            if (AdjacencyList.ContainsKey(vertex)) return;
            AdjacencyList[vertex] = new HashSet<Edge<T>>();
        }

        public void AddEdgeToList(Tuple<T, T, double> edge, bool isDirected = false)
        {
            AdjacencyList[edge.Item1].Add(new Edge<T>(edge.Item2, edge.Item3));
            Edges.Add(new Edge<T>(edge.Item1, edge.Item2, edge.Item3));
            UnWeightedEdges.Add(Tuple.Create(edge.Item1, edge.Item2));
            if (!isDirected)
            {
                AdjacencyList[edge.Item2].Add(new Edge<T>(edge.Item1, edge.Item3));
                Edges.Add(new Edge<T>(edge.Item2, edge.Item1, edge.Item3));
                UnWeightedEdges.Add(Tuple.Create(edge.Item2, edge.Item1));
            }
        }

    }

    public class GraphAlgorithms<T>
    {
        public T Infinity { get; set; }
        public Dictionary<T, int> BFS(Graph<T> graph, T start)
        {
            var visited = new Dictionary<T, int>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<Tuple<T, int>>();
            queue.Enqueue(Tuple.Create(start, 0));
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.ContainsKey(vertex.Item1))
                    continue;

                visited.Add(vertex.Item1, vertex.Item2);

                foreach (var neighbor in graph.AdjacencyList[vertex.Item1])
                    if (!visited.ContainsKey(neighbor.EdgeTo))
                    {
                        queue.Enqueue(Tuple.Create(neighbor.EdgeTo, vertex.Item2 + 1));
                    }
            }

            return visited;
        }

        public HashSet<T> DFS(Graph<T> graph, T start, object end = null)
        {
            bool isFinished = false;
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);
                if (!isFinished)
                    foreach (var neighbor in graph.AdjacencyList[vertex])
                        if (!visited.Contains(neighbor.EdgeTo))
                        {
                            stack.Push(neighbor.EdgeTo);
                            if (end != null && neighbor.EdgeTo.Equals(end)) isFinished = true;
                        }

            }

            return visited;
        }

        public Func<T, IEnumerable<T>> ShortestPathFunction(Graph<T> graph, T start)
        {
            var previous = new Dictionary<T, T>();

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (previous.ContainsKey(neighbor.EdgeTo))
                        continue;

                    previous[neighbor.EdgeTo] = vertex;
                    queue.Enqueue(neighbor.EdgeTo);
                }
            }

            Func<T, IEnumerable<T>> shortestPath = v =>
            {
                var path = new List<T> { };

                var current = v;
                while (!current.Equals(start))
                {
                    path.Add(current);
                    try
                    {
                        current = previous[current];
                    }
                    catch
                    {
                        return null;
                    }
                };

                path.Add(start);
                path.Reverse();

                return path;
            };

            return shortestPath;
        }

        public Dictionary<int, List<T>> FindComponents(Graph<T> graph)
        {
            int count = 0;
            bool visited;
            Dictionary<int, List<T>> components = new Dictionary<int, List<T>>();
            foreach (var item in graph.AdjacencyList)
            {
                visited = false;
                for (int i = 0; i < count; i++)
                {
                    if (count > 0 && components[i].Contains(item.Key))
                    {
                        visited = true;
                        break;
                    }
                }
                if (visited) continue;
                var dfs = DFS(graph, item.Key);
                foreach (var dItem in dfs)
                {
                    if (!components.ContainsKey(count))
                        components.Add(count, new List<T>() { dItem });
                    else
                        components[count].Add(dItem);
                }
                count++;
            }

            return components;
        }

        public T[] TopologicalSort(Graph<T> graph, string type = "dfs")
        {
            int n = graph.AdjacencyList.Count;
            List<T> ordering = new List<T>();
            T[] order = new T[n];
            int i = n - 1;
            switch (type)
            {
                case "bfs":
                    foreach (var item in graph.AdjacencyList)
                    {
                        if (ordering.Contains(item.Key)) continue;
                        var dfs = BFS(graph, item.Key);
                        if (dfs.Count < 2) continue;
                        List<T> thumb = new List<T>();
                        foreach (var dItem in dfs)
                        {
                            if (ordering.Contains(dItem.Key)) continue;
                            thumb.Add(dItem.Key);
                        }
                        for (int k = thumb.Count - 1; k > -1; k--)
                        {
                            order[i] = thumb[k];
                            i--;
                        }
                        ordering.AddRange(thumb);
                    }
                    break;
                default:
                    foreach (var item in graph.AdjacencyList)
                    {
                        if (ordering.Contains(item.Key)) continue;
                        var dfs = DFS(graph, item.Key);
                        if (dfs.Count < 2) continue;
                        List<T> thumb = new List<T>();
                        foreach (var dItem in dfs)
                        {
                            if (ordering.Contains(dItem)) continue;
                            thumb.Add(dItem);
                        }
                        for (int k = thumb.Count - 1; k > -1; k--)
                        {
                            order[i] = thumb[k];
                            i--;
                        }
                        ordering.AddRange(thumb);
                    }
                    break;
            }
            return order;
        }

        public List<T> TopologicalSortKahn(Graph<T> graph)
        {
            var nodes = graph.AdjacencyList.Keys;
            var edges = graph.UnWeightedEdges;
            var L = new List<T>(); // will contain the sorted elements
            var S = new SortedSet<T>(nodes.Where(n => edges.All(e => !e.Item2.Equals(n)))); // no incoming edges
            while (S.Any())
            {
                var n = S.First();
                S.Remove(n);
                L.Add(n);
                foreach (var e in edges.Where(e => e.Item1.Equals(n)).ToList())
                {
                    var m = e.Item2;
                    edges.Remove(e);
                    if (edges.All(incoming => !incoming.Item2.Equals(m)))
                        S.Add(m);
                }
            }
            return edges.Any() ? null : L;
        }

        public bool IsTopologicalSortValid(Graph<T> graph, HashSet<T> sorted)
        {
            var edges = graph.UnWeightedEdges;

            var dict = new Dictionary<T, int>();

            int i = 0;
            foreach (var item in sorted)
            {
                dict[item] = i++;
            }

            foreach (var edge in edges)
            {
                if (dict[edge.Item1] > dict[edge.Item2])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Shortest distance for every graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public Dictionary<T, double> ShortestDistance(Graph<T> graph, T start)
        {
            int n = graph.AdjacencyList.Count;
            var topSort = TopologicalSortKahn(graph);
            Dictionary<T, double> distance = new Dictionary<T, double>();
            foreach (var item in graph.AdjacencyList)
            {
                distance[item.Key] = int.MaxValue - 1000;
            }
            distance[start] = 0;

            for (int i = 0; i < n; i++)
            {
                var nodeIndex = topSort[i];
                if (distance[nodeIndex] != int.MaxValue - 1000)
                {
                    var edges = graph.AdjacencyList[nodeIndex];
                    if (edges != null)
                    {
                        foreach (var edge in edges)
                        {
                            double newDist = distance[nodeIndex] + edge.Weight;
                            if (distance[edge.EdgeTo] == int.MaxValue - 1000) distance[edge.EdgeTo] = newDist;
                            else distance[edge.EdgeTo] = Math.Min(distance[edge.EdgeTo], newDist);
                        }
                    }
                }
            }
            return distance;
        }

        /// <summary>
        /// Longest distance for every graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public Dictionary<T, double> LongestDistance(Graph<T> graph, T start)
        {
            int n = graph.AdjacencyList.Count;
            var topSort = TopologicalSortKahn(graph);
            Dictionary<T, double> distance = new Dictionary<T, double>();
            foreach (var item in graph.AdjacencyList)
            {
                distance[item.Key] = int.MaxValue - 1000;
            }
            distance[start] = 0;

            for (int i = 0; i < n; i++)
            {
                var nodeIndex = topSort[i];
                if (distance[nodeIndex] != int.MaxValue - 1000)
                {
                    var edges = graph.AdjacencyList[nodeIndex];
                    if (edges != null)
                    {
                        foreach (var edge in edges)
                        {
                            double newDist = distance[nodeIndex] + edge.Weight * -1;
                            if (distance[edge.EdgeTo] == int.MaxValue - 1000) distance[edge.EdgeTo] = newDist;
                            else distance[edge.EdgeTo] = Math.Min(distance[edge.EdgeTo], newDist);
                        }
                    }
                }
            }
            foreach (var k in distance.Keys.ToList())
            {
                distance[k] *= -1;
            }
            return distance;
        }

        /// <summary>
        /// The shortest distance for graph with non-negative numbers
        /// Dijkstra's Algorithm
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Tuple<Dictionary<T, double>, Dictionary<T, T>> NonNegativeShortestDistance(Graph<T> graph, T start)
        {
            Dictionary<T, double> distance = new Dictionary<T, double>();
            Dictionary<T, T> ordering = new Dictionary<T, T>();

            distance[start] = 0;
            List<T> visited = new List<T>();

            foreach (var item in graph.AdjacencyList)
            {
                distance[item.Key] = int.MaxValue - 1000;
            }

            distance[start] = 0;
            Queue<Tuple<T, double>> queue = new Queue<Tuple<T, double>>();
            queue.Enqueue(Tuple.Create(start, 0d));

            while (queue.Count > 0)
            {
                var tuple = queue.Dequeue();
                var item = tuple.Item1;
                var minValue = tuple.Item2;
                if (distance[item] < minValue) continue;
                if (!graph.AdjacencyList.ContainsKey(item)) return null;
                foreach (var edge in graph.AdjacencyList[item])
                {
                    visited.Add(edge.EdgeTo);
                    double newDist = distance[item] + edge.Weight;
                    if (distance.ContainsKey(edge.EdgeTo) && newDist < distance[edge.EdgeTo])
                    {
                        ordering[edge.EdgeTo] = item;
                        distance[edge.EdgeTo] = newDist;
                        queue.Enqueue(Tuple.Create(edge.EdgeTo, newDist));
                    }
                }

            }

            return Tuple.Create(distance, ordering);
        }

        public List<Tuple<T, double>> OrderedListShortesDistance(Graph<T> graph, T start, T end)
        {
            var shortesPath = NonNegativeShortestDistance(graph, start);
            if (shortesPath == null) return null;
            var distance = shortesPath.Item1;
            var ordering = shortesPath.Item2;
            List<Tuple<T, double>> orderedDist = new List<Tuple<T, double>>(ordering.Count + 50);
            for (var i = end; i != null; i = ordering[i])
            {
                orderedDist.Add(Tuple.Create(i, distance[i]));
                if (!ordering.ContainsKey(i)) break;
            }
            orderedDist.Reverse();

            return orderedDist;
        }

        public List<Edge<T>> Kruskal(Graph<T> graph, List<T> comb = null)
        {
            var edges = new HashSet<Edge<T>>(graph.Edges).ToList();
            var numberOfVertices = graph.AdjacencyList.Count;
            edges.Sort();

            Dictionary<T, T> parent = new Dictionary<T, T>(numberOfVertices);
            if (comb != null)
            {
                foreach (var station in comb)
                {
                    var start = FindRoot(station, parent);
                    var end = FindRoot(comb[0], parent);
                    parent[end] = start;
                }
            }
            var spanningTree = new List<Edge<T>>();
            foreach (var edge in edges)
            {
                var startNodeRoot = FindRoot(edge.EdgeFrom, parent);
                var endNodeRoot = FindRoot(edge.EdgeTo, parent);

                if (!startNodeRoot.Equals(endNodeRoot))
                {
                    spanningTree.Add(edge);
                    parent[endNodeRoot] = startNodeRoot;
                }
            }
            return spanningTree;
        }

        private static T FindRoot(T node, Dictionary<T, T> parent)
        {
            var root = node;
            if (parent.ContainsKey(root))
                while (!root.Equals(parent[root]))
                {
                    root = parent[root];
                    if (!parent.ContainsKey(root)) break;

                }

            while (!node.Equals(root))
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }

    }


    //public class GraphCaller
    //{
    //    public void ShortestPathCaller()
    //    {
    //        //var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    //        //var edges = new[]{Tuple.Create(1,2,1), Tuple.Create(1,3,1),
    //        //    Tuple.Create(2,4,1), Tuple.Create(3,5,1), Tuple.Create(3,6,1),
    //        //    Tuple.Create(4,7,1), Tuple.Create(5,7,1), Tuple.Create(5,8,1),
    //        //    Tuple.Create(5,6,1), Tuple.Create(8,9,1), Tuple.Create(9,10,1)};

    //        var vertices = new[] { 1, 2, 3, 4, 5, 6 };
    //        var edges = new[]{Tuple.Create(5,6,1d), Tuple.Create(6,4,1d),
    //            Tuple.Create(4,5,1d), Tuple.Create(4,1,1d), Tuple.Create(1,2,1d),
    //            Tuple.Create(2,3,1d),Tuple.Create(5,2,1d),Tuple.Create(2,1,1d),Tuple.Create(1,4,1d)};


    //        var graph = new Graph<int>(vertices, edges, true);
    //        var graphAlg = new GraphAlgorithms<int>();
    //        var startVertex = 1;
    //        var shortestPath = graphAlg.ShortestPathFunction(graph, startVertex);
    //        Console.WriteLine("shortest path to {0,2}: {1}",
    //                    5, string.Join(", ", shortestPath(4)));
    //    }

    //    public void FindComponentsCaller()
    //    {
    //        //var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    //        //var edges = new[]{Tuple.Create(1,2,1), Tuple.Create(1,3,1),
    //        //    Tuple.Create(2,4,1), Tuple.Create(3,5,1), Tuple.Create(3,6,1),
    //        //    Tuple.Create(4,7,1), Tuple.Create(5,7,1), Tuple.Create(5,8,1),
    //        //    Tuple.Create(5,6,1), Tuple.Create(8,9,1), Tuple.Create(9,10,1)};

    //        var vertices = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
    //        var edges = new[]{Tuple.Create(0,8,1), Tuple.Create(8,4,1),
    //            Tuple.Create(4,0,1), Tuple.Create(8,14,1), Tuple.Create(14,13,1),
    //            Tuple.Create(14,0,1),Tuple.Create(13,0,1),Tuple.Create(6,11,1),Tuple.Create(7,6,1),
    //            Tuple.Create(11,7,1),Tuple.Create(1,5,1),Tuple.Create(5,16,1),Tuple.Create(5,17,1)
    //        };


    //        //var graph = new Graph<int>(vertices, edges, true);
    //        //var graphAlg = new GraphAlgorithms<int>();
    //        //var shortestPath = graphAlg.FindComponents(graph);
    //        //Console.WriteLine("shortest path to {0,2}: {1}",
    //        //            5, string.Join(", ", shortestPath));
    //    }

    //    public void BFS()
    //    {
    //        //var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    //        //var edges = new[]{Tuple.Create(1,2,1), Tuple.Create(1,3,1),
    //        //    Tuple.Create(2,4,1), Tuple.Create(3,5,1), Tuple.Create(3,6,1),
    //        //    Tuple.Create(4,7,1), Tuple.Create(5,7,1), Tuple.Create(5,8,1),
    //        //    Tuple.Create(5,6,1), Tuple.Create(8,9,1), Tuple.Create(9,10,1)};

    //        //var graph = new Graph<int>(vertices, edges);
    //        var graphAlg = new GraphAlgorithms<int>();


    //        //Console.WriteLine(string.Join(", ", graphAlg.BFS(graph, 1)));
    //    }

    //    public void DFS()
    //    {
    //        var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    //        var edges = new[]{Tuple.Create(1,2,1), Tuple.Create(1,3,1),
    //            Tuple.Create(2,4,1), Tuple.Create(3,5,1), Tuple.Create(3,6,1),
    //            Tuple.Create(4,7,1), Tuple.Create(5,7,1), Tuple.Create(5,8,1),
    //            Tuple.Create(5,6,1), Tuple.Create(8,9,1), Tuple.Create(9,10,1)};

    //        var graph = new Graph<int>(vertices, edges);
    //        var graphAlg = new GraphAlgorithms<int>();


    //        Console.WriteLine(string.Join(", ", graphAlg.DFS(graph, 1)));
    //    }

    //    public void TopSort()
    //    {
    //        var vertices = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };
    //        var edges = new[]{Tuple.Create('C', 'A', 1), Tuple.Create('C', 'B', 1),
    //            Tuple.Create('A', 'D', 1), Tuple.Create('B', 'D', 1), Tuple.Create('D', 'G', 1),
    //            Tuple.Create('D', 'H', 1), Tuple.Create('G', 'I', 1), Tuple.Create('I', 'L', 1),
    //            Tuple.Create('H', 'I', 1), Tuple.Create('H', 'J', 1), Tuple.Create('J', 'M', 1),
    //            Tuple.Create('J', 'L', 1), Tuple.Create('E', 'A', 1), Tuple.Create('E', 'D', 1),
    //            Tuple.Create('E', 'F', 1), Tuple.Create('F', 'K', 1), Tuple.Create('F', 'J', 1),
    //            Tuple.Create('K', 'J', 1),
    //        };

    //        var graph = new Graph<char>(vertices, edges, true);
    //        var graphAlg = new GraphAlgorithms<char>();
    //        char[] chars = new char[3];
    //        chars[0] = 'H';
    //        chars[1] = 'E';
    //        chars[2] = 'C';

    //        Console.WriteLine(string.Join(", ", graphAlg.TopologicalSortKahn(graph)));
    //    }

    //    public void ShortestDistanceCaller()
    //    {
    //        var vertices = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
    //        var edges = new[]{Tuple.Create('A', 'B', 3), Tuple.Create('A', 'C', 6),
    //            Tuple.Create('B', 'C', 4), Tuple.Create('B', 'D', 4), Tuple.Create('B', 'E', 11),
    //            Tuple.Create('C', 'D', 8), Tuple.Create('C', 'G', 11), Tuple.Create('D', 'E', -4),
    //            Tuple.Create('D', 'F', 5), Tuple.Create('D', 'G', 2), Tuple.Create('E', 'H', 9),
    //            Tuple.Create('F', 'H', 1), Tuple.Create('G', 'H', 2)};

    //        //var vertices = new[] { 0, 1, 2, 3, 4 };
    //        //var edges = new[]{Tuple.Create(0, 1, 4), Tuple.Create(0, 2, 1),
    //        //    Tuple.Create(2, 1, 2), Tuple.Create(2, 3, 5), Tuple.Create(1, 3, 1),
    //        //    Tuple.Create(3, 4, 3)};

    //        var graph = new Graph<char>(vertices, edges, true);
    //        var graphAlg = new GraphAlgorithms<char>();

    //        Console.WriteLine(string.Join(", ", graphAlg.ShortestDistance(graph, vertices[0])));
    //    }

    //    public void LongestDistanceCaller()
    //    {
    //        var vertices = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
    //        var edges = new[]{Tuple.Create('A', 'B', 3), Tuple.Create('A', 'C', 6),
    //            Tuple.Create('B', 'C', 4), Tuple.Create('B', 'D', 4), Tuple.Create('B', 'E', 11),
    //            Tuple.Create('C', 'D', 8), Tuple.Create('C', 'G', 11), Tuple.Create('D', 'E', -4),
    //            Tuple.Create('D', 'F', 5), Tuple.Create('D', 'G', 2), Tuple.Create('E', 'H', 9),
    //            Tuple.Create('F', 'H', 1), Tuple.Create('G', 'H', 2)};

    //        var graph = new Graph<char>(vertices, edges, true);
    //        var graphAlg = new GraphAlgorithms<char>();

    //        Console.WriteLine(string.Join(", ", graphAlg.LongestDistance(graph, vertices[0])));
    //    }

    //    public void NonNegShortestDistanceCaller()
    //    {
    //        var vertices = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
    //        var edges = new[]{Tuple.Create('A', 'B', 3), Tuple.Create('A', 'C', 6),
    //            Tuple.Create('B', 'C', 4), Tuple.Create('B', 'D', 4), Tuple.Create('B', 'E', 11),
    //            Tuple.Create('C', 'D', 8), Tuple.Create('C', 'G', 11), Tuple.Create('D', 'E', -4),
    //            Tuple.Create('D', 'F', 5), Tuple.Create('D', 'G', 2), Tuple.Create('E', 'H', 9),
    //            Tuple.Create('F', 'H', 1), Tuple.Create('G', 'H', 2)};

    //        var graph = new Graph<char>(vertices, edges, true);
    //        var graphAlg = new GraphAlgorithms<char>();

    //        Console.WriteLine(string.Join(", ", graphAlg.NonNegativeShortestDistance(graph, vertices[0], vertices[5])));
    //    }
    //}

    //1, 2, 3, 4, 5, 6
    //5,6,1
    //6,4,1
    //4,5,1
    //4,1,1
    //1,2,1
    //2,3,1
    //5,2,1
    //2,1,1
    //1,4,1

    //0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17
    //0,8,1
    //8,4,1
    //4,0,1
    //8,14,1
    //14,13,1
    //14,0,1
    //13,0,1
    //6,11,1
    //7,6,1
    //11,7,1
    //1,5,1
    //5,16,1
    //5,17,1
}
