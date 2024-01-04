using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Graph
{
    public Dictionary<string, List<string>> AdjacencyList { get; }

    public HashSet<string> Vertices { get; set; }
    public List<string> SortedVertices { get; set; }

    private Dictionary<string, int> _vertexToIndex;
    private Dictionary<int, string> _indexToVertex;
    public List<(string, string)> EdgeList { get; set; }
    public int[,] IncidenceMatrix { get; set; }
    public int[,] AdjacencyMatrix { get; set; }

    public Graph(Dictionary<string, List<string>> adjacencyList)
    {
        AdjacencyList = adjacencyList;
        InitializeGraphData();
    }

    private void InitializeGraphData()
    {
        Vertices = new HashSet<string>(AdjacencyList.Keys);
        foreach (var neighbor in AdjacencyList.Values.SelectMany(neighbors => neighbors))
        {
            Vertices.Add(neighbor);
        }
        SortedVertices = Vertices.ToList();
        SortedVertices.Sort();

        var index = 0;
        _vertexToIndex = new Dictionary<string, int>();
        _indexToVertex = new Dictionary<int, string>();
        foreach (var vertex in SortedVertices)
        {
            _vertexToIndex[vertex] = index;
            _indexToVertex[index] = vertex;
            index++;
        }

        EdgeList = ToEdgeList();
        IncidenceMatrix = ToIncidenceMatrix();
        AdjacencyMatrix = ToAdjacencyMatrix();
    }

    private List<(string, string)> ToEdgeList()
    {
        var edgeList = new List<(string, string)>();
        foreach (var kvp in AdjacencyList)
        {
            string vertex = kvp.Key;
            foreach (string neighbor in kvp.Value)
            {
                edgeList.Add((vertex, neighbor));
            }
        }
        return edgeList;
    }

    private int[,] ToIncidenceMatrix()
    {
        int numVertices = Vertices.Count;
        int numEdges = EdgeList.Count;
        int[,] incidenceMatrix = new int[numVertices, numEdges];
        int edgeIndex = 0;

        foreach (var kvp in AdjacencyList)
        {
            string vertex = kvp.Key;
            foreach (string neighbor in kvp.Value)
            {
                incidenceMatrix[_vertexToIndex[vertex], edgeIndex] = 1;
                incidenceMatrix[_vertexToIndex[neighbor], edgeIndex] = -1;
                if (vertex == neighbor)  // Check for loops
                {
                    incidenceMatrix[_vertexToIndex[vertex], edgeIndex] = 2;
                }
                edgeIndex++;
            }
        }

        return incidenceMatrix;
    }

    private int[,] ToAdjacencyMatrix()
    {
        int numVertices = Vertices.Count;
        var adjacencyMatrix = new int[numVertices, numVertices];

        foreach (var kvp in AdjacencyList)
        {
            var vertex = kvp.Key;
            foreach (var neighbor in kvp.Value)
            {
                adjacencyMatrix[_vertexToIndex[vertex], _vertexToIndex[neighbor]] = 1;
            }
        }

        return adjacencyMatrix;
    }

    private List<(string, string)> AllEdges()
    {
        var edges = new List<(string, string)>();
        foreach (var kvp in AdjacencyList)
        {
            string vertex = kvp.Key;
            foreach (string neighbor in kvp.Value)
            {
                edges.Add((vertex, neighbor));
            }
        }
        return edges;
    }
}
