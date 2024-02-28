namespace Graphs;

public class Set
{
    public Graph SetGraph;

    public Set(Edge edge)
    {
        SetGraph = new Graph(edge);
    }

    public void Union(Set set, Edge connectingEdge)
    {
        SetGraph.Add(set.SetGraph);
        SetGraph.Add(connectingEdge);
    }

    public void AddEdge(Edge edge)
    {
        SetGraph.Add(edge);
    }

    public bool Contains(string vertex)
    {
        return SetGraph.Vertices.Contains(vertex);
    }
}