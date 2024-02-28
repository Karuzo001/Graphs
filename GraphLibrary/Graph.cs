using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graphs;

public class Graph : IEnumerable<Edge>, ICloneable
{
    public List<string> Vertices { get; set; }
    public List<Edge> Edges { get; set; }

//------------------------------------------------------- ОБЪЯВЛЕНИЕ ГРАФА
    public Graph()
    {
        Edges = new List<Edge>();
        Vertices = new List<string>();
    }

    public Graph(int minLength)
    {
        Edges = new List<Edge>(minLength - 1);
        Vertices = new List<string>(minLength);
    }

    public Graph(Edge edge)
    {
        Edges = new List<Edge>(){edge};
        Vertices = new List<string>() { edge.VertexA, edge.VertexB };
    }

    public Graph(List<Edge> edges)
    {
        Edges = new List<Edge>(edges.Count);
        Vertices = new List<string>(edges.Count);
        Add(edges);
    }

//---------------------------------------------------------------------- ДОБАВЛЕНИЕ ВЕРШИНЫ/РЕБРА/ГРАФА
    public void Add(Edge edge)
    {
            Edges.Add(edge);
        AddVertex(edge);
    }

    public void Add(List<Edge> edges)
    {
        foreach (var edge in edges)
        {
            Add(edge);
        }
    }

    public void Add(Graph graph)
    {
        Add(graph.Edges);
    }

//---------------------------------------------------------ПРОВЕРКА НА ВКЛЮЧЕНИЕ ДАННЫХ ВЕРШИХ В ГРАФ
    private void AddVertex(Edge edge)
    {
        if (!Vertices.Contains(edge.VertexA))
            Vertices.Add(edge.VertexA);
        if (!Vertices.Contains(edge.VertexB))
            Vertices.Add(edge.VertexB);
    }

//---------------------------------------------------------ВЕС ГРАФА
    public double GetWeight()
    {
        return Edges.Sum(edge => edge.EdgeWeight);
    }

//----------------------------------------------------------ВЫВОД ГРАФА
    public override string ToString()
    {
        return Edges.Aggregate(string.Empty,
            (current, edge) => current + edge);
    }

    public void Sort()
    {
        Edges.Sort();
    }

    
    public object Clone()
    {
        return new Graph(Edges);
    }

    public IEnumerator<Edge> GetEnumerator()
    {
        return Edges.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Edges.GetEnumerator();
    }
}