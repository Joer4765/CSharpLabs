using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Task_4
{
    public partial class MainWindow
    {
        private readonly Dictionary<string, List<string>> _adjacencyList = new Dictionary<string, List<string>>();
        private Graph _graph;

        public MainWindow()
        {
            InitializeComponent();
            FontFamily = new FontFamily("Courier New");
            
        }

        private void AddEdge_Click(object sender, RoutedEventArgs e)
        {
            var vertex = VertexEntry.Text;
            var neighborsInput = NeighborsEntry.Text;
            var neighbors = neighborsInput.Split(',').Select(n => n.Trim()).ToList();

            if (neighbors.Count != neighbors.Distinct().Count())
            {
                MessageBox.Show("Vertices should be unique.");
                return;
            }

            _adjacencyList[vertex] = neighbors;
            _graph = new Graph(_adjacencyList);

            VertexEntry.Clear();
            NeighborsEntry.Clear();

            DisplayGraphInfo();
        }

        private void ShowGraphInfo_Click(object sender, RoutedEventArgs e)
        {
            DisplayGraphInfo();
        }

        private void DisplayGraphInfo()
        {
            OutputText.Clear();
            
            OutputText.AppendText("Adjacency List:\n");
            foreach (var vertex in _graph.AdjacencyList)
            {
                OutputText.AppendText($"{vertex.Key}: {string.Join(", ", vertex.Value)}\n");
            }

            OutputText.AppendText("\nEdge List:\n");
            foreach (var edge in _graph.EdgeList)
            {
                OutputText.AppendText($"{edge.Item1} - {edge.Item2}\n");
            }

            OutputText.AppendText("\nIncidence Matrix:\n");
            var res = Enumerable.Range(0, _graph.IncidenceMatrix.GetLength(1)).Select(x => $"{x, 4}");
            OutputText.AppendText($"i\\j{string.Join("", res)}\n");

            for (var i = 0; i < _graph.IncidenceMatrix.GetLength(0); i++)
            {
                OutputText.AppendText($"{_graph.SortedVertices[i]}  ");
                for (var j = 0; j < _graph.IncidenceMatrix.GetLength(1); j++)
                {
                    OutputText.AppendText($"{_graph.IncidenceMatrix[i, j], 4}");
                }
                OutputText.AppendText("\n");
            }


            OutputText.AppendText("\nAdjacency Matrix:\n");
            res = _graph.SortedVertices.Select(x => $"{x, 3}");
            OutputText.AppendText($"i\\j{string.Join("", res)}\n");
            for (var i = 0; i < _graph.AdjacencyMatrix.GetLength(0); i++)
            {
                OutputText.AppendText($"{_graph.SortedVertices[i]}  ");
                for (var j = 0; j < _graph.AdjacencyMatrix.GetLength(1); j++)
                {
                    OutputText.AppendText($"{_graph.AdjacencyMatrix[i, j], 3}");
                }
                OutputText.AppendText("\n");
            }
        }
    }
}
