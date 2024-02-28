using System;
using System.Linq;

namespace Graphs;

public class SolutionMethods
{
    public static Graph KruskalAlgorithm(Graph inputData)
    {
        var sortedData = (Graph)inputData.Clone();
        sortedData.Sort();
        var i = 1;
        var resultTree = new SystemOfDisjointSets(sortedData.Edges[0]);
        Console.Write(sortedData.Edges[0]);
        while (resultTree.Sets.First().SetGraph.Vertices.Count != inputData.Vertices.Count)
        {
            Console.Write($"\n{sortedData.Edges[i]}");
            resultTree.AddEdgeInSet(sortedData.Edges[i]);
            i++;
        }

        return resultTree.Sets.First().SetGraph;
    }
}