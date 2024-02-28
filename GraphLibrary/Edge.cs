using System;

namespace Graphs;

public class Edge : IComparable<Edge>
{
    public double EdgeWeight { get; set; }
    public string VertexA { get; set; }
    public string VertexB { get; set; }

    public Edge(string vertexA, string vertexB, double weight)
    {
        if (!(weight > 0)) return;
        VertexA = vertexA;
        VertexB = vertexB;
        EdgeWeight = weight;
    }

    public override string ToString()
    {
        return $"({VertexA},{VertexB}) l={EdgeWeight}";
    }

    public int CompareTo(Edge other)
    {
        return other == null ? 1 : EdgeWeight.CompareTo(other.EdgeWeight);
    }
}